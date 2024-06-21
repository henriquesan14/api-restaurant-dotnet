using MediatR;
using Restaurant.Application.InputModels;
using System.Text.Json.Serialization;

namespace Restaurant.Application.Commands.OrderCommands.CreateCommonOrder
{
    public class CreateCommonOrderCommand : IRequest<int>
    {
        

        public CreateCommonOrderCommand()
        {
            
        }

        public CreateCommonOrderCommand(IEnumerable<OrderItemInputModel> items, int tableId, int clientId, int employeeId)
        {
            Items = items;
            TableId = tableId;
            ClientId = clientId;
            EmployeeId = employeeId;
        }

        public IEnumerable<OrderItemInputModel> Items { get; set; }

        public int TableId { get; set; }
        public int ClientId { get; set; }

        [JsonIgnore]
        public int EmployeeId { get; set; }

    }
}
