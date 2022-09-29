using AutoMapper;
using Restaurant.Application.Commands.OrderCommands;
using Restaurant.Application.Commands.OrderCommands.CreateCommonOrder;
using Restaurant.Application.Commands.OrderCommands.CreateDeliveryOrder;
using Restaurant.Application.ViewModels;
using Restaurant.Core.Entities;

namespace Restaurant.Application.Mappers
{
    public class OrderMapper : Profile
    {
        public OrderMapper()
        {
            CreateMap<CommonOrder, OrderViewModel>().ReverseMap();
            CreateMap<DeliveryOrder, OrderViewModel>().ReverseMap();
            CreateMap<CreateCommonOrderCommand, CommonOrder>().ReverseMap();
            CreateMap<CreateDeliveryOrderCommand, DeliveryOrder>().ReverseMap();
            CreateMap<OrderItemCommand, OrderItem>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
