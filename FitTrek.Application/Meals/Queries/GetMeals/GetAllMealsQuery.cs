using FitTrek.Application.Meals.Dtos;
using FitTrek.Application.Common.Pagination;
using FitTrek.Domain.Enums;
using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Xml.Linq;
using FitTrek.Application.Clients.Queries.GetClientById;

namespace FitTrek.Application.Meals.Queries.GetMeals;

public class GetAllMealsQuery(int dietPlanId) : IRequest<IEnumerable<MealDto>>
{
    public int DietPlanId { get; set; } = dietPlanId;

}
