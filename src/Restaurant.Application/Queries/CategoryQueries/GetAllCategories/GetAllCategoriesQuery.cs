using MediatR;
using Restaurant.Application.ViewModels;
using Restaurant.Application.ViewModels.Page;
using Restaurant.Core.Enums;

namespace Restaurant.Application.Queries.CategoryQueries.GetByCategoryType
{
    public class GetAllCategoriesQuery : IRequest<PagedListViewModel<CategoryViewModel>>
    {
        public GetAllCategoriesQuery(CategoryTypeEnum? categoryType, string name, int pageNumber, int pageSize)
        {
            CategoryType = categoryType;
            Name = name;
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        public CategoryTypeEnum? CategoryType { get; set; }
        public string? Name { get; set; }

        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }
}
