using FitTrek.Application.Nutritionists.Dtos;
using MediatR;

namespace FitTrek.Application.Nutritionists.Queries.GetNutritionistById;

public class GetNutritionistByIdQuery(int id) : IRequest<NutritionistDto>
{
    public int Id { get; } = id;
}
