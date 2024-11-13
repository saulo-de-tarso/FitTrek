using AutoMapper;
using FitTrek.Application.DietPlans.Dtos;
using FitTrek.Application.Common.Pagination;
using FitTrek.Application.Users;
using FitTrek.Domain.Entities;
using FitTrek.Domain.Enums;
using FitTrek.Domain.Exceptions;
using FitTrek.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace FitTrek.Application.DietPlans.Queries.GetDietPlans;

public class GetAllDietPlansQueryHandler(ILogger<GetAllDietPlansQueryHandler> logger,
    INutritionistsRepository nutritionistsRepository,
    IMapper mapper,
    IUserContext userContext) : IRequestHandler<GetAllDietPlansQuery, PagedResult<DietPlanDto>>
{

    public async Task<PagedResult<DietPlanDto>> Handle(GetAllDietPlansQuery request, CancellationToken cancellationToken)
    {
        var user = userContext.GetCurrentUser();

        var nutritionist = await nutritionistsRepository.GetByUserIdWithDietPlansAsync(user!.Id);

        logger.LogInformation($"Getting all dietplans of client {request.ClientId} for nutritionist with id {nutritionist.Id}");

        var client = nutritionist.Clients.FirstOrDefault(c => c.Id == request.ClientId)
            ?? throw new NotFoundException(nameof(Client), request.ClientId.ToString());

        var dietPlanQuery = client.DietPlans;

        var totalCount = dietPlanQuery.Count();


        var dietPlans = mapper.Map<IEnumerable<DietPlanDto>>(dietPlanQuery)
            .Skip(request.PageSize * (request.PageNumber - 1))
            .Take(request.PageSize).
            ToList();

        var result = new PagedResult<DietPlanDto>(dietPlans, totalCount, request.PageSize, request.PageNumber);

        return result;


    }




}
