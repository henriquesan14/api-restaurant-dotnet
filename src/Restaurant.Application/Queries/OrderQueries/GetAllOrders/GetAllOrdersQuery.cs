using MediatR;
using Restaurant.Application.ViewModels;
using Restaurant.Application.ViewModels.Page;

namespace Restaurant.Application.Queries.OrderQueries.GetAllOrders
{
    public class GetAllOrdersQuery : IRequest<PagedListViewModel<OrderViewModel>>
    {
        public GetAllOrdersQuery(PageFilter pageFilter)
        {
            PageFilter = pageFilter;
        }

        public PageFilter PageFilter { get; set; }
    }
}
