using AutoMapper;
using FitTrek.Application.Clients.Dtos;
using FitTrek.Application.Common.Pagination;
using FitTrek.Application.Nutritionists.Dtos;
using FitTrek.Domain.Entities;
using FitTrek.Domain.Exceptions;
using FitTrek.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Xml.Linq;

namespace FitTrek.Application.Clients.Queries.GetClientsForNutritionist;

public class GetClientsForNutritionistQueryHandler(ILogger<GetClientsForNutritionistQueryHandler> logger, 
    INutritionistsRepository nutritionistsRepository,
    IMapper mapper) : IRequestHandler<GetClientsForNutritionistQuery, PagedResult<ClientDto>>
{
   
    public async Task<PagedResult<ClientDto>> Handle(GetClientsForNutritionistQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation(request.Name != null ? $"Getting all clients with name including: {request.Name} " +
            $"for nutritionist with id {request.NutritionistId}" : $"Getting all clients for nutritionist with id {request.NutritionistId}");
        
        var nutritionist = await nutritionistsRepository.GetByIdWithClientsAsync(request.NutritionistId)
            ?? throw new NotFoundException(nameof(Nutritionist), request.NutritionistId.ToString());

        var nameLower = request.Name?.ToLower();

        var clientQuery = nutritionist.Clients.Where(c => nameLower == null || c.FirstName.ToLower().Contains(nameLower)
                   || c.LastName.ToLower().Contains(nameLower)
                   || (c.FirstName + " " + c.LastName).ToLower().Contains(nameLower));

        var totalCount = clientQuery.Count();

        var clients = mapper.Map<IEnumerable<ClientDto>>(clientQuery)
            .Skip(request.PageSize * (request.PageNumber - 1))
            .Take(request.PageSize).
            ToList();

        var result = new PagedResult<ClientDto>(clients, totalCount, request.PageSize, request.PageNumber);

        return result;


    }

 


}
