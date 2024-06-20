using MediatR;
using Restaurant.Application.ViewModels;
using Restaurant.Application.ViewModels.Page;

namespace Restaurant.Application.Queries.OrderItemQueries.GetAllOrdemItem
{
    public class GetAllOrdemItemQuery : IRequest<PagedListViewModel<OrderItemViewModel>>
    {
        public GetAllOrdemItemQuery(int? status, DateTime? date, int pageNumber, int pageSize)
        {
            Status = status;
            Date = date;
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        public int? Status { get; set; }
        public DateTime? Date { get; set; }

        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }
}
