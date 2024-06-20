using MediatR;
using Restaurant.Application.ViewModels;
using Restaurant.Application.ViewModels.Page;

namespace Restaurant.Application.Queries.OrderQueries.GetAllOrdersByClient
{
    public class GetOrdersByClientQuery : IRequest<PagedListViewModel<OrderViewModel>>
    {
        public GetOrdersByClientQuery(int pageNumber, int pageSize, int clientId)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            ClientId = clientId;
        }

        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
        public int ClientId { get; set; }
    }
}
