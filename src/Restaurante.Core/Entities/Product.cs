using Restaurant.Core.Entities.Base;
using System.Text.Json.Serialization;

namespace Restaurant.Core.Entities
{
    public class Product : Entity
    {
        

        public Product()
        {
        }

        public Product(string name, string description, ProductCategory category, int categoryId)
        {
            Name = name;
            Description = description;
            Category = category;
            CategoryId = categoryId;
        }

        public string Name { get; set; }

        public string Description { get; set; }


        public virtual ProductCategory Category { get; set; }
        public int CategoryId { get; set; }

        public decimal QuantityInStock { get; set; }

        public string UnitOfMeasure { get; set; }

        // Relacionamento com estoque
        public StockProduct StockProduct { get; set; }

        [JsonIgnore]
        public ICollection<MenuItemProduct> MenuItemProducts { get; set; } = new List<MenuItemProduct>();

        [JsonIgnore]
        public ICollection<StockMovement> StockMovements { get; set; } = new List<StockMovement>();

    }
}
