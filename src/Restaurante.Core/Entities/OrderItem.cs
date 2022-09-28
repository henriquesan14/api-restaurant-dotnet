using Restaurant.Core.Entities.Base;
using Restaurant.Core.Enums;
using System.Text.Json.Serialization;

namespace Restaurant.Core.Entities
{
    public class OrderItem : Entity
    {
        public OrderItem(int quantity, ItemOrderStatus status, Product product, Order order)
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

        public ItemOrderStatus Status{ get; set; }

        public Product Product { get; set; }
        [JsonIgnore]
        public int ProductId { get; set; }

        [JsonIgnore]
        public Order Order { get; set; }
        [JsonIgnore]
        public int OrderId { get; set; }

        public decimal SubTotal
        {
            get { return Product != null ? Product.Price * Quantity : 0; }
        }
    }
}
