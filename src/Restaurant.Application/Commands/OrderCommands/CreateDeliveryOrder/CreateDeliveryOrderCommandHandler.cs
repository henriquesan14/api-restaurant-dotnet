using MediatR;
using Restaurant.Core.Entities;
using Restaurant.Core.Repositories;

namespace Restaurant.Application.Commands.OrderCommands.CreateDeliveryOrder
{
    public class CreateDeliveryOrderCommandHandler : IRequestHandler<CreateDeliveryOrderCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateDeliveryOrderCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateDeliveryOrderCommand request, CancellationToken cancellationToken)
        {
            var entity = new DeliveryOrder();
            entity.AddressId = request.AddressId;
            entity.ClientId = request.ClientId;
            decimal valueTotal = 0;
            entity.Status = Core.Enums.OrderStatusEnum.CREATED;
            entity.Type = "Delivery";

            await _unitOfWork.BeginTransaction();

            var orderItems = new List<OrderItem>();
            foreach (var item in request.Items)
            {
                var orderItem = new OrderItem();
                var product = await _unitOfWork.Products.GetByIdAsync(item.MenuItemId!.Value);

                
                orderItem.Quantity = item.Quantity!.Value;
                orderItem.Status = Core.Enums.OrderItemStatusEnum.PENDING;
                orderItem.CreatedAt = DateTime.Now;

                orderItems.Add(orderItem);
                //valueTotal += product.Price * item.Quantity!.Value;
            }

            entity.ValueTotal = valueTotal;
            entity.Items = orderItems;

            var result = await _unitOfWork.Orders.AddAsync(entity);

            await _unitOfWork.CompleteAsync();

            await _unitOfWork.CommitAsync();

            return result.Id;
        }
    }
}
