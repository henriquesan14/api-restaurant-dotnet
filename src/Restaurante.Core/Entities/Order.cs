using Restaurant.Core.Entities.Base;
using Restaurant.Core.Enums;

namespace Restaurant.Core.Entities
{
    public class Order : Entity
    {
        public Order(OrderStatus status, User client, IEnumerable<OrderItem> items)
        {
            Status = status;
            Client = client;
            Items = items;
        }

        public Order()
        {
        }

        public string Type { get; set; }
        public OrderStatus Status { get; set; }
        public User Client { get; set; }
        public int ClientId { get; set; }
        public IEnumerable<OrderItem> Items { get; set; }
        public decimal ValueTotal { get; set; }
    }
}
