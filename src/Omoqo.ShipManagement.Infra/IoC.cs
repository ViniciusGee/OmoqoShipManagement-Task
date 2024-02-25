using Microsoft.Extensions.DependencyInjection;
using Omoqo.ShipManagement.Domain.Repositories;
using Omoqo.ShipManagement.Domain.Ships.Persistence;
using Omoqo.ShipManagement.Infra.Persistence;
using Omoqo.ShipManagement.Infra.Repositories;

namespace Omoqo.ShipManagement.Infra
{
    public static class Ioc
    {
        public static IServiceCollection ResolveDependencies(IServiceCollection services)
        {
            services.AddScoped<ShipManagementDbContext>();

            services.AddScoped<IShipUnitOfWork, UnitOfWork>();

            services.AddScoped<IShipManagementRepository, ShipManagementRepository>();

            return services;
        }
    }
}
