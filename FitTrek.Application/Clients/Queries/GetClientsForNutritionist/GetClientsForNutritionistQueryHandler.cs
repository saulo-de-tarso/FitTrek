using AutoMapper;
using FitTrek.Application.Clients.Dtos;
using FitTrek.Domain.Entities;
using FitTrek.Domain.Exceptions;
using FitTrek.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FitTrek.Application.Clients.Queries.GetClientsForNutritionist;

public class GetClientsForNutritionistQueryHandler(ILogger<GetClientsForNutritionistQueryHandler> logger, 
    INutritionistsRepository nutritionistsRepository,
    IMapper mapper) : IRequestHandler<GetClientsForNutritionistQuery, IEnumerable<ClientDto>>
{
   
    public async Task<IEnumerable<ClientDto>> Handle(GetClientsForNutritionistQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Getting all clients for nutritionist with id {request.NutritionistId}");
        
        var nutritionist = await nutritionistsRepository.GetByIdAsync(request.NutritionistId)
            ?? throw new NotFoundException(nameof(Nutritionist), request.NutritionistId.ToString());

        var clients = mapper.Map<IEnumerable<ClientDto>>(nutritionist.Clients);

        return clients;
    }
}
