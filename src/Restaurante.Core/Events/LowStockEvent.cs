using Restaurant.Core.Common;

namespace Restaurant.Core.Events
{
    public class LowStockEvent : IDomainEvent
    {
        public int ProductId { get; }
        public string ProductName { get; set; }
        public decimal CurrentStock { get; set; }
        public DateTime OccurredOn { get; } = DateTime.UtcNow;

        public LowStockEvent(int productId, string productName, decimal currentStock)
        {
            ProductId = productId;
            ProductName = productName;
            CurrentStock = currentStock;
        }
    }
}
