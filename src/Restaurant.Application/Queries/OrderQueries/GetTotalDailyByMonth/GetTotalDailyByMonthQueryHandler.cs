using AutoMapper;
using MediatR;
using Restaurant.Application.ViewModels;
using Restaurant.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurant.Application.Queries.OrderQueries.GetTotalDailyByMonth
{
    public class GetTotalDailyByMonthQueryHandler : IRequestHandler<GetTotalDailyByMonthQuery, List<StatisticOrderViewModel>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetTotalDailyByMonthQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<List<StatisticOrderViewModel>> Handle(GetTotalDailyByMonthQuery request, CancellationToken cancellationToken)
        {
            int month = request.Month ?? DateTime.Now.Month;
            var result = await _orderRepository.GetTotalDailyByMonth(month);
            return _mapper.Map<List<StatisticOrderViewModel>>(result);
        }
    }
}
