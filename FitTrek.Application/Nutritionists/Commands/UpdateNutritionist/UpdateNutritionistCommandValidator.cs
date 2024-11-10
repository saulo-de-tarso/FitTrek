using FitTrek.Domain.Entities;
using FluentValidation;
using MediatR;

namespace FitTrek.Application.Nutritionists.Commands.UpdateNutritionist;

public class UpdateNutritionistCommandValidator : AbstractValidator<UpdateNutritionistCommand>
{
    public UpdateNutritionistCommandValidator()
    {
        RuleFor(c => c.Email)
            .EmailAddress()
            .WithMessage("Please provide a valid email address.");

        RuleFor(c => c.PhoneNumber)
                .Matches(@"^\(\d{2}\) 9\d{4}-\d{4}$")
                .WithMessage("The phone number must be in the format (XX) 9XXXX-XXXX.");

    }
    
}
