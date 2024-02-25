using Omoqo.ShipManagement.Domain.Repositories;
using Omoqo.ShipManagement.Domain.Ships.Models;

namespace Omoqo.ShipManagement.Application.Ships.Services
{
    public class ShipService : IShipService
    {
        private readonly IShipManagementRepository _shipManagementRepository;

        //Service for validations, business rules, mapper, etc. 

        public ShipService(IShipManagementRepository shipManagementRepository)
        {
            _shipManagementRepository = shipManagementRepository;
    }
        public Task<IEnumerable<Ship>> GetAllShipsAsync()
        {
            return _shipManagementRepository.GetAllAsync();
        }

        public Task<Ship> GetShipAsync(Guid id)
        {
            return _shipManagementRepository.GetByIdAsync(id);
        }
    }
}
