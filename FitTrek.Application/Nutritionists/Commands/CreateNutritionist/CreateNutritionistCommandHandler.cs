using AutoMapper;
using FitTrek.Domain.Entities;
using FitTrek.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FitTrek.Application.Nutritionists.Commands.CreateNutritionist;

public class CreateNutritionistCommandHandler(ILogger<CreateNutritionistCommandHandler> logger,
    IMapper mapper,
    INutritionistsRepository nutritionistsRepository) : IRequestHandler<CreateNutritionistCommand, int>
{
    public async Task<int> Handle(CreateNutritionistCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating a new nutritionist: {@Nutritionist}", request);

        var nutritionist = mapper.Map<Nutritionist>(request);
                
        int id = await nutritionistsRepository.Create(nutritionist);

        return id;
    }
}
