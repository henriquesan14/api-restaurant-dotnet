using AutoMapper;
using Restaurant.Application.Commands.OrderCommands.UpdateOrderItemCommand;
using Restaurant.Application.Commands.OrderCommands;
using Restaurant.Application.ViewModels;
using Restaurant.Core.Entities;

namespace Restaurant.Application.Mappers
{
    public class OrderItemMapper : Profile
    {
        public OrderItemMapper()
        {
            CreateMap<OrderItem, OrderItemViewModel>().ReverseMap();
            CreateMap<OrderItemCommand, OrderItem>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<UpdateOrderItemCommand, OrderItem>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
