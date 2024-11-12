using AutoMapper;
using MediatR;
using Restaurant.Application.Identity;
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
        private readonly AuthenticatedUser _authenticatedUser;
        private readonly IMapper _mapper;

        public CreateCommonOrderCommandHandler(IUnitOfWork unitOfWork, AuthenticatedUser authenticatedUser, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _authenticatedUser = authenticatedUser;
            _mapper = mapper;
        }

        public async Task<Result<OrderViewModel>> Handle(CreateCommonOrderCommand request, CancellationToken cancellationToken)
        {
            int result = 0;
            // TODO: implementar lógica de autorização
            var entity = new CommonOrder();
            entity.TableId = request.TableId;
            entity.ClientId = request.ClientId;
            decimal valueTotal = 0; 
            entity.Status = Core.Enums.OrderStatusEnum.CREATED;
            entity.Type = "Common";
            entity.CreatedByUserId = _authenticatedUser.Id;

            await _unitOfWork.BeginTransaction();

            var orderItems = new List<OrderItem>();
            foreach (var item in request.Items)
            {
                var orderItem = new OrderItem();
                var menuItem = await _unitOfWork.MenuItems.GetMenuItemIncludeItemsByIdAsync(item.MenuItemId!.Value);

                orderItem.MenuItem = menuItem;
                orderItem.Quantity = item.Quantity!.Value;
                orderItem.Status = Core.Enums.OrderItemStatusEnum.PENDING;
                orderItem.Observation = "teste";
                orderItem.CreatedAt = DateTime.Now;
                orderItem.CreatedByUserId = _authenticatedUser.Id;

                orderItems.Add(orderItem);
                valueTotal += menuItem.Price * item.Quantity!.Value;

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
                    stockProduct.QuantityInStock -= totalRequiredQuantity;

                    product.QuantityInStock -= totalRequiredQuantity;

                    // Atualizar o StockProduct no banco
                    _unitOfWork.StockProducts.UpdateAsync(stockProduct);
                    _unitOfWork.Products.UpdateAsync(product);

                    // Registrar o movimento de estoque
                    var stockMovement = new StockMovement
                    {
                        ProductId = stockProduct.ProductId,
                        Quantity = neededProduct.QuantityRequired * item.Quantity.Value,
                        MovementDate = DateTime.Now,
                        MovementType = MovementTypeEnum.EXIT,
                        CreatedByUserId = _authenticatedUser.Id
                    };
                    await _unitOfWork.StockMovements.AddAsync(stockMovement);
                }
            }
            
            entity.ValueTotal = valueTotal;
            entity.Items = orderItems;

            var table = await _unitOfWork.Tables.GetByIdAsync(entity.TableId.Value);
            table.Status = Core.Enums.TableStatusEnum.BUSY;
            _unitOfWork.Tables.UpdateAsync(table);
            try
            {

                await _unitOfWork.Orders.AddAsync(entity);
                await _unitOfWork.CompleteAsync();
                await _unitOfWork.CommitAsync();
 
            }
            catch (Exception ex)
            {

            }

            var viewModel = _mapper.Map<OrderViewModel>(entity);

            return Result<OrderViewModel>.Success(viewModel);
        }
    }
}
