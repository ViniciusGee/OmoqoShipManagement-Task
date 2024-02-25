using FluentValidation;

namespace Omoqo.ShipManagement.Application.Ships.Commands.Validations
{
    public class UpdateShipValidation : AbstractValidator<UpdateShipCommand>
    {
        public UpdateShipValidation()
        {
            RuleFor(c => c.Id)
                  .NotEmpty()
                  .WithMessage("Id must be set");

            RuleFor(c => c.Name)
                  .NotEmpty()
                  .WithMessage("Ship's name must be set");

            RuleFor(c => c.Length)
               .NotEmpty()
               .InclusiveBetween(1, int.MaxValue)
               .WithMessage("Ship's lenght must be set(meters) and bigger than 0");

            RuleFor(c => c.Width)
            .NotEmpty()
            .InclusiveBetween(1, int.MaxValue)
            .WithMessage("Ship's width must be set(meters) and bigger than 0");

            RuleFor(x => x.Code)
                .NotEmpty()
                .Matches(@"^[A-Za-z]{4}-\d{4}-[A-Za-z]\d$")
                .WithMessage("The format must be AAAA-1111-A1, where A is any letter from the Latin alphabet and 1 is a number from 0 to 9.");
        }
    }
}
