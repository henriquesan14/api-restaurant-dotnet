using Restaurant.Core.Entities.Base;
using Restaurant.Core.Enums;

namespace Restaurant.Core.Entities
{
    public class StockProduct : Entity
    {
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public decimal QuantityInStock { get; set; }

        public List<StockMovement> StockMovements { get; set; } = new List<StockMovement>();

        public void AdjustStock(decimal quantity, MovementTypeEnum movementType)
        {
            // Atualiza a quantidade de estoque com base no tipo de movimento (entrada ou saída)
            QuantityInStock += movementType == MovementTypeEnum.ENTRY ? quantity : -quantity;

            // Adiciona o registro de movimentação ao histórico
            StockMovements.Add(new StockMovement
            {
                ProductId = ProductId,
                Quantity = quantity,
                MovementType = movementType
            });
        }
    }
}
