using AutoMapper;
using FitTrek.Application.Clients.Dtos;
using FitTrek.Domain.Entities;
using FitTrek.Domain.Exceptions;
using FitTrek.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FitTrek.Application.Clients.Queries.GetClientByIdForNutritionist;

public class GetClientByIdForNutritionistQueryHandler(ILogger<GetClientByIdForNutritionistQueryHandler> logger,
    INutritionistsRepository nutritionistsRepository,
    IMapper mapper) : IRequestHandler<GetClientByIdForNutritionistQuery, ClientDto>
{

    public async Task<ClientDto> Handle(GetClientByIdForNutritionistQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Getting client with id {request.Id} for nutritionist with id {request.NutritionistId}");

        var nutritionist = await nutritionistsRepository.GetByIdWithClientsAsync(request.NutritionistId)
            ?? throw new NotFoundException(nameof(Nutritionist), request.NutritionistId.ToString());

        var client = nutritionist.Clients.FirstOrDefault(c => c.Id == request.Id) 
            ?? throw new NotFoundException(nameof(Client), request.Id.ToString());

        var result = mapper.Map<ClientDto>(client);

        return result;
    }
}
