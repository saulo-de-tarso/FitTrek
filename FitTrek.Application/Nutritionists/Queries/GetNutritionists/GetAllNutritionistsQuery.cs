using FitTrek.Application.Nutritionists.Dtos;
using MediatR;

namespace FitTrek.Application.Nutritionists.Queries.GetNutritionists;

public class GetAllNutritionistsQuery : IRequest<IEnumerable<NutritionistDto>>
{
    
}
