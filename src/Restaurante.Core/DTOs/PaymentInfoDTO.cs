namespace Restaurant.Core.DTOs
{
    public class PaymentInfoDTO
    {
        public PaymentInfoDTO(int orderId, string creditCardNumber, string cvv, string expiresAt, string fullName, decimal amount)
        {
            OrderId = orderId;
            CreditCardNumber = creditCardNumber;
            Cvv = cvv;
            ExpiresAt = expiresAt;
            FullName = fullName;
            Amount = amount;
        }

        public int OrderId { get; set; }
        public string CreditCardNumber { get; set; }
        public string Cvv { get; set; }
        public string ExpiresAt { get; set; }
        public string FullName { get; set; }
        public decimal Amount { get; set; }
    }
}
