using Restaurant.Core.Entities.Base;
using System.Text.Json.Serialization;

namespace Restaurant.Core.Entities
{
    public class MenuItemProduct : Entity
    {
        public int MenuItemId { get; set; }
        [JsonIgnore]
        public MenuItem MenuItem { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public decimal QuantityRequired { get; set; }
    }
}
