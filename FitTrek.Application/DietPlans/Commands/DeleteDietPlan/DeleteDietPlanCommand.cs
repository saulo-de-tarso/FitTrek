using MediatR;
using System.Text.Json.Serialization;

namespace FitTrek.Application.DietPlans.Commands.DeleteDietPlan;

public class DeleteDietPlanCommand(int clientId, int id) : IRequest
{
    public int ClientId { get; set; } = clientId;
    public int DietPlanId { get; } = id;

}
