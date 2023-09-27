using MediatR;
using Restaurant.Core.Enums;

namespace Restaurant.Application.Commands.OrderCommands.UpdateOrderStatusCommand
{
    public class UpdateOrderStatusCommand : IRequest<int>
    {
        public int Id { get; set; }
        public OrderStatus Status { get; set; }
    }
}
