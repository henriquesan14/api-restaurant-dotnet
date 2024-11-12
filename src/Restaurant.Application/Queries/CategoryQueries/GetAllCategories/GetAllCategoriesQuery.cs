using MediatR;
using Restaurant.Application.ViewModels;
using Restaurant.Application.ViewModels.Page;

namespace Restaurant.Application.Queries.CategoryQueries.GetByCategoryType
{
    public class GetAllCategoriesQuery : IRequest<PagedListViewModel<CategoryViewModel>>
    {
        public GetAllCategoriesQuery(string name, int pageNumber, int pageSize)
        {
            Name = name;
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        public string? Name { get; set; }

        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }
}
