using Restaurant.Core.Entities.Base;
using System.Text.Json.Serialization;

namespace Restaurant.Core.Entities
{
    public class MenuItemProduct : Entity
    {
        public MenuItemProduct()
        {
            
        }

        public MenuItemProduct(int menuItemId, int productId, decimal quantityRequired)
        {
            MenuItemId = menuItemId;
            ProductId = productId;
            QuantityRequired = quantityRequired;
        }

        public int MenuItemId { get; private set; }
        [JsonIgnore]
        public MenuItem MenuItem { get; private set; }

        public int ProductId { get; private set; }
        public Product Product { get; private set; }

        public decimal QuantityRequired { get; private set; }
    }
}
