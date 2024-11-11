using FitTrek.Application.Clients.Dtos;
using MediatR;

namespace FitTrek.Application.Clients.Queries.GetClientByIdForNutritionist;

public class GetClientByIdForNutritionistQuery(int nutritionistId, int clientId) : IRequest<ClientDto>
{
    public int NutritionistId { get; } = nutritionistId;
    public int Id { get; } = clientId;
}
