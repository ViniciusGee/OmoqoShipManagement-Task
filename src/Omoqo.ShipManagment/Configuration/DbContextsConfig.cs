using Microsoft.EntityFrameworkCore;
using Omoqo.ShipManagement.Infra;
using System;

namespace Omoqo.ShipManagement.Configuration
{
    public static class DbContextsConfig
    {
        private const string OmoqoDbConnectionString = "SqliteConnectionConfiguration";

        public static IServiceCollection AddDbContextsConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ShipManagementDbContext>(sqlOptions =>
                                    sqlOptions.UseSqlite(configuration.GetConnectionString(OmoqoDbConnectionString)));

            //Add many...

            return services;
        }

        public static string GetConnectionString(this IConfiguration configuration, string connectionName)
        {
            return configuration[$"SqliteConnection:{connectionName}"];
        }

        public static IServiceProvider CreateInMemoryDb(this IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ShipManagementDbContext>();
                dbContext.Database.EnsureCreated();
            }

            return serviceProvider;
        }
    }
}
