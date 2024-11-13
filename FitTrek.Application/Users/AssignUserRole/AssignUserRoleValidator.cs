using FitTrek.Domain.Constants;
using FluentValidation;

namespace FitTrek.Application.Users.AssignUserRole;

public class AssignUserRoleCommandValidator : AbstractValidator<AssignUserRoleCommand>
{
    public AssignUserRoleCommandValidator()
    {
        RuleFor(u => u.NutritionistId)
            .NotEmpty().When(u => u.RoleName == UserRoles.Nutritionist)
            .WithMessage("Nutritionist id is required when unassigning a role for nutritionist");

        RuleFor(u => u.ClientId)
            .NotEmpty().When(u => u.RoleName == UserRoles.Client)
            .WithMessage("Client id is required when unassigning a role for nutritionist");
    }

}
