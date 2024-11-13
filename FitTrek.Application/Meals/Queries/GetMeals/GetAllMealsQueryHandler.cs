using AutoMapper;
using FitTrek.Application.Meals.Dtos;
using FitTrek.Application.Common.Pagination;
using FitTrek.Application.Users;
using FitTrek.Domain.Entities;
using FitTrek.Domain.Enums;
using FitTrek.Domain.Exceptions;
using FitTrek.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;
using FitTrek.Application.DietPlans.Dtos;

namespace FitTrek.Application.Meals.Queries.GetMeals;

public class GetAllMealsQueryHandler(ILogger<GetAllMealsQueryHandler> logger,
    INutritionistsRepository nutritionistsRepository,
    IDietPlansRepository dietPlansRepository,
    IMapper mapper,
    IUserContext userContext) : IRequestHandler<GetAllMealsQuery, IEnumerable<MealDto>>
{

    public async Task<IEnumerable<MealDto>> Handle(GetAllMealsQuery request, CancellationToken cancellationToken)
    {
        var user = userContext.GetCurrentUser();

        var nutritionist = await nutritionistsRepository.GetByUserIdAsync(user!.Id);

        var dietPlan = await dietPlansRepository.GetByIdAsync(request.DietPlanId)
            ?? throw new NotFoundException(nameof(DietPlan), request.DietPlanId.ToString());

        if (dietPlan.NutritionistId != nutritionist.Id)
            throw new ForbidException();

        logger.LogInformation($"Getting all meals of dietplan {request.DietPlanId} for nutritionist with id {nutritionist.Id}");

        var meals = dietPlan.Meals;
        
        var result = mapper.Map<IEnumerable<MealDto>>(meals);
            

        return result;


    }




}
