using AutoMapper;
using Omoqo.ShipManagement.Application.Ships.Commands;
using Omoqo.ShipManagement.Domain.Ships.Models;

namespace ShipManagementGUI.ViewModels.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Ship, ShipViewModel>();
            CreateMap<ShipViewModel, CreateShipCommand>(); 
            CreateMap<ShipViewModel, UpdateShipCommand>(); 
        }
    }
}
