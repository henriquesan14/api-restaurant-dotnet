using MediatR;
using Restaurant.Application.InputModels;
using Restaurant.Application.ViewModels;
using Restaurant.Core.Common;
using Restaurant.Core.Request;

namespace Restaurant.Application.Commands.OrderCommands.CreateCommonOrder
{
    public class CreateCommonOrderCommand : IRequest<Result<OrderViewModel>>, ICreatedByRequest
    {
        

        public CreateCommonOrderCommand()
        {
            
        }

        public CreateCommonOrderCommand(IEnumerable<OrderItemInputModel> items, int tableId, int clientId)
        {
            Items = items;
            TableId = tableId;
            ClientId = clientId;
        }

        public IEnumerable<OrderItemInputModel> Items { get; set; }

        public int TableId { get; set; }
        public int ClientId { get; set; }

        public int CreatedByUserId { get; set; }

    }
}
