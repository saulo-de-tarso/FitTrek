using FluentValidation;

namespace FitTrek.Application.Clients.Commands.UpdateClient;

public class UpdateClientCommandValidator : AbstractValidator<UpdateClientCommand>
{
    public UpdateClientCommandValidator()
    {
        RuleFor(c => c.Email)
            .EmailAddress()
            .WithMessage("Please provide a valid email address.");

        RuleFor(c => c.PhoneNumber)
            .Matches(@"^\(\d{2}\) 9\d{4}-\d{4}$")
            .WithMessage("The phone number must be in the format (XX) 9XXXX-XXXX.");

        RuleFor(c => c.HeightInCm)
            .GreaterThanOrEqualTo(50).WithMessage("Height must be at least 50 cm.")
            .LessThanOrEqualTo(300).WithMessage("Height must be no more than 300 cm.");

        RuleFor(c => c.WeightInKg)
            .GreaterThan(0).WithMessage("Weight must be greater than 0 kg.")
            .LessThanOrEqualTo(500).WithMessage("Weight must be no more than 500 kg.");
    }

}
