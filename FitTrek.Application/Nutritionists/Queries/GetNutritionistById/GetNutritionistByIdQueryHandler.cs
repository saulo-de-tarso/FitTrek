using AutoMapper;
using FitTrek.Application.Clients.Dtos;
using FitTrek.Application.Common.Pagination;
using FitTrek.Application.Nutritionists.Dtos;
using FitTrek.Domain.Entities;
using FitTrek.Domain.Exceptions;
using FitTrek.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FitTrek.Application.Nutritionists.Queries.GetNutritionistById;

public class GetNutritionistByIdQueryHandler(ILogger<GetNutritionistByIdQueryHandler> logger,
    IMapper mapper,
    INutritionistsRepository nutritionistsRepository) : IRequestHandler<GetNutritionistByIdQuery, NutritionistDto?>
{

    public async Task<NutritionistDto> Handle(GetNutritionistByIdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting nutritionist with id {NutritionistId}", request.Id);
        var nutritionist = await nutritionistsRepository.GetByIdAsync(request.Id) 
            ?? throw new NotFoundException(nameof(Nutritionist), request.Id.ToString());
      

        var nutritionistDto = mapper.Map<NutritionistDto>(nutritionist);

        return nutritionistDto;

    }
}
