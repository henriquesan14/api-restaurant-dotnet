using MediatR;
using Restaurant.Application.ViewModels;
using Restaurant.Application.ViewModels.Page;
using Restaurant.Core.Common;
using Restaurant.Core.Enums;

namespace Restaurant.Application.Queries.OrderQueries.GetAllOrders
{
    public class GetAllOrdersQuery : IRequest<Result<PagedListViewModel<OrderViewModel>>>
    {
        public OrderTypeEnum OrderType { get; set; }
        public OrderStatusEnum? Status { get; set; }
        public DateTime? Date { get; set; }

        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }
}
