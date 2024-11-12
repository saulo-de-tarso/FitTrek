using FitTrek.Application.Clients.Dtos;
using FitTrek.Application.Common.Pagination;
using MediatR;
using System.Xml.Linq;

namespace FitTrek.Application.Clients.Queries.GetClientsForNutritionist;

public class GetClientsForNutritionistQuery(int nutritionistId, string? name, PaginationRequest paginationRequest) : IRequest<PagedResult<ClientDto>>
{
    public int NutritionistId { get; } = nutritionistId;
    public string? Name { get; set; } = name;
    public int PageSize { get; set; } = (int)paginationRequest.PageSize;
    public int PageNumber { get; set; } = paginationRequest.PageNumber;

}
