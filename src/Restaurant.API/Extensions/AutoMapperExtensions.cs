using AutoMapper;
using Restaurant.Application.Mappers;

namespace Restaurant.API.Extensions
{
    public static class AutoMapperExtensions
    {
        public static IServiceCollection AutoMapperConfig(this IServiceCollection services)
        {
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductMapper>();
                cfg.AddProfile<ProductCategoryMapper>();
                cfg.AddProfile<UserMapper>();
                cfg.AddProfile<OrderMapper>();
                cfg.AddProfile<TableMapper>();
                cfg.AddProfile<OrderItemMapper>();
                cfg.AddProfile<AddressMapper>();
                cfg.AddProfile<StatisticOrderMapper>();
                cfg.AddProfile<MenuItemMapper>();
                cfg.AddProfile<MenuMapper>();
            });
            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }
    }
}
