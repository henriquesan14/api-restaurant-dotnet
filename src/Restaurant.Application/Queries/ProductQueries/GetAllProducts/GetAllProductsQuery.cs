using MediatR;
using Restaurant.Application.ViewModels;
using Restaurant.Application.ViewModels.Page;

namespace Restaurant.Application.Queries.ProductQueries.GetAllProducts
{
    public  class GetAllProductsQuery : IRequest<PagedListViewModel<ProductViewModel>>
    {
        public GetAllProductsQuery(PageFilter pageFilter)
        {
            PageFilter = pageFilter;
        }

        public PageFilter PageFilter { get; set; }
    }
}
