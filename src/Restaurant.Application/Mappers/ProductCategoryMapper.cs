using AutoMapper;
using Restaurant.Application.Commands.ProductCategoryCommands.CreateCategory;
using Restaurant.Application.Commands.ProductCategoryCommands.UpdateCategory;
using Restaurant.Application.ViewModels;
using Restaurant.Core.Entities;

namespace Restaurant.Application.Mappers
{
    public class ProductCategoryMapper : Profile
    {
        public ProductCategoryMapper()
        {
            CreateMap<CreateProductCategoryCommand, ProductCategory>().ReverseMap();
            CreateMap<ProductCategoryViewModel, ProductCategory>().ReverseMap();
            CreateMap<UpdateProductCategoryCommand, ProductCategory>().ReverseMap();
        }
    }
}
