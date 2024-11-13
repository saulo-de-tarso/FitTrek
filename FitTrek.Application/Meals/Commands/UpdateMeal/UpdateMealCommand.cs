using FitTrek.Domain.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FitTrek.Application.Meals.Commands.UpdateMeal;

public class UpdateMealCommand : IRequest
{

    [JsonIgnore]
    public int Id { get; set; }
    public string? MealType { get; set; } = default!;
    
    public string? Description { get; set; } = default!;

    
    public int? Calories { get; set; }
    
    public int? Carbs { get; set; }
    
    public int? Proteins { get; set; }
    
    public int? Fats { get; set; }

    [JsonIgnore]
    public int DietPlanId { get; set; }

}
