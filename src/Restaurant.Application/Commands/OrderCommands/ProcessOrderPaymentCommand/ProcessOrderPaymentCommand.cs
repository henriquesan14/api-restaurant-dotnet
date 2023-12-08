using MediatR;

namespace Restaurant.Application.Commands.OrderCommands.UpdateOrderStatusCommand
{
    public class ProcessOrderPaymentCommand : IRequest<int>
    {
        public int OrderId { get; set; }
        public string CreditCardNumber { get; set; }
        public string Cvv { get; set; }
        public string ExpiresAt { get; set; }
        public string FullName { get; set; }
        public decimal Amount { get; set; }
    }
}
