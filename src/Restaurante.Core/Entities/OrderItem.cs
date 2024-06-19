using Restaurant.Core.Entities.Base;
using Restaurant.Core.Enums;
using System.Text.Json.Serialization;

namespace Restaurant.Core.Entities
{
    public class OrderItem : Entity
    {
        public OrderItem(int quantity, OrderItemStatusEnum status, Product product, Order order)
        {
            Quantity = quantity;
            Status = status;
            Product = product;
            Order = order;
        }

        public OrderItem()
        {
        }

        public int Quantity { get; set; }

        public OrderItemStatusEnum Status{ get; set; }

        public virtual Product Product { get; set; }
        [JsonIgnore]
        public int ProductId { get; set; }

        [JsonIgnore]
        public virtual Order Order { get; set; }
        [JsonIgnore]
        public int OrderId { get; set; }

        public decimal SubTotal
        {
            get { return Product != null ? Product.Price * Quantity : 0; }
        }
    }
}
