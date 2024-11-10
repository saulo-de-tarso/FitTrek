using FitTrek.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FitTrek.Application.Nutritionists.Commands.DeleteNutritionist;

public class DeleteNutritionistCommandHandler(ILogger<DeleteNutritionistCommandHandler> logger,
    INutritionistsRepository nutritionistsRepository) : IRequestHandler<DeleteNutritionistCommand, bool>
{
    public async Task<bool> Handle(DeleteNutritionistCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Deleting nutritionist with id {NutritionistId}", request.Id);
        var nutritionist = await nutritionistsRepository.GetByIdAsync(request.Id);

        if (nutritionist is null)
            return false;

        await nutritionistsRepository.Delete(nutritionist);
        return true;
    }
}
