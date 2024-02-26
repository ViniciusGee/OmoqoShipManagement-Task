using Microsoft.EntityFrameworkCore;
using Omoqo.Shared.Support.EntityMethodsExtensions;
using Omoqo.ShipManagement.Domain.Repositories;
using Omoqo.ShipManagement.Domain.Ships.Models;

namespace Omoqo.ShipManagement.Infra.Repositories
{
    public class ShipManagementRepository : IShipManagementRepository
    {
        //Using only this dbset object type, not all context objects(if we have more). 
        private readonly DbSet<Ship> _ships;

        public ShipManagementRepository(ShipManagementDbContext context)
        {
            _ships = context.Ships;
        }

        public async Task CreateAsync(Ship ship)
        {
            await _ships.AddAsync(ship);
        }

        public async Task<IEnumerable<Ship>> GetAllAsync()
        {
            return await _ships
                        .UseNolock()
                        .ToListAsync();
        }

        public async Task<Ship> GetByIdAsync(Guid shipId)
        {
            var result = await _ships
                        .UseNolock()
                        .FirstOrDefaultAsync(d => d.Id == shipId);

            return result ?? default!;
        }

        public async Task<Ship> GetTrackedByIdAsync(Guid shipId)
        {
            var result = await _ships
                               .AsTracking()
                               .FirstOrDefaultAsync(d => d.Id == shipId);

            return result ?? default!;
        }

        public async Task<Ship> GetShipWithThisNameAsync(string shipName)
        {
            var result = await _ships
                                .AsTracking()
                                .FirstOrDefaultAsync(d => d.Name == shipName);

            return result ?? default!;
        }

        public async Task<bool> AnyShipWithThisNameAndIdAsync(string shipName, Guid Id)
        {
            return await _ships
                .UseNolock()
                .AnyAsync(d => d.Name == shipName && d.Id == Id);
        }

        public void DeleteShip(Ship ship)
        {
            _ships.Remove(ship);
        }
    }
}
