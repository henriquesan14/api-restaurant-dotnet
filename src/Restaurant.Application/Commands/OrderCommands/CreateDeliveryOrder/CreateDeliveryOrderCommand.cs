using MediatR;
using Restaurant.Application.InputModels;

namespace Restaurant.Application.Commands.OrderCommands.CreateDeliveryOrder
{
    public class CreateDeliveryOrderCommand : IRequest<int>
    {
        public IEnumerable<OrderItemInputModel> Items { get; set; }

        public int ClientId { get; set; }

        public int AddressId { get; set; }
    }
}
