using FitTrek.Application.Clients.Dtos;
using MediatR;

namespace FitTrek.Application.Clients.Queries.GetClientsForNutritionist;

public class GetClientsForNutritionistQuery(int nutritionistId) : IRequest<IEnumerable<ClientDto>>
{
    public int NutritionistId { get; } = nutritionistId;
}
