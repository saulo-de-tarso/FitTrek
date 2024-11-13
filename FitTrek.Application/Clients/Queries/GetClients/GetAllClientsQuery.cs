using FitTrek.Application.Clients.Dtos;
using FitTrek.Application.Common.Pagination;
using MediatR;
using System.Xml.Linq;

namespace FitTrek.Application.Clients.Queries.GetClients;

public class GetAllClientsQuery(string? name, PaginationRequest paginationRequest) : IRequest<PagedResult<ClientDto>>
{
    public int NutritionistId { get; set; }
    public string? Name { get; set; } = name;
    public int PageSize { get; set; } = (int)paginationRequest.PageSize;
    public int PageNumber { get; set; } = paginationRequest.PageNumber;

}
