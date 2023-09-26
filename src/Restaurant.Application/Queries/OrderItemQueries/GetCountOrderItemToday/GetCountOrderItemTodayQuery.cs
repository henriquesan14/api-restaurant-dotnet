using MediatR;
using Restaurant.Application.ViewModels;

namespace Restaurant.Application.Queries.OrderItemQueries.GetCountOrderItemToday
{
    public class GetCountOrderItemTodayQuery : IRequest<CountOrderItemViewModel>
    {
    }
}
