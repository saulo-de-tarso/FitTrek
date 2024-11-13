using AutoMapper;
using FitTrek.Application.Clients.Dtos;
using FitTrek.Application.Users;
using FitTrek.Domain.Entities;
using FitTrek.Domain.Exceptions;
using FitTrek.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FitTrek.Application.Clients.Queries.GetClientById;

public class GetClientByIdQueryHandler(ILogger<GetClientByIdQueryHandler> logger,
    INutritionistsRepository nutritionistsRepository,
    IMapper mapper,
    IUserContext userContext) : IRequestHandler<GetClientByIdQuery, ClientDto>
{

    public async Task<ClientDto> Handle(GetClientByIdQuery request, CancellationToken cancellationToken)
    {
        var user = userContext.GetCurrentUser();

        var nutritionist = await nutritionistsRepository.GetByUserIdAsync(user!.Id);

        logger.LogInformation($"Getting client with id {request.Id} for nutritionist with id {nutritionist.Id}");
   
        var client = nutritionist.Clients.FirstOrDefault(c => c.Id == request.Id) 
            ?? throw new NotFoundException(nameof(Client), request.Id.ToString());

        var result = mapper.Map<ClientDto>(client);

        return result;
    }
}
