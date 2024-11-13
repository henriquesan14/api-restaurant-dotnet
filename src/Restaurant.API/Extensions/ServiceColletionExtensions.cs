using Restaurant.Application.Identity;
using Restaurant.Core.Repositories;
using Restaurant.Core.Repositories.Base;
using Restaurant.Core.Services;
using Restaurant.Infra.MessageBus;
using Restaurant.Infra.Persistence.Repositories;
using Restaurant.Infra.Persistence.Repositories.Base;
using Restaurant.Infra.Services;

namespace Restaurant.API.Extensions
{
    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            //Repositories
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<ITableRepository, TableRepository>();
            services.AddTransient<IOrderItemRepository, OrderItemRepository>();
            services.AddTransient<IAddressRepository, AddressRepository>();
            services.AddTransient<IMenuItemRepository, MenuItemRepository>();
            services.AddTransient<IMenuCategoryRepository, MenuCategoryRepository>();
            services.AddTransient<IMenuRepository, MenuRepository>();
            services.AddTransient<IStockProductRepository, StockProductRepository>();
            services.AddTransient<IStockMovementRepository, StockMovementRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            //Services
            services.AddTransient<ITokenService, TokenService>();
            services.AddScoped<IMessageBusService, MessageBusService>();
            services.AddScoped<IPaymentService, PaymentService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<AuthenticatedUser>();

            return services;
        }
    }
}
