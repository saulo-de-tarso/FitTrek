using AutoMapper;
using FitTrek.Application.Users;
using FitTrek.Domain.Entities;
using FitTrek.Domain.Exceptions;
using FitTrek.Domain.Extensions;
using FitTrek.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FitTrek.Application.Meals.Commands.UpdateMeal;

public class UpdateMealCommandHandler(ILogger<UpdateMealCommandHandler> logger,
    IMapper mapper,
    INutritionistsRepository nutritionistsRepository,
    IDietPlansRepository dietPlansRepository,
    IMealsRepository mealsRepository,
    IUserContext userContext) : IRequestHandler<UpdateMealCommand>
{
    public async Task Handle(UpdateMealCommand request, CancellationToken cancellationToken)
    {
        var user = userContext.GetCurrentUser();

        var nutritionist = await nutritionistsRepository.GetByUserIdAsync(user!.Id);

        var dietPlan = await dietPlansRepository.GetByIdAsync(request.DietPlanId)
            ?? throw new NotFoundException(nameof(DietPlan), request.DietPlanId.ToString());

        if (dietPlan.NutritionistId != nutritionist.Id)
            throw new ForbidException();

        logger.LogWarning("Nutritionist with id {nutritionist.Id} is updating meal with id {DietPlanId} for client with id {ClientId}:" +
            "with the values: {@UpdatedDietPlan}", nutritionist.Id, request.DietPlanId, dietPlan.ClientId, request);

        var meal = dietPlan.Meals.FirstOrDefault(c => c.Id == request.Id)
            ?? throw new NotFoundException(nameof(Meal), request.Id.ToString());

        //logic so that you can update only one property
        if (request.MealType is null)
            request.MealType = meal.MealType;
        if (request.Description is null)
            request.Description = meal.Description;
        if (request.Calories is null)
            request.Calories = meal.Calories;
        if (request.Carbs is null)
            request.Carbs = meal.Carbs;
        if (request.Proteins is null)
            request.Proteins = meal.Proteins;
        if (request.Fats is null)
            request.Fats = meal.Fats;

        mapper.Map(request, meal);

        await mealsRepository.SaveChanges();


    }
}
