using FitTrek.Application.Common.Pagination;
using FitTrek.Application.Nutritionists.Dtos;
using FitTrek.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace FitTrek.Application.Nutritionists.Queries.GetNutritionists;

public class GetAllNutritionistsQuery(string? name,
    PaginationRequest paginationRequest,
    NutritionistSortBy sortBy,
    SortDirection sortDirection) : IRequest<PagedResult<NutritionistDto>>
{
    public string? Name { get; set; } = name;
    public int PageSize { get; set; } = (int)paginationRequest.PageSize;
    public int PageNumber { get; set; } = paginationRequest.PageNumber;
    
    [EnumDataType(typeof(NutritionistSortBy), ErrorMessage = "SortBy must be by FirstName or CurrentMonthlyRevenue")]
    public NutritionistSortBy? SortBy { get; set; } = sortBy;
    
    [EnumDataType(typeof(SortDirection), ErrorMessage = "SortDirection must be Ascending or Descending")]
    public SortDirection? SortDirection { get; set; } = sortDirection;


}
