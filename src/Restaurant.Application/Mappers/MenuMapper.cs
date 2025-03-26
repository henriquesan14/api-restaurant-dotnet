using AutoMapper;
using Restaurant.Application.Commands.MenuCommands.CreateMenu;
using Restaurant.Application.ViewModels;
using Restaurant.Core.Entities;

namespace Restaurant.Application.Mappers
{
    public class MenuMapper : Profile
    {
        public MenuMapper()
        {
            CreateMap<CreateMenuCommand, Menu>();
            CreateMap<Menu, MenuViewModel>();
        }
    }
}
