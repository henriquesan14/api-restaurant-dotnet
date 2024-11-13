using AutoMapper;
using Restaurant.Application.Commands.MenuCategoryCommands.CreateMenuCategory;
using Restaurant.Application.ViewModels;
using Restaurant.Core.Entities;

namespace Restaurant.Application.Mappers
{
    public class MenuCategoryMapper : Profile
    {
        public MenuCategoryMapper()
        {
            CreateMap<CreateMenuCategoryCommand, MenuCategory>();
            CreateMap<MenuCategory, MenuCategoryViewModel>();
        }
    }
}
