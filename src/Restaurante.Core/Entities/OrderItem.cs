using Restaurant.Core.Entities.Base;
using Restaurant.Core.Enums;
using System.Text.Json.Serialization;

namespace Restaurant.Core.Entities
{
    public class OrderItem : Entity
    {
        public OrderItem(int quantity, OrderItemStatusEnum status, MenuItem product, Order order)
        {
            Quantity = quantity;
            Status = status;
            MenuItem = product;
            Order = order;
        }

        public OrderItem()
        {
        }

        public int Quantity { get; set; }

        public OrderItemStatusEnum Status{ get; set; }

        public virtual MenuItem MenuItem { get; set; }
        [JsonIgnore]
        public int MenuItemId { get; set; }

        [JsonIgnore]
        public virtual Order Order { get; set; }
        [JsonIgnore]
        public int OrderId { get; set; }

        public string? Observation { get; set; }

        public decimal SubTotal
        {
            get { return MenuItem != null ? MenuItem.Price * Quantity : 0; }
        }
    }
}
