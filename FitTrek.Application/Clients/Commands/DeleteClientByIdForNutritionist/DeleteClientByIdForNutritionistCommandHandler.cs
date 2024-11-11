using FitTrek.Domain.Entities;
using FitTrek.Domain.Exceptions;
using FitTrek.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FitTrek.Application.Clients.Commands.DeleteClientByIdForNutritionist;

public class DeleteClientByIdForNutritionistCommandHandler(ILogger<DeleteClientByIdForNutritionistCommandHandler> logger,
    INutritionistsRepository nutritionistsRepository,
    IClientsRepository clientsRepository) : IRequestHandler<DeleteClientByIdForNutritionistCommand>
{

    public async Task Handle(DeleteClientByIdForNutritionistCommand request, CancellationToken cancellationToken)
    {
        logger.LogWarning($"Removing client with id {request.ClientId} for nutritionist with id {request.NutritionistId}");

        var nutritionist = await nutritionistsRepository.GetByIdAsync(request.NutritionistId)
            ?? throw new NotFoundException(nameof(Nutritionist), request.NutritionistId.ToString());

        var client = nutritionist.Clients.FirstOrDefault(c => c.Id == request.ClientId)
            ?? throw new NotFoundException(nameof(Client), request.ClientId.ToString());

        await clientsRepository.DeleteById(client);

    }
}
