using MediatR;
using Restaurant.Core.Entities;
using Restaurant.Core.Repositories;

namespace Restaurant.Application.Commands.OrderCommands.CreateCommonOrder
{
    public class CreateCommonOrderCommandHandler : IRequestHandler<CreateCommonOrderCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateCommonOrderCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateCommonOrderCommand request, CancellationToken cancellationToken)
        {
            // TODO: implementar lógica de autorização
            var entity = new CommonOrder();
            entity.TableId = request.TableId;
            entity.ClientId = request.ClientId;
            decimal valueTotal = 0; 
            entity.Status = Core.Enums.OrderStatusEnum.CREATED;
            entity.EmployeeId = request.EmployeeId;
            entity.Type = "Common";

            await _unitOfWork.BeginTransaction();

            var orderItems = new List<OrderItem>();
            foreach (var item in request.Items)
            {
                var orderItem = new OrderItem();
                var product = await _unitOfWork.Products.GetByIdAsync(item.ProductId!.Value);

                orderItem.Product = product;
                orderItem.Quantity = item.Quantity!.Value;
                orderItem.Status = Core.Enums.OrderItemStatusEnum.PENDING;
                orderItem.CreatedAt = DateTime.UtcNow;

                orderItems.Add(orderItem);
                valueTotal += product.Price * item.Quantity!.Value;
            }
            
            entity.ValueTotal = valueTotal;
            entity.Items = orderItems;

            var table = await _unitOfWork.Tables.GetByIdAsync(entity.TableId.Value);
            table.Status = Core.Enums.TableStatusEnum.BUSY;
            _unitOfWork.Tables.UpdateAsync(table);
            await _unitOfWork.CompleteAsync();

            var result = await _unitOfWork.Orders.AddAsync(entity);
            
            await _unitOfWork.CompleteAsync();

            await _unitOfWork.CommitAsync();
            
            return result.Id;
        }
    }
}
