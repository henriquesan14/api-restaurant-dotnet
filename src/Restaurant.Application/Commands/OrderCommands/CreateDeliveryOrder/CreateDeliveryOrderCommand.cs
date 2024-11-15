using MediatR;
using Restaurant.Application.InputModels;
using Restaurant.Application.ViewModels;
using Restaurant.Core.Common;
using Restaurant.Core.Request;

namespace Restaurant.Application.Commands.OrderCommands.CreateDeliveryOrder
{
    public class CreateDeliveryOrderCommand : IRequest<Result<OrderViewModel>>, ICreatedByRequest
    {
        public IEnumerable<OrderItemInputModel> Items { get; set; }

        public int ClientId { get; set; }

        public int AddressId { get; set; }

        public int CreatedByUserId { get; set; }
    }
}
