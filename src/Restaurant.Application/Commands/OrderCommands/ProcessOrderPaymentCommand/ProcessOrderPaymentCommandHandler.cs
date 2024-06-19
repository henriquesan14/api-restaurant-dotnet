using MediatR;
using Restaurant.Core.DTOs;
using Restaurant.Core.Entities;
using Restaurant.Core.Repositories;
using Restaurant.Core.Services;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurant.Application.Commands.OrderCommands.UpdateOrderStatusCommand
{
    public class ProcessOrderPaymentCommandHandler : IRequestHandler<ProcessOrderPaymentCommand, int>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IPaymentService _paymentService;

        public ProcessOrderPaymentCommandHandler(IOrderRepository orderRepository, IPaymentService paymentService)
        {
            _orderRepository = orderRepository;
            _paymentService = paymentService;
        }

        public async Task<int> Handle(ProcessOrderPaymentCommand request, CancellationToken cancellationToken)
        {
            Order order = await _orderRepository.GetOrderById(request.OrderId) ;
            if (order != null)
            {
                order.Status = Core.Enums.OrderStatusEnum.PENDING;
                var dto = new PaymentInfoDTO(request.OrderId, request.CreditCardNumber, request.Cvv, request.ExpiresAt, request.FullName, request.Amount) ;
                _paymentService.ProcessPayment(dto);
                await _orderRepository.UpdateAsync(order);
                return order.Id;
            }
            return 0;
        }
    }
}
