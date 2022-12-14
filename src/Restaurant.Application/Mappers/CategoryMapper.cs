using AutoMapper;
using Restaurant.Application.Commands.CategoryCommands.CreateCategory;
using Restaurant.Core.Entities;

namespace Restaurant.Application.Mappers
{
    public class CategoryMapper : Profile
    {
        public CategoryMapper()
        {
            CreateMap<CreateCategoryCommand, Category>().ReverseMap();
        }
    }
}
