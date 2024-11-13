using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FitTrek.Application.DietPlans.Commands.UpdateDietPlan;

public class UpdateDietPlanCommand : IRequest
{
    [JsonIgnore]
    public int Id { get; set; }
    public string? Goal { get; set; }
    
    public DateOnly? StartDate { get; set; }
    
    public DateOnly? EndDate { get; set; }

    public int? Calories { get; set; }

    [JsonIgnore]
    public int ClientId { get; set; }
}
