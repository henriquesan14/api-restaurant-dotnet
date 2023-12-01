using AutoMapper;
using Restaurant.Application.ViewModels;
using Restaurant.Core.Entities.Statistic;

namespace Restaurant.Application.Mappers
{
    public class StatisticOrderMapper : Profile
    {
        public StatisticOrderMapper()
        {
            CreateMap<StatisticOrder, StatisticOrderViewModel>().ReverseMap();
        }
    }
}
