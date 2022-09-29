using MediatR;
using System.Collections.Generic;

namespace Restaurant.Application.Commands.OrderCommands.CreateDeliveryOrder
{
    public class CreateDeliveryOrderCommand : IRequest<int>
    {
        public IEnumerable<OrderItemCommand> Items { get; set; }

        public int ClientId { get; set; }

        public int AddressId { get; set; }
    }
}
