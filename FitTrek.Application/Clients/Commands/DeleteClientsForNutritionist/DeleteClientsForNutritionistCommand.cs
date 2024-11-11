using MediatR;

namespace FitTrek.Application.Clients.Commands.DeleteClientsForNutritionist;

public class DeleteClientsForNutritionistCommand(int nutritionistId) : IRequest
{
    public int NutritionistId { get; } = nutritionistId;
}
