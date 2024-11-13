using AutoMapper;
using FitTrek.Application.Users;
using FitTrek.Domain.Entities;
using FitTrek.Domain.Exceptions;
using FitTrek.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FitTrek.Application.Meals.Commands.CreateMeal;

public class CreateMealCommandHandler(ILogger<CreateMealCommandHandler> logger,
    IMapper mapper,
    INutritionistsRepository nutritionistsRepository,
    IDietPlansRepository dietPlansRepository,
    IMealsRepository mealsRepository,
    IUserContext userContext) : IRequestHandler<CreateMealCommand, int>
{
    public async Task<int> Handle(CreateMealCommand request, CancellationToken cancellationToken)
    {

        var user = userContext.GetCurrentUser();

        var nutritionist = await nutritionistsRepository.GetByUserIdAsync(user!.Id);

        var dietPlan = await dietPlansRepository.GetByIdAsync(request.DietPlanId) 
            ?? throw new NotFoundException(nameof(DietPlan), request.DietPlanId.ToString());

        if (dietPlan.NutritionistId != nutritionist.Id)
            throw new ForbidException();
        

        logger.LogInformation("Nutritionist {NutritionistId} is creating a new meal: {@Meal} for diet plan {dietPlanId} and client {clientId}",
            nutritionist.Id,
            request,
            request.DietPlanId,
            dietPlan.ClientId);

        var meal = mapper.Map<Meal>(request);


        int id = await mealsRepository.Create(meal);

        return id;
    }
}
