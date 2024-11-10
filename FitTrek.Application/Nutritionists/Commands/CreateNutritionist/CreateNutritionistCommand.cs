using MediatR;

namespace FitTrek.Application.Nutritionists.Commands.CreateNutritionist;

public class CreateNutritionistCommand : IRequest<int>
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;

    public string Email { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;

    public DateTime DateOfBirth { get; set; } = default!;
}
