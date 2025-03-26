using Restaurant.Core.Entities.Base;
using Restaurant.Core.Events;
using System.Text.Json.Serialization;

namespace Restaurant.Core.Entities
{
    public class Product : Entity
    {
        public Product()
        {
        }

        public Product(string name, string description, ProductCategory category, int categoryId, decimal minimumStock)
        {
            Name = name;
            Description = description;
            Category = category;
            CategoryId = categoryId;
        }

        public string Name { get; private set; }

        public string Description { get; private set; }


        public virtual ProductCategory Category { get; private set; }
        public int CategoryId { get; private set; }

        public decimal QuantityInStock { get; private set; }

        public string UnitOfMeasure { get; private set; }

        public decimal MinimumStock { get; set; }

        // Relacionamento com estoque
        public StockProduct StockProduct { get; private set; }

        [JsonIgnore]
        public ICollection<MenuItemProduct> MenuItemProducts { get; private set; }

        [JsonIgnore]
        public ICollection<StockMovement> StockMovements { get; private set; }

        public void AddStock(decimal quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("A quantidade deve ser maior que zero.", nameof(quantity));

            QuantityInStock += quantity;
        }

        // Método para diminuir estoque
        public void RemoveStock(decimal quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("A quantidade deve ser maior que zero.", nameof(quantity));

            if (quantity > QuantityInStock)
                throw new InvalidOperationException("Quantidade insuficiente em estoque.");

            QuantityInStock -= quantity;

            //if (QuantityInStock <= MinimumStock)
            //{
            //    AddDomainEvent(new LowStockEvent(Id, Name, QuantityInStock));
            //}

        }

    }
}
