using FitTrek.Domain.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FitTrek.Application.DietPlans.Commands.CreateDietPlan;

public class CreateDietPlanCommand : IRequest<int>
{
    [Required]
    public string Goal { get; set; } = default!;
    [Required]
    public DateOnly StartDate { get; set; } = default!;
    [Required]
    public DateOnly EndDate { get; set; } = default!;

    public int Calories { get; set; }

    [JsonIgnore]
    public int NutritionistId { get; set; }

    [JsonIgnore]
    public int ClientId { get; set; }

}
