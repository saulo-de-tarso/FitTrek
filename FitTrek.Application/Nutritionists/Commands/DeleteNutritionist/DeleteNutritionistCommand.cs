using MediatR;

namespace FitTrek.Application.Nutritionists.Commands.DeleteNutritionist;

public class DeleteNutritionistCommand(int id) : IRequest<bool>
{
    public int Id { get; } = id;
}
