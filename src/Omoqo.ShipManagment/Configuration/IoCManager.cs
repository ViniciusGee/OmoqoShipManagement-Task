using Microsoft.AspNetCore.Hosting;
using Omoqo.Shared.Notifications;
using Omoqo.ShipManagement.Application.Ships.Handler;
using Omoqo.ShipManagement.Application.Ships.Services;
using System.Reflection;
using ShipManagmentInfra = Omoqo.ShipManagement.Infra.Ioc;

namespace Omoqo.ShipManagement.Configuration
{
    public static class IocManager
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddScoped<INotifier, Notifier>();
            services.AddScoped<IShipService, ShipService>();

            services = ShipManagmentInfra.ResolveDependencies(services);

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<ShipCommandsHandler>());

            return services;
        }
    }
}
