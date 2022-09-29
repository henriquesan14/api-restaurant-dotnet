using MediatR;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Restaurant.Application.Commands.OrderCommands.CreateCommonOrder
{
    public class CreateCommonOrderCommand : IRequest<int>
    {
        public IEnumerable<OrderItemCommand> Items { get; set; }

        public int TableId { get; set; }
        public int ClientId { get; set; }

        [JsonIgnore]
        public int EmployeeId { get; set; }

    }
}
