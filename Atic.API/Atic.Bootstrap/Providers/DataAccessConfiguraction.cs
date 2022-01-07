using Atic.Domain.Interface.Command;
using Atic.Domain.Interface.Queries;
using Atic.Persistance.Command;
using Atic.Persistance.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace Atic.Bootstrap.Providers
{
    public static class DataAccessConfiguraction
    {
        public static IServiceCollection AddQuerys(this IServiceCollection services)
        {
            services.AddTransient<IGenericsQuery, GenericsQuery>();
            return services;
        }
        public static IServiceCollection AddCommands(this IServiceCollection services)
        {
            services.AddTransient<IGenericsCommand, GenericsCommand>();
            return services;
        }
    }
}