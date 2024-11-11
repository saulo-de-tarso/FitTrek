using FitTrek.Application.Common.Pagination;
using FitTrek.Application.Nutritionists.Dtos;
using MediatR;

namespace FitTrek.Application.Nutritionists.Queries.GetNutritionists;

public class GetAllNutritionistsQuery(string? name, PaginationRequest paginationRequest) : IRequest<PagedResult<NutritionistDto>>
{
    public string? Name { get; set; } = name;
    public int PageSize { get; set; } = (int)paginationRequest.PageSize;
    public int PageNumber { get; set; } = paginationRequest.PageNumber;


}
