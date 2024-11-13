using FitTrek.Application.Users;
using FitTrek.Domain.Entities;
using FitTrek.Domain.Exceptions;
using FitTrek.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FitTrek.Application.Meals.Commands.DeleteMeal;

public class DeleteMealCommandHandler(ILogger<DeleteMealCommandHandler> logger,
    INutritionistsRepository nutritionistsRepository,
    IDietPlansRepository dietPlansRepository,
    IMealsRepository mealsRepository,
    IUserContext userContext) : IRequestHandler<DeleteMealCommand>
{

    public async Task Handle(DeleteMealCommand request, CancellationToken cancellationToken)
    {

        var user = userContext.GetCurrentUser();

        var nutritionist = await nutritionistsRepository.GetByUserIdAsync(user!.Id);

        var dietPlan = await dietPlansRepository.GetByIdAsync(request.DietPlanId)
            ?? throw new NotFoundException(nameof(DietPlan), request.DietPlanId.ToString());

        if (dietPlan.NutritionistId != nutritionist.Id)
            throw new ForbidException();

        logger.LogWarning($"Nutritionist with id {nutritionist.Id} is removing meal with id {request.MealId} " +
            $"for diet plan {request.DietPlanId} and client {dietPlan.ClientId}");
        
        var meal = dietPlan.Meals.FirstOrDefault(c => c.Id == request.MealId)
            ?? throw new NotFoundException(nameof(Meal), request.MealId.ToString());

        await mealsRepository.DeleteById(meal);

    }
}
