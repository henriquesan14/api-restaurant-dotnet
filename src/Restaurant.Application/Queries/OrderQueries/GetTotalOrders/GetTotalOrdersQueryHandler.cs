using MediatR;
using Restaurant.Application.ViewModels;
using Restaurant.Core.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurant.Application.Queries.OrderQueries.GetTotalOrders
{
    public class GetTotalOrdersQueryHandler : IRequestHandler<GetTotalOrdersQuery, TotalOrderViewModel>
    {
        private readonly IOrderRepository _orderRepository;

        public GetTotalOrdersQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<TotalOrderViewModel> Handle(GetTotalOrdersQuery request, CancellationToken cancellationToken)
        {
            var result = await _orderRepository.GetTotalOrders(request.StartDate, request.EndDate);
            return new TotalOrderViewModel
            {
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                Total = result
            };
        }
    }
}
