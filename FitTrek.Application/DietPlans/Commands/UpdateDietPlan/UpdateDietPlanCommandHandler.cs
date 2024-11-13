using AutoMapper;
using FitTrek.Application.Users;
using FitTrek.Domain.Entities;
using FitTrek.Domain.Exceptions;
using FitTrek.Domain.Extensions;
using FitTrek.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FitTrek.Application.DietPlans.Commands.UpdateDietPlan;

public class UpdateDietPlanCommandHandler(ILogger<UpdateDietPlanCommandHandler> logger,
    IMapper mapper,
    INutritionistsRepository nutritionistsRepository,
    IDietPlansRepository dietPlansRepository,
    IUserContext userContext) : IRequestHandler<UpdateDietPlanCommand>
{
    public async Task Handle(UpdateDietPlanCommand request, CancellationToken cancellationToken)
    {
        var user = userContext.GetCurrentUser();

        var nutritionist = await nutritionistsRepository.GetByUserIdWithDietPlansAsync(user!.Id);


        logger.LogInformation("Updating diet plan with id {DietPlanId} for client with id {ClientId}" +
            " for nutritionist with id {NutritionistId} with the values: {@UpdatedDietPlan}",
            request.Id, request.ClientId, nutritionist.Id, request);

        var client = nutritionist.Clients.FirstOrDefault(c => c.Id == request.ClientId)
            ?? throw new NotFoundException(nameof(Client), request.ClientId.ToString());

        var dietPlan = nutritionist.DietPlans.FirstOrDefault(c => c.Id == request.Id)
            ?? throw new NotFoundException(nameof(DietPlan), request.Id.ToString());


        //logic so that you can update only one property
        if (request.Goal is null)
            request.Goal = dietPlan.Goal;
        if (request.StartDate is null)
            request.StartDate = dietPlan.StartDate;
        if (request.EndDate is null)
            request.EndDate = dietPlan.EndDate;
        if (request.Calories is null)
            request.Calories = dietPlan.Calories;


        mapper.Map(request, dietPlan);

        await dietPlansRepository.SaveChanges();


    }
}
