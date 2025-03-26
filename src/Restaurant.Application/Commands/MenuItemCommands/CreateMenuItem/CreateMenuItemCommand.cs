using MediatR;
using Restaurant.Application.InputModels;
using Restaurant.Application.ViewModels;
using Restaurant.Core.Common;
using Restaurant.Core.Request;

namespace Restaurant.Application.Commands.MenuItemCommands.CreateMenuItem
{
    public class CreateMenuItemCommand : IRequest<Result<MenuItemViewModel>>, ICreatedByRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }

        public List<MenuItemProductInputModel> NeededProducts { get; set; }

        public int MenuCategoryId { get; set; }
        public int MenuId { get; set; }
        public int CreatedByUserId { get; set; }
    }
}
