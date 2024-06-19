using MediatR;
using Restaurant.Core.Enums;

namespace Restaurant.Application.Commands.OrderCommands.UpdateOrderItemCommand
{
    public class UpdateOrderItemCommand : IRequest<int>
    {
        public OrderItemStatusEnum Status { get; set; }
        public int OrderItemId { get; set; }
    }
}
