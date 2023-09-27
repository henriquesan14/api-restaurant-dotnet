using MediatR;
using Restaurant.Application.ViewModels;
using Restaurant.Application.ViewModels.Page;

namespace Restaurant.Application.Queries.OrderQueries.GetAllOrdersByClient
{
    public class GetOrdersByClientQuery : IRequest<PagedListViewModel<OrderViewModel>>
    {
        public GetOrdersByClientQuery(PageFilter pageFilter, int clientId)
        {
            PageFilter = pageFilter;
            ClientId = clientId;
        }

        public PageFilter PageFilter { get; set; }
        public int ClientId { get; set; }
    }
}
