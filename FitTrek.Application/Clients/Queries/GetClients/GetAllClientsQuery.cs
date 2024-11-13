using FitTrek.Application.Clients.Dtos;
using FitTrek.Application.Common.Pagination;
using FitTrek.Domain.Enums;
using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Xml.Linq;

namespace FitTrek.Application.Clients.Queries.GetClients;

public class GetAllClientsQuery(string? name, 
    PaginationRequest paginationRequest, 
    ClientSortBy sortBy,
    SortDirection sortDirection) : IRequest<PagedResult<ClientDto>>
{
    public int NutritionistId { get; set; }
    public string? Name { get; set; } = name;
    public int PageSize { get; set; } = (int)paginationRequest.PageSize;
    public int PageNumber { get; set; } = paginationRequest.PageNumber;

    [EnumDataType(typeof(ClientSortBy), ErrorMessage = "SortBy must be by FirstName or WeightInKg or HeightInCm")]
    public ClientSortBy? SortBy { get; set; } = sortBy;

    [EnumDataType(typeof(SortDirection), ErrorMessage = "SortDirection must be Ascending or Descending")]
    public SortDirection? SortDirection { get; set; } = sortDirection;

}
