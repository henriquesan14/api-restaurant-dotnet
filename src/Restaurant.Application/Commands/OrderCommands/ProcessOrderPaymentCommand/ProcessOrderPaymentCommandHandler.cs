using MediatR;
using Restaurant.Core.DTOs;
using Restaurant.Core.Entities;
using Restaurant.Core.Repositories;
using Restaurant.Core.Services;

namespace Restaurant.Application.Commands.OrderCommands.UpdateOrderStatusCommand
{
    public class ProcessOrderPaymentCommandHandler : IRequestHandler<ProcessOrderPaymentCommand, int>
    {
        private readonly IUnitOfWork _uniOfWork;
        private readonly IPaymentService _paymentService;

        public ProcessOrderPaymentCommandHandler(IUnitOfWork uniOfWork, IPaymentService paymentService)
        {
            _uniOfWork = uniOfWork;
            _paymentService = paymentService;
        }

        public async Task<int> Handle(ProcessOrderPaymentCommand request, CancellationToken cancellationToken)
        {
            Order order = await _uniOfWork.Orders.GetOrderById(request.OrderId) ;
            if (order != null)
            {
                order.UpdateStatus(Core.Enums.OrderStatusEnum.PENDING);
                var dto = new PaymentInfoDTO(request.OrderId, request.CreditCardNumber, request.Cvv, request.ExpiresAt, request.FullName, request.Amount) ;
                _paymentService.ProcessPayment(dto);
                _uniOfWork.Orders.UpdateAsync(order);
                await _uniOfWork.CompleteAsync();
                return order.Id;
            }
            return 0;
        }
    }
}
