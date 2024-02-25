using FluentValidation;

namespace Omoqo.ShipManagement.Application.Ships.Commands.Validations
{
    public class DeleteShipValidation : AbstractValidator<DeleteShipCommand>
    {
        public DeleteShipValidation()
        {
            RuleFor(c => c.Id).NotEmpty().WithMessage("Id must be valid.");
        }
    }
}
