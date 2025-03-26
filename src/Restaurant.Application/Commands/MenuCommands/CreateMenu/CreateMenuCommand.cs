using MediatR;
using Restaurant.Application.ViewModels;
using Restaurant.Core.Common;
using Restaurant.Core.Request;

namespace Restaurant.Application.Commands.MenuCommands.CreateMenu
{
    public class CreateMenuCommand : IRequest<Result<MenuViewModel>>, ICreatedByRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int CreatedByUserId { get; set; }
    }
}
