using MediatR;
using Restaurant.Application.ViewModels.Page;
using Restaurant.Application.ViewModels;
using System;

namespace Restaurant.Application.Queries.OrderItemQueries.GetAllOrdemItem
{
    public class GetAllOrdemItemQuery : IRequest<PagedListViewModel<OrderItemViewModel>>
    {
        public GetAllOrdemItemQuery(PageFilter pageFilter, int? status, DateTime? date)
        {
            PageFilter = pageFilter;
            Status = status;
            Date = date;
        }

        public PageFilter PageFilter { get; set; }
        public int? Status { get; set; }
        public DateTime? Date { get; set; }
    }
}
