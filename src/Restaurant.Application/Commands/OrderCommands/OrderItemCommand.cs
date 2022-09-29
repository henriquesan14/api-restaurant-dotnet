using Restaurant.Core.Entities;
using System.Text.Json.Serialization;

namespace Restaurant.Application.Commands.OrderCommands
{
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
