using MediatR;
using Restaurant.Application.ViewModels;
using Restaurant.Application.ViewModels.Page;
using Restaurant.Core.Enums;

namespace Restaurant.Application.Queries.CategoryQueries.GetByCategoryType
{
    public class GetAllCategoriesQuery : IRequest<PagedListViewModel<CategoryViewModel>>
    {
        public CategoryType? CategoryType { get; set; }
        public string Name { get; set; }
        public PageFilter PageFilter { get; set; }

        public GetAllCategoriesQuery(PageFilter pageFilter, CategoryType? categoryType, string name)
        {
            PageFilter = pageFilter;
            CategoryType = categoryType;
            Name = name;
        }
    }
}
