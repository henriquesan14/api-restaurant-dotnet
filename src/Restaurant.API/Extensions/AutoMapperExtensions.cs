using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
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
                cfg.AddProfile<CategoryMapper>();
                cfg.AddProfile<UserMapper>();
                cfg.AddProfile<OrderMapper>();
                cfg.AddProfile<TableMapper>();
            });
            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }
    }
}
