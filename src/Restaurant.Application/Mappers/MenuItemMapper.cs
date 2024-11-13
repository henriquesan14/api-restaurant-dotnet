using AutoMapper;
using Restaurant.Application.Commands.MenuItemCommands.CreateMenuItem;
using Restaurant.Application.InputModels;
using Restaurant.Application.ViewModels;
using Restaurant.Core.Entities;

namespace Restaurant.Application.Mappers
{
    public class MenuItemMapper : Profile
    {
        public MenuItemMapper()
        {
            CreateMap<MenuItemProductInputModel, MenuItemProduct>();

            CreateMap<CreateMenuItemCommand, MenuItem>()
               .ForMember(dest => dest.NeededProducts, opt => opt.MapFrom(src => src.NeededProducts));

            CreateMap<MenuItem, MenuItemViewModel>();
            
        }
    }
}
