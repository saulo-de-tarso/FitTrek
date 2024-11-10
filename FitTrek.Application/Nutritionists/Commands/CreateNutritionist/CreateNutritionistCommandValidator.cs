using FluentValidation;

namespace FitTrek.Application.Nutritionists.Commands.CreateNutritionist;

public class CreateNutritionistCommandValidator : AbstractValidator<CreateNutritionistCommand>
{
    public CreateNutritionistCommandValidator()
    {
        RuleFor(c => c.Email)
            .EmailAddress()
            .WithMessage("Please provide a valid email address.");

        RuleFor(c => c.PhoneNumber)
            .Matches(@"^\(\d{2}\) 9\d{4}-\d{4}$")
            .WithMessage("The phone number must be in the format (XX) 9XXXX-XXXX.");
    }
}
