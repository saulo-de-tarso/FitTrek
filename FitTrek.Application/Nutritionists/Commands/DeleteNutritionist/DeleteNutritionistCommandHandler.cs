using FitTrek.Domain.Entities;
using FitTrek.Domain.Exceptions;
using FitTrek.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FitTrek.Application.Nutritionists.Commands.DeleteNutritionist;

public class DeleteNutritionistCommandHandler(ILogger<DeleteNutritionistCommandHandler> logger,
    INutritionistsRepository nutritionistsRepository) : IRequestHandler<DeleteNutritionistCommand>
{
    public async Task Handle(DeleteNutritionistCommand request, CancellationToken cancellationToken)
    {
        logger.LogWarning("Deleting nutritionist with id {NutritionistId}", request.Id);
        var nutritionist = await nutritionistsRepository.GetByIdAsync(request.Id);

        if (nutritionist is null)
            throw new NotFoundException(nameof(Nutritionist), request.Id.ToString());

        await nutritionistsRepository.Delete(nutritionist);
        
    }
}
