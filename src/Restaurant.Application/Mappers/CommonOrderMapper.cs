using AutoMapper;
using Restaurant.Application.Commands.OrderCommands.CreateCommonOrder;
using Restaurant.Core.Entities;

namespace Restaurant.Application.Mappers
{
    public class CommonOrderMapper : Profile
    {
        public CommonOrderMapper()
        {
            CreateMap<CreateCommonOrderCommand, CommonOrder>().ReverseMap();
            CreateMap<OrderItemCommand, OrderItem>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
