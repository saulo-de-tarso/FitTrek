using AutoMapper;
using FitTrek.Application.Nutritionists.Dtos;
using FitTrek.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FitTrek.Application.Nutritionists.Queries.GetNutritionists;

public class GetAllNutritionistsQueryHandler(ILogger<GetAllNutritionistsQueryHandler> logger,
    IMapper mapper,
    INutritionistsRepository nutritionistsRepository) : IRequestHandler<GetAllNutritionistsQuery, IEnumerable<NutritionistDto>>
{

    public async Task<IEnumerable<NutritionistDto>> Handle(GetAllNutritionistsQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Getting all nutritionists");
        var nutritionists = await nutritionistsRepository.GetAllAsync();

        var nutritionistsDto = mapper.Map<IEnumerable<NutritionistDto>>(nutritionists);

        return nutritionistsDto;
    }
}
