using AutoMapper;
using FitTrek.Application.Nutritionists.Dtos;
using FitTrek.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FitTrek.Application.Nutritionists.Queries.GetNutritionistById;

public class GetNutritionistByIdQueryHandler(ILogger<GetNutritionistByIdQueryHandler> logger,
    IMapper mapper,
    INutritionistsRepository nutritionistsRepository) : IRequestHandler<GetNutritionistByIdQuery, NutritionistDto?>
{

    public async Task<NutritionistDto?> Handle(GetNutritionistByIdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Getting restaurant with id {request.Id}");
        var nutritionist = await nutritionistsRepository.GetByIdAsync(request.Id);

        var nutritionistDto = mapper.Map<NutritionistDto?>(nutritionist);

        return nutritionistDto;
    }
}
