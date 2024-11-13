using AutoMapper;
using FitTrek.Application.DietPlans.Dtos;
using FitTrek.Application.Users;
using FitTrek.Domain.Entities;
using FitTrek.Domain.Exceptions;
using FitTrek.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FitTrek.Application.DietPlans.Queries.GetDietPlanById;

public class GetDietPlanByIdQueryHandler(ILogger<GetDietPlanByIdQueryHandler> logger,
    INutritionistsRepository nutritionistsRepository,
    IMapper mapper,
    IUserContext userContext) : IRequestHandler<GetDietPlanByIdQuery, DietPlanDto>
{

    public async Task<DietPlanDto> Handle(GetDietPlanByIdQuery request, CancellationToken cancellationToken)
    {
        var user = userContext.GetCurrentUser();

        var nutritionist = await nutritionistsRepository.GetByUserIdWithDietPlansAsync(user!.Id);

        logger.LogInformation($"Getting dietplan with id {request.Id} of client with id {request.Id} for nutritionist with id {nutritionist.Id}");

        var client = nutritionist.Clients.FirstOrDefault(c => c.Id == request.ClientId)
            ?? throw new NotFoundException(nameof(Client), request.ClientId.ToString());

        var dietPlan = nutritionist.DietPlans.FirstOrDefault(c => c.Id == request.Id)
            ?? throw new NotFoundException(nameof(DietPlan), request.Id.ToString());

        var result = mapper.Map<DietPlanDto>(dietPlan);

        return result;
    }
}
