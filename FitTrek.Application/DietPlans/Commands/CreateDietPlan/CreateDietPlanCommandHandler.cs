using AutoMapper;
using FitTrek.Application.Users;
using FitTrek.Domain.Entities;
using FitTrek.Domain.Extensions;
using FitTrek.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FitTrek.Application.DietPlans.Commands.CreateDietPlan;

public class CreateDietPlanCommandHandler(ILogger<CreateDietPlanCommandHandler> logger,
    IMapper mapper,
    INutritionistsRepository nutritionistsRepository,
    IDietPlansRepository dietPlansRepository,
    IUserContext userContext) : IRequestHandler<CreateDietPlanCommand, int>
{
    public async Task<int> Handle(CreateDietPlanCommand request, CancellationToken cancellationToken)
    {

        var user = userContext.GetCurrentUser();

        var nutritionist = await nutritionistsRepository.GetByUserIdAsync(user!.Id);

        request.NutritionistId = nutritionist.Id;

        logger.LogInformation("Nutritionist {NutritionistId} is creating a new DietPlan for client with id {ClientId}: " +
            "{@DietPlan}", request.NutritionistId, request.ClientId, request);

        var dietPlan = mapper.Map<DietPlan>(request);

        int id = await dietPlansRepository.Create(dietPlan);

        return id;
    }
}
