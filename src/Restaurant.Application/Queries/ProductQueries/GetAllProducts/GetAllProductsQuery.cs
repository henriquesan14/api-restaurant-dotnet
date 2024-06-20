using MediatR;
using Restaurant.Application.ViewModels;
using Restaurant.Application.ViewModels.Page;

namespace Restaurant.Application.Queries.ProductQueries.GetAllProducts
{
    public  class GetAllProductsQuery : IRequest<PagedListViewModel<ProductViewModel>>
    {
        public GetAllProductsQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }
}
