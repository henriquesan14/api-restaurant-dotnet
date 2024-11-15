using AutoMapper;
using MediatR;
using Restaurant.Application.ViewModels;
using Restaurant.Core.Common;
using Restaurant.Core.Entities;
using Restaurant.Core.Enums;
using Restaurant.Core.Repositories;

namespace Restaurant.Application.Commands.OrderCommands.CreateCommonOrder
{
    public class CreateCommonOrderCommandHandler : IRequestHandler<CreateCommonOrderCommand, Result<OrderViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCommonOrderCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<OrderViewModel>> Handle(CreateCommonOrderCommand request, CancellationToken cancellationToken)
        {
            var entity = new CommonOrder(request.ClientId, request.TableId, 0, request.CreatedByUserId);

            await _unitOfWork.BeginTransaction();

            foreach (var item in request.Items)
            {
                var menuItem = await _unitOfWork.MenuItems.GetMenuItemIncludeItemsByIdAsync(item.MenuItemId!.Value);

                var orderItem = new OrderItem(item.Quantity.Value, menuItem, item.Observation, request.CreatedByUserId);

                entity.AddItem(orderItem);

                foreach (var neededProduct in menuItem.NeededProducts)
                {
                    var stockProduct = await _unitOfWork.StockProducts.GetByIdAsync(neededProduct.ProductId);
                    var product = await _unitOfWork.Products.GetByIdAsync(neededProduct.ProductId);

                    var totalRequiredQuantity = neededProduct.QuantityRequired * item.Quantity.Value;

                    if (stockProduct.QuantityInStock < neededProduct.QuantityRequired * item.Quantity.Value)
                    {
                        // Opcional: lançar exceção ou retornar erro se o estoque for insuficiente
                        throw new InvalidOperationException($"Estoque insuficiente para o produto {stockProduct.Product.Name}");
                    }

                    // Reduzir a quantidade em estoque
                    stockProduct.RemoveStock(totalRequiredQuantity);

                    product.RemoveStock(totalRequiredQuantity);

                    stockProduct.SetUpdatedByUserId(request.CreatedByUserId);
                    product.SetUpdatedByUserId(request.CreatedByUserId);

                    // Atualizar o StockProduct no banco
                    _unitOfWork.StockProducts.UpdateAsync(stockProduct);
                    _unitOfWork.Products.UpdateAsync(product);

                    // Registrar o movimento de estoque
                    var stockMovement = new StockMovement(stockProduct.ProductId, totalRequiredQuantity, MovementTypeEnum.EXIT, request.CreatedByUserId);
                    await _unitOfWork.StockMovements.AddAsync(stockMovement);
                }
            }

            var table = await _unitOfWork.Tables.GetByIdAsync(entity.TableId.Value);

            table.UpdateStatus(Core.Enums.TableStatusEnum.BUSY);
            table.SetUpdatedByUserId(request.CreatedByUserId);

            _unitOfWork.Tables.UpdateAsync(table);
            
            await _unitOfWork.Orders.AddAsync(entity);
            await _unitOfWork.CompleteAsync();
            await _unitOfWork.CommitAsync();
 
            var viewModel = _mapper.Map<OrderViewModel>(entity);

            return Result<OrderViewModel>.Success(viewModel);
        }
    }
}
