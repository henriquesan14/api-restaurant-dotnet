namespace Restaurant.Core.Entities
{
    public class CommonOrder : Order
    {
        public CommonOrder()
        {
            
        }

        public CommonOrder(int clientId, int tableId, decimal valueTotal, int createdByUserId)
        : base("Common", clientId, valueTotal)
        {
            TableId = tableId;
            CreatedByUserId = createdByUserId;
        }

        public virtual Table Table { get; private set; }
        public int? TableId { get; private set; }

        public virtual User CreatedByUser { get; private set; }
    }
}
