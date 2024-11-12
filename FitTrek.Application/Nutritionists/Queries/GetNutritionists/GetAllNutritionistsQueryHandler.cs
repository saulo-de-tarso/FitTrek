using AutoMapper;
using FitTrek.Application.Common.Pagination;
using FitTrek.Application.Nutritionists.Dtos;
using FitTrek.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FitTrek.Application.Nutritionists.Queries.GetNutritionists;

public class GetAllNutritionistsQueryHandler(ILogger<GetAllNutritionistsQueryHandler> logger,
    IMapper mapper,
    INutritionistsRepository nutritionistsRepository) : IRequestHandler<GetAllNutritionistsQuery, PagedResult<NutritionistDto>>
{

    public async Task<PagedResult<NutritionistDto>> Handle(GetAllNutritionistsQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation(request.Name != null ? $"Getting all nutritionists with name including: {request.Name}"
            : $"Getting all nutritionists");
        var (nutritionists, totalCount) = await nutritionistsRepository.GetAllMatchingNamesAsync(request.Name,
            request.PageSize,
            request.PageNumber);

        var nutritionistsDto = mapper.Map<IEnumerable<NutritionistDto>>(nutritionists);

        var result = new PagedResult<NutritionistDto>(nutritionistsDto, totalCount, request.PageSize, request.PageNumber);

        return result;
    }
}
