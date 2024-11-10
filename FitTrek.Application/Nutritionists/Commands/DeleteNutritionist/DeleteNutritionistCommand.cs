using MediatR;

namespace FitTrek.Application.Nutritionists.Commands.DeleteNutritionist;

public class DeleteNutritionistCommand(int id) : IRequest
{
    public int Id { get; } = id;
}
