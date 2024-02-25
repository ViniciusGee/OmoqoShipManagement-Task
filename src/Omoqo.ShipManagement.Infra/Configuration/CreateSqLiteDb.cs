using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Omoqo.ShipManagement.Infra.Configuration
{
    public static class CreateSqLiteDb
    {
        public static void InitializeDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<ShipManagementDbContext>();
                context.Database.EnsureCreated(); // Creates the database if it doesn't exist
            }
        }
    }
}
