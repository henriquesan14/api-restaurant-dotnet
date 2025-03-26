using MediatR;
using Restaurant.Application.ViewModels;
using Restaurant.Core.Common;

namespace Restaurant.Application.Queries.MenuQueries.GetAllMenus
{
    public class GetAllMenusQuery : IRequest<Result<List<MenuViewModel>>>
    {
        public string? Name { get; set; }
    }
}
