using Microsoft.Extensions.DependencyInjection;
using Restaurant.Application.Services;
using Restaurant.Core.Repositories;
using Restaurant.Core.Repositories.Base;
using Restaurant.Core.Services;
using Restaurant.Infra.MessageBus;
using Restaurant.Infra.Repositories;
using Restaurant.Infra.Repositories.Base;

namespace Restaurant.API.Extensions
{
    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            //Repositories
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<ITableRepository, TableRepository>();
            services.AddTransient<IOrderItemRepository, OrderItemRepository>();
            services.AddTransient<IAddressRepository, AddressRepository>();

            //Services
            services.AddTransient<ITokenService, TokenService>();
            services.AddScoped<IMessageBusService, MessageBusService>();
            services.AddScoped<IPaymentService, PaymentService>();

            return services;
        }
    }
}
