using Restaurant.Core.Entities.Base;
using Restaurant.Core.Enums;

namespace Restaurant.Core.Entities
{
    public class StockMovement : Entity
    {
        public int ProductId { get; set; } // Estoque do produto
        public Product Product { get; set; }
        public decimal Quantity { get; set; }
        public MovementTypeEnum MovementType { get; set; }
        public DateTime MovementDate { get; set; }

        public int StockProductId { get; set; }
        public StockProduct StockProduct { get; set; }  // Propriedade de navegação
    }
}
