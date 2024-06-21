using MediatR;
using Restaurant.Application.ViewModels;
using Restaurant.Core.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurant.Application.Queries.OrderQueries.GetCountOrderToday
{
    public class GetCountOrderTodayQueryHandler : IRequestHandler<GetCountOrderTodayQuery, CountOrderViewModel>
    {
        private readonly IOrderRepository _orderRepository;

        public GetCountOrderTodayQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<CountOrderViewModel> Handle(GetCountOrderTodayQuery request, CancellationToken cancellationToken)
        {
            var today = DateTime.UtcNow.Date;
            var result = await _orderRepository.GetCountOrderToday(today);
            return new CountOrderViewModel { Count = result, Date = today };
        }
    }
}
