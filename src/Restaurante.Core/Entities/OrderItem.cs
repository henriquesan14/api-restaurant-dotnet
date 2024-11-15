using Restaurant.Core.Entities.Base;
using Restaurant.Core.Enums;
using System.Text.Json.Serialization;

namespace Restaurant.Core.Entities
{
    public class OrderItem : Entity
    {

        public OrderItem()
        {
            
        }

        public OrderItem(int quantity, MenuItem menuItem, string? observation, int createdByUserId)
        {
            Status = OrderItemStatusEnum.PENDING;
            Quantity = quantity;
            MenuItem = menuItem;
            MenuItemId = menuItem.Id;
            Observation = observation;
            CreatedByUserId = createdByUserId;
        }

        public int Quantity { get; private set; }

        public OrderItemStatusEnum Status{ get; private set; }

        public virtual MenuItem MenuItem { get; private set; }
        [JsonIgnore]
        public int MenuItemId { get; set; }

        [JsonIgnore]
        public virtual Order Order { get; private set; }
        [JsonIgnore]
        public int OrderId { get; private set; }

        public string? Observation { get; private set; }

        public decimal SubTotal
        {
            get { return MenuItem != null ? MenuItem.Price * Quantity : 0; }
        }
    }
}
