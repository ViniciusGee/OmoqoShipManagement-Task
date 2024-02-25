using Microsoft.AspNetCore.Mvc.DataAnnotations;
using ShipManagementGUI.Services;

namespace ShipManagementGUI.Settings
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient<IShipManagementBffService, ShipManagementBffService>();
        }
    }
}
