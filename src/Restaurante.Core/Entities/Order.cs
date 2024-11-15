using Restaurant.Core.Entities.Base;
using Restaurant.Core.Enums;

namespace Restaurant.Core.Entities
{
    public class Order : Entity
    {
        private readonly List<OrderItem> _items = new List<OrderItem>();

        protected Order()
        {
            
        }

        protected Order(string type, int? clientId, decimal valueTotal)
        {
            Type = type;
            Status = OrderStatusEnum.CREATED;
            ClientId = clientId;
            ValueTotal = valueTotal;
            _items = new List<OrderItem>();
        }

        public string Type { get; private set; }
        public OrderStatusEnum Status { get; private set; }
        public virtual User Client { get; private set; }
        public int? ClientId { get; private set; }
        public IReadOnlyCollection<OrderItem> Items => _items.AsReadOnly();
        public decimal ValueTotal { get; private set; }

        public void AddItem(OrderItem item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            _items.Add(item);
            RecalculateTotalValue();
        }

        public void RemoveItem(OrderItem item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            _items.Remove(item);
            RecalculateTotalValue();
        }

        public void UpdateStatus(OrderStatusEnum newStatus)
        {
            Status = newStatus;
        }

        private void RecalculateTotalValue()
        {
            ValueTotal = _items.Sum(item => item.SubTotal);
        }

    }
}
