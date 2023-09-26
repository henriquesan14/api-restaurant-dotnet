using AutoMapper;
using Restaurant.Application.ViewModels;
using Restaurant.Core.Entities;

namespace Restaurant.Application.Mappers
{
    public class OrderItemMapper : Profile
    {
        public OrderItemMapper()
        {
            CreateMap<OrderItem, OrderItemViewModel>().ReverseMap();
        }
    }
}
