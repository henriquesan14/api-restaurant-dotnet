using Restaurant.Core.Entities.Base;
using Restaurant.Core.Enums;

namespace Restaurant.Core.Entities
{
    public class StockMovement : Entity
    {
        public StockMovement()
        {
            
        }

        public StockMovement(int productId, decimal quantity, MovementTypeEnum movementType, int createdByUserId)
        {
            ProductId = productId;
            Quantity = quantity;
            MovementDate = DateTime.Now;
            MovementType = movementType;
            CreatedByUserId = CreatedByUserId;
        }

        public int ProductId { get; private set; } // Estoque do produto
        public Product Product { get; private set; }
        public decimal Quantity { get; private set; }
        public MovementTypeEnum MovementType { get; private set; }
        public DateTime MovementDate { get; private set; }

        public int StockProductId { get; private set; }
        public StockProduct StockProduct { get; private set; }  // Propriedade de navegação
    }
}
