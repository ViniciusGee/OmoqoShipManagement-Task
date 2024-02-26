using Omoqo.ShipManagement.Domain.Ships.Models;

namespace Omoqo.ShipManagement.Domain.Repositories
{
    public interface IShipManagementRepository
    {
        Task CreateAsync(Ship ship);
        Task<Ship> GetByIdAsync(Guid shipId);
        Task<IEnumerable<Ship>> GetAllAsync();
        Task<Ship> GetTrackedByIdAsync(Guid shipId);
        Task<Ship> GetShipWithThisNameAsync(string shipName);
        Task<bool> AnyShipWithThisNameAndIdAsync(string shipName, Guid shipId);
        void DeleteShip(Ship ship);
    }
}
