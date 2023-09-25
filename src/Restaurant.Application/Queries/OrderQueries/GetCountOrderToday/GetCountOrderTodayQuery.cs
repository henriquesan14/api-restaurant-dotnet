using MediatR;
using Restaurant.Application.ViewModels;

namespace Restaurant.Application.Queries.OrderQueries.GetCountOrderToday
{
    public class GetCountOrderTodayQuery : IRequest<CountOrderViewModel>
    {
    }
}
