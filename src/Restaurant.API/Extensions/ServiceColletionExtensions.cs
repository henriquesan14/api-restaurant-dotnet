using Microsoft.Extensions.DependencyInjection;
using Restaurant.Core.Repositories;
using Restaurant.Core.Repositories.Base;
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

            return services;
        }
    }
}
