using Restaurant.Core.Enums;

namespace Restaurant.Core.Entities
{
    public class DeliveryOrder : Order
    {
        public DeliveryOrder()
        {
            
        }

        public DeliveryOrder(int clientId,int addressId, decimal valueTotal, int createdByUserId)
        : base("Delivery", clientId, valueTotal)
        {
            AddressId = addressId;
            DeliveryStatus = DeliveryStatusEnum.PENDING; // Status inicial de entrega
            CreatedByUserId = createdByUserId;
        }

        public virtual Address Address { get; private set; }
        public int AddressId { get; private set; }

        public DeliveryStatusEnum DeliveryStatus { get; private set; }

    }
}
