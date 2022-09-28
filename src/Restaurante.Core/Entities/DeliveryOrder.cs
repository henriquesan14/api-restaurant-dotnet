namespace Restaurant.Core.Entities
{
    public class DeliveryOrder : Order
    {
        public Address Address { get; set; }
        public int AddressId { get; set; }
    }
}
