using FitTrek.Domain.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FitTrek.Application.Meals.Commands.CreateMeal;

public class CreateMealCommand : IRequest<int>
{
    [Required]
    public string MealType { get; set; } = default!;
    [Required]
    public string Description { get; set; } = default!;

    [Required]
    public int Calories { get; set; }
    [Required]
    public int Carbs { get; set; }
    [Required]
    public int Proteins { get; set; }
    [Required]
    public int Fats { get; set; }

    [JsonIgnore]
    public int DietPlanId { get; set; }

}
