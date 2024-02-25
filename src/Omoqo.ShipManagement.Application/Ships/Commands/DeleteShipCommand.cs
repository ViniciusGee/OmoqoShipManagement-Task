using MediatR;
using Omoqo.Shared.Notifications;
using Omoqo.ShipManagement.Application.Ships.Commands.Validations;

namespace Omoqo.ShipManagement.Application.Ships.Commands
{
    public class DeleteShipCommand: Notifiable, IRequest
    {
        public Guid Id { get; set; }

        public DeleteShipCommand(Guid id)
        {
            Id = id;
        }
        public override bool IsValid()
        {
            return ValidateObject(new DeleteShipValidation());
        }
    }
}
