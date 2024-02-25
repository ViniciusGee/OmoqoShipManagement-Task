using Omoqo.ShipManagement.Application.Ships.Commands;
using ShipManagementGUI.Utility;
using ShipManagementGUI.ViewModels;

namespace ShipManagementGUI.Services
{
    public interface IShipManagementBffService
    {
        Task<IEnumerable<ShipViewModel>> GetAllShips();
        Task<ShipViewModel> GetShip(Guid Id);
        Task<ResponseResult> CreateShip(ShipViewModel ship);
        Task<ResponseResult> UpdateShip(ShipViewModel ship);
        Task<ResponseResult> DeleteShip(Guid Id);
    }
}
