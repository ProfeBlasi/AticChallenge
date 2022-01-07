using Atic.Persistance.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Atic.Bootstrap.Providers
{
    public static class PersistenceConfiguration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetSection("ConnectionString").Value;
            services.AddDbContext<AticPruebaDeCandidatosContext>(opcion => opcion.UseSqlServer(connectionString));
           
            services.AddTransient<IDbConnection>(s =>
            {
                return new SqlConnection(connectionString);
            });
            return services;
        }
    }
}
