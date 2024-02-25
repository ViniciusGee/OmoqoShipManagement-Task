using MediatR;
using Omoqo.Shared.Notifications;
using Omoqo.ShipManagement.Application.Ships.Commands.Validations;

namespace Omoqo.ShipManagement.Application.Ships.Commands
{
    public class UpdateShipCommand : Notifiable, IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public int Length { get; set; }
        public int Width { get; set; }
        public string Code { get; set; } = default!;

        public override bool IsValid()
        {
            return ValidateObject(new UpdateShipValidation());
        }
    }
}
