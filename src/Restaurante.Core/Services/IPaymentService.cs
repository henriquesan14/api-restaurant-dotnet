using Restaurant.Core.DTOs;
using System.Threading.Tasks;

namespace Restaurant.Core.Services
{
    public interface IPaymentService
    {
        void ProcessPayment(PaymentInfoDTO paymentInfoDto);
    }
}
