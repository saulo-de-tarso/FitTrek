using FitTrek.Application.Common.Pagination;
using FitTrek.Application.DietPlans.Dtos;
using MediatR;

namespace FitTrek.Application.DietPlans.Queries.GetDietPlans;

public class GetAllDietPlansQuery(int clientId, PaginationRequest paginationRequest) : IRequest<PagedResult<DietPlanDto>>
{
    public int ClientId { get; set; } = clientId;
    public int PageSize { get; set; } = (int)paginationRequest.PageSize;
    public int PageNumber { get; set; } = paginationRequest.PageNumber;

}
