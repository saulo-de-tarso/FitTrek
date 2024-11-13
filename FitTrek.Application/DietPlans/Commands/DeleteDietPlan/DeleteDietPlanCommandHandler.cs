using FitTrek.Application.Users;
using FitTrek.Domain.Entities;
using FitTrek.Domain.Exceptions;
using FitTrek.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FitTrek.Application.DietPlans.Commands.DeleteDietPlan;

public class DeleteDietPlanCommandHandler(ILogger<DeleteDietPlanCommandHandler> logger,
    INutritionistsRepository nutritionistsRepository,
    IDietPlansRepository dietPlansRepository,
    IUserContext userContext) : IRequestHandler<DeleteDietPlanCommand>
{

    public async Task Handle(DeleteDietPlanCommand request, CancellationToken cancellationToken)
    {

        var user = userContext.GetCurrentUser();

        var nutritionist = await nutritionistsRepository.GetByUserIdAsync(user!.Id);

        logger.LogWarning($"Removing diet plan with id {request.DietPlanId} of client {request.ClientId} for" +
            $" nutritionist with id {nutritionist.Id}");

        var client = nutritionist.Clients.FirstOrDefault(c => c.Id == request.ClientId)
            ?? throw new NotFoundException(nameof(Client), request.ClientId.ToString());

        var dietPlan = await dietPlansRepository.GetByIdAsync(request.DietPlanId);

        if(dietPlan == null || dietPlan.ClientId != request.ClientId)
            throw new NotFoundException(nameof(DietPlan), request.DietPlanId.ToString());

        await dietPlansRepository.DeleteById(dietPlan);

    }
}
