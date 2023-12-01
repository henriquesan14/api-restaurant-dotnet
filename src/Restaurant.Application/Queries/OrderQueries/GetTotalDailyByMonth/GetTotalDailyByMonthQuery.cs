using MediatR;
using Restaurant.Application.ViewModels;
using System.Collections.Generic;

namespace Restaurant.Application.Queries.OrderQueries.GetTotalDailyByMonth
{
    public class GetTotalDailyByMonthQuery : IRequest<List<StatisticOrderViewModel>>
    {
        public int? Month { get; set; }

        public GetTotalDailyByMonthQuery(int? month)
        {
            Month = month;
        }
    }
}
