using Restaurant.Core.DTOs;
using Restaurant.Core.Services;

namespace Restaurant.Infra.Services
{
    public class PaymentService : IPaymentService
    {

        private readonly IMessageBusService _messageBusService;
        private const string QUEUE_NAME = "Payments";

        public PaymentService(IMessageBusService messageBusService)
        {
            _messageBusService = messageBusService;
        }
        public void ProcessPayment(PaymentInfoDTO paymentInfoDto)
        {
            _messageBusService.Publish(QUEUE_NAME, paymentInfoDto);
        }
    }
}
