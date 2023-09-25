using MediatR;
using Restaurant.Application.ViewModels;
using Restaurant.Application.ViewModels.Page;
using Restaurant.Core.Enums;

namespace Restaurant.Application.Queries.OrderQueries.GetAllOrders
{
    public class GetAllOrdersQuery : IRequest<PagedListViewModel<OrderViewModel>>
    {
        public GetAllOrdersQuery(PageFilter pageFilter, OrderType orderType, int? status)
        {
            PageFilter = pageFilter;
            OrderType = orderType;
            Status = status;
        }

        public PageFilter PageFilter { get; set; }
        public OrderType OrderType { get; set; }
        public int? Status { get; set; }
    }
}
