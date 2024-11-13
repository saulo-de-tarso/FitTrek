using FitTrek.Application.DietPlans.Dtos;
using MediatR;

namespace FitTrek.Application.DietPlans.Queries.GetDietPlanById;

public class GetDietPlanByIdQuery(int clientId, int dietPlanId) : IRequest<DietPlanDto>
{

    public int Id { get; } = dietPlanId;

    public int ClientId { get; set; } = clientId;
}
