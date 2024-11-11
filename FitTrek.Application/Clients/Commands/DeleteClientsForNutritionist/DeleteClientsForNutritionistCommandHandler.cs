using FitTrek.Application.Clients.Commands.DeleteClientsForNutritionist;
using FitTrek.Domain.Entities;
using FitTrek.Domain.Exceptions;
using FitTrek.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FitTrek.Application.Clients.Commands.GetClientsForNutritionist;

public class DeleteClientsForNutritionistCommandHandler(ILogger<DeleteClientsForNutritionistCommandHandler> logger,
    INutritionistsRepository nutritionistsRepository,
    IClientsRepository clientsRepository) : IRequestHandler<DeleteClientsForNutritionistCommand>
{

    public async Task Handle(DeleteClientsForNutritionistCommand request, CancellationToken cancellationToken)
    {
        logger.LogWarning($"Removing all clients for nutritionist with id {request.NutritionistId}");

        var nutritionist = await nutritionistsRepository.GetByIdAsync(request.NutritionistId)
            ?? throw new NotFoundException(nameof(Nutritionist), request.NutritionistId.ToString());

        await clientsRepository.DeleteAll(nutritionist.Clients);

    }
}
