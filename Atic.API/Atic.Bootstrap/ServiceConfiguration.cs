using Atic.Bootstrap.Providers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Atic.Bootstrap
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen();
            services.AddMediatr();
            services.ConfigurePersistenceServices(configuration);
            services.AddQuerys();
            services.AddCommands();
            return services;
        }
    }
}
