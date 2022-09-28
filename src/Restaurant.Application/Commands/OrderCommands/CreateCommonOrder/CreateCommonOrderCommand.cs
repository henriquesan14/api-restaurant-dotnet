using MediatR;
using Restaurant.Core.Entities;
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

    public class OrderItemCommand
    {
        public int Quantity { get; set; }

        [JsonIgnore]
        public Product Product { get; set; }
        public int ProductId { get; set; }

        [JsonIgnore]
        public Order Order { get; set; }
    }
}
