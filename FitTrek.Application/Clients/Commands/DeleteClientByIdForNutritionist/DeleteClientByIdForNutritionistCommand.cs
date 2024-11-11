using MediatR;

namespace FitTrek.Application.Clients.Commands.DeleteClientByIdForNutritionist;

public class DeleteClientByIdForNutritionistCommand(int nutritionistId, int clientId) : IRequest
{
    public int NutritionistId { get; } = nutritionistId;
    public int ClientId { get; } = clientId;

}
