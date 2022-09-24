using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Serialization;

namespace Restaurant.API.Extensions
{
    public static class SerializationExtensions
    {
        public static IServiceCollection JsonSerializationConfig(this IServiceCollection services)
        {
            services.AddControllers().AddJsonOptions(options => {
                options.JsonSerializerOptions.IgnoreNullValues = true;
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });

            return services;
        }
    }
}
