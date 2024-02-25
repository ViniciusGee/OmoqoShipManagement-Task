
using Omoqo.ShipManagement.Domain.Ships.Models;

namespace Omoqo.ShipManagement.Application.Ships.Services
{
    public interface IShipService
    {
        Task<IEnumerable<Ship>> GetAllShipsAsync();
        Task<Ship> GetShipAsync(Guid id);

        //Add many services as needed...

    }
}
