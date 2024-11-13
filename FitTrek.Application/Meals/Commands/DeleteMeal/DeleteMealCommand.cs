using FitTrek.Domain.Entities;
using MediatR;

namespace FitTrek.Application.Meals.Commands.DeleteMeal;

public class DeleteMealCommand(int dietPlanId, int mealId) : IRequest
{

    public int MealId { get; } = mealId;
    public int DietPlanId { get; } = dietPlanId;

}
