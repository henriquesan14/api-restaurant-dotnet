using Restaurant.Core.Entities.Base;

namespace Restaurant.Core.Entities
{
    public class StockProduct : Entity
    {

        public StockProduct()
        {
            
        }

        public StockProduct(int productId, decimal quantityInStock, decimal minimumStock)
        {
            ProductId = productId;
            QuantityInStock = quantityInStock;
            MinimumStock = minimumStock;
        }

        public Product Product { get; private set; }
        public int ProductId { get; private set; }
        public decimal QuantityInStock { get; private set; }

        public decimal MinimumStock { get; private set; }

        public List<StockMovement> StockMovements { get; private set; }

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

        }

    }
}
