using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Atic.Bootstrap.Providers
{
    public static class MediatorConfiguration
    {
        public static IServiceCollection AddMediatr(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.Load("Atic.Application"));
            return services;
        }
    }
}