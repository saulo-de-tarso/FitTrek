using FitTrek.Application.Users;
using FitTrek.Domain.Entities;
using FitTrek.Domain.Exceptions;
using FitTrek.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FitTrek.Application.Clients.Commands.DeleteClient;

public class DeleteClientCommandHandler(ILogger<DeleteClientCommandHandler> logger,
    INutritionistsRepository nutritionistsRepository,
    IClientsRepository clientsRepository,
    IUserContext userContext) : IRequestHandler<DeleteClientCommand>
{

    public async Task Handle(DeleteClientCommand request, CancellationToken cancellationToken)
    {
               
        var user = userContext.GetCurrentUser();

        var nutritionist = await nutritionistsRepository.GetByUserIdAsync(user!.Id);

        logger.LogWarning($"Removing client with id {request.ClientId} for nutritionist with id {nutritionist.Id}");

        var client = nutritionist.Clients.FirstOrDefault(c => c.Id == request.ClientId)
            ?? throw new NotFoundException(nameof(Client), request.ClientId.ToString());

        await clientsRepository.DeleteById(client);

    }
}
