using Restaurant.Core.Entities.Base;
using Restaurant.Core.Enums;

namespace Restaurant.Core.Entities
{
    public class Payment : Entity
    {
        public Payment(decimal amountReceived, PaymentMethod paymentMethod)
        {
            AmountReceived = amountReceived;
            PaymentMethod = paymentMethod;
        }

        public Payment()
        {
        }

        public decimal AmountReceived { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public Order Order { get; set; }
        public int OrderId { get; set; }
    }
}
