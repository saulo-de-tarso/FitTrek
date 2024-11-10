using FitTrek.Domain.Entities;

namespace FitTrek.Application.Nutritionists
{
    public interface INutritionistsService
    {
        Task<IEnumerable<Nutritionist>> Get();
    }
}