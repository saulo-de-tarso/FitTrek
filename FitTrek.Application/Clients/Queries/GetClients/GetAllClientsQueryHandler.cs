using AutoMapper;
using FitTrek.Application.Clients.Dtos;
using FitTrek.Application.Common.Pagination;
using FitTrek.Application.Users;
using FitTrek.Domain.Entities;
using FitTrek.Domain.Enums;
using FitTrek.Domain.Exceptions;
using FitTrek.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace FitTrek.Application.Clients.Queries.GetClients;

public class GetAllClientsQueryHandler(ILogger<GetAllClientsQueryHandler> logger,
    INutritionistsRepository nutritionistsRepository,
    IMapper mapper,
    IUserContext userContext) : IRequestHandler<GetAllClientsQuery, PagedResult<ClientDto>>
{

    public async Task<PagedResult<ClientDto>> Handle(GetAllClientsQuery request, CancellationToken cancellationToken)
    {
        var user = userContext.GetCurrentUser();

        var nutritionist = await nutritionistsRepository.GetByUserIdAsync(user!.Id);

        request.NutritionistId = nutritionist.Id;

        var nameLower = request.Name?.ToLower();

        logger.LogInformation(request.Name != null ? $"Getting all clients with name including: {request.Name} " +
            $"for nutritionist with id {request.NutritionistId}" : $"Getting all clients for nutritionist with id {request.NutritionistId}");


        var clientQuery = nutritionist.Clients.Where(c => nameLower == null || c.FirstName.ToLower().Contains(nameLower)
                   || c.LastName.ToLower().Contains(nameLower)
                   || (c.FirstName + " " + c.LastName).ToLower().Contains(nameLower));

        var totalCount = clientQuery.Count();

        var columnsSelector = new Dictionary<string, Func<Client, object>>
                {
                    { nameof(Client.FirstName), n => n.FirstName },
                    { nameof(Client.WeightInKg), n => n.WeightInKg },
                    { nameof(Client.HeightInCm), n => n.HeightInCm }
                };


        if (request.SortBy == ClientSortBy.FirstName)
        {
            if (request.SortDirection == SortDirection.Ascending)
                clientQuery = clientQuery.OrderBy(columnsSelector[nameof(Client.FirstName)]);
            if (request.SortDirection == SortDirection.Descending)
                clientQuery = clientQuery.OrderByDescending(columnsSelector[nameof(Client.FirstName)]);

        }

        if (request.SortBy == ClientSortBy.WeightInKg)
        {
            if (request.SortDirection == SortDirection.Ascending)
                clientQuery = clientQuery.OrderBy(columnsSelector[nameof(Client.WeightInKg)]);
            if (request.SortDirection == SortDirection.Descending)
                clientQuery = clientQuery.OrderByDescending(columnsSelector[nameof(Client.WeightInKg)]);

        }

        if (request.SortBy == ClientSortBy.HeightInCm)
        {
            if (request.SortDirection == SortDirection.Ascending)
                clientQuery = clientQuery.OrderBy(columnsSelector[nameof(Client.HeightInCm)]);
            if (request.SortDirection == SortDirection.Descending)
                clientQuery = clientQuery.OrderByDescending(columnsSelector[nameof(Client.HeightInCm)]);

        }

        var clients = mapper.Map<IEnumerable<ClientDto>>(clientQuery)
            .Skip(request.PageSize * (request.PageNumber - 1))
            .Take(request.PageSize).
            ToList();

        var result = new PagedResult<ClientDto>(clients, totalCount, request.PageSize, request.PageNumber);

        return result;


    }




}
