using Restaurant.Core.Entities.Base;
using Restaurant.Core.Enums;

namespace Restaurant.Core.Entities
{
    public class Order : Entity
    {
        public Order()
        {
        }

        public Order(string type, OrderStatusEnum status, User client, int? clientId, IEnumerable<OrderItem> items, decimal valueTotal)
        {
            Type = type;
            Status = status;
            Client = client;
            ClientId = clientId;
            Items = items;
            ValueTotal = valueTotal;
        }

        public string Type { get; set; }
        public OrderStatusEnum Status { get; set; }
        public virtual User Client { get; set; }
        public int? ClientId { get; set; }
        public virtual IEnumerable<OrderItem> Items { get; set; }
        public decimal ValueTotal { get; set; }
    }
}
