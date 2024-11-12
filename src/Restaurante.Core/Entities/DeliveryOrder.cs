using Restaurant.Core.Enums;

namespace Restaurant.Core.Entities
{
    public class DeliveryOrder : Order
    {
        public virtual Address Address { get; set; }
        public int AddressId { get; set; }

        public DeliveryStatusEnum DeliveryStatus { get; set; }
    }
}
