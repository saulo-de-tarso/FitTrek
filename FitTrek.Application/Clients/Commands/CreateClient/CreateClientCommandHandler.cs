using AutoMapper;
using FitTrek.Domain.Entities;
using FitTrek.Domain.Exceptions;
using FitTrek.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FitTrek.Application.Clients.Commands.CreateClient;

public class CreateClientCommandHandler(ILogger<CreateClientCommandHandler> logger,
    IMapper mapper,
    INutritionistsRepository nutritionistsRepository,
    IClientsRepository clientsRepository) : IRequestHandler<CreateClientCommand, int>
{
    public async Task<int> Handle(CreateClientCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating a new client for nutritionist with id {NutritionistId}: {@Client}", request.NutritionistId, request);

        var nutritionist = await nutritionistsRepository.GetByIdAsync(request.NutritionistId)
            ?? throw new NotFoundException(nameof(Nutritionist), request.NutritionistId.ToString());

        var client = mapper.Map<Client>(request);

        int id = await clientsRepository.Create(client);

        return id;
    }
}
