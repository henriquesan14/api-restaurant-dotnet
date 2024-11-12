using MediatR;
using Restaurant.Application.ViewModels;
using Restaurant.Core.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurant.Application.Queries.OrderItemQueries.GetCountOrderItemToday
{
    public class GetCountOrderItemTodayQueryHandler : IRequestHandler<GetCountOrderItemTodayQuery, CountOrderItemViewModel>
    {
        private readonly IOrderItemRepository _orderItemRepository;

        public GetCountOrderItemTodayQueryHandler(IOrderItemRepository orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
        }

        public async Task<CountOrderItemViewModel> Handle(GetCountOrderItemTodayQuery request, CancellationToken cancellationToken)
        {
            var today = DateTime.Now.Date;
            var count = await _orderItemRepository.GetCountOrderItemsToday(today);
            return new CountOrderItemViewModel { Date = today, Count = count };
        }
    }
}
