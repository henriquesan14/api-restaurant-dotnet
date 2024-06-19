using MediatR;
using Restaurant.Application.ViewModels;
using Restaurant.Application.ViewModels.Page;
using Restaurant.Core.Enums;
using System;

namespace Restaurant.Application.Queries.OrderQueries.GetAllOrders
{
    public class GetAllOrdersQuery : IRequest<PagedListViewModel<OrderViewModel>>
    {
        public GetAllOrdersQuery(PageFilter pageFilter, OrderTypeEnum orderType, int? status, DateTime? date)
        {
            PageFilter = pageFilter;
            OrderType = orderType;
            Status = status;
            Date = date;
        }

        public PageFilter PageFilter { get; set; }
        public OrderTypeEnum OrderType { get; set; }
        public int? Status { get; set; }
        public DateTime? Date { get; set; }
    }
}
