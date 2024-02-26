using MediatR;
using Omoqo.Shared.Notifications;
using Omoqo.Shared.Support.Constants;
using Omoqo.ShipManagement.Application.Ships.Commands;
using Omoqo.ShipManagement.Application.Ships.Commands.Validations;
using Omoqo.ShipManagement.Domain.Repositories;
using Omoqo.ShipManagement.Domain.Ships.Models;
using Omoqo.ShipManagement.Domain.Ships.Persistence;
using System.Text.Json;

namespace Omoqo.ShipManagement.Application.Ships.Handler
{
    public class ShipCommandsHandler : IRequestHandler<CreateShipCommand, Ship>,
                                        IRequestHandler<UpdateShipCommand>,
                                        IRequestHandler<DeleteShipCommand>
    {
        private readonly INotifier _notifier;
        private readonly IShipManagementRepository _shipManagementRepository;
        private readonly IShipUnitOfWork _unitOfWork;
       
                          
        public ShipCommandsHandler(INotifier notifier,
                                   IShipManagementRepository shipManagementRepository,
                                   IShipUnitOfWork unitOfWork)
        {
            _notifier = notifier;
            _shipManagementRepository = shipManagementRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Ship> Handle(CreateShipCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                _notifier.AddNotifications(request.GetNotifications());
                return default!; 
            }

            if (!await ValidateRulesCreateShip(request.Name))
                return default!;

            var ship = new Ship(request.Name, request.Length, request.Width, request.Code);

            await _shipManagementRepository.CreateAsync(ship);

            await _unitOfWork.SaveChangesAsync();

            return ship;
        }

        public async Task Handle(UpdateShipCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                _notifier.AddNotifications(request.GetNotifications());
                return; //Mediator v12.x requires
            }

            if (!await ValidateRulesuUpdateShip(request.Name, request.Id))
            {
                _notifier.AddNotifications(request.GetNotifications());
                return; 
            }

            var ship = await _shipManagementRepository.GetTrackedByIdAsync(request.Id);

            if (ship is null)
            {
                _notifier.AddNotification(new Notification(SharedErrorMessages.NotFoundCode, ShipMessages.ErrorShipNotFound));
                return;
            }

            ship.Update(request.Name, request.Length, request.Width, request.Code);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task Handle(DeleteShipCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                _notifier.AddNotifications(request.GetNotifications());
                return;
            }

            var ship = await _shipManagementRepository.GetByIdAsync(request.Id);

            if (ship is null)
            {
                _notifier.AddNotification(new Notification(SharedErrorMessages.NotFoundCode, ShipMessages.ErrorShipNotFound));
                return;
            }

            _shipManagementRepository.DeleteShip(ship);

            await _unitOfWork.SaveChangesAsync();
        }

        private async Task<bool> ValidateRulesCreateShip(string shipName)
        {
            if (await _shipManagementRepository.GetShipWithThisNameAsync(shipName) != null)
            {
                _notifier.AddNotification(new Notification(SharedErrorMessages.Conflict, $"Already has a ship with the name {shipName}"));
                return false;
            }

            return true;
        }

        private async Task<bool> ValidateRulesuUpdateShip(string shipName, Guid shipId)
        {
            var shipWithSameName = await _shipManagementRepository.GetShipWithThisNameAsync(shipName);

            if (shipWithSameName != null)
            {
                if (shipWithSameName.Id != shipId)
                {
                    _notifier.AddNotification(new Notification(SharedErrorMessages.Conflict, $"Already has a ship with the name {shipName}"));
                    return false;
                }
            }

            return true;
        }
    }
}
