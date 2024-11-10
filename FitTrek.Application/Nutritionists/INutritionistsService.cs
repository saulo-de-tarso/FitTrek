using FitTrek.Application.Nutritionists.Dtos;

namespace FitTrek.Application.Nutritionists
{
    public interface INutritionistsService
    {
        Task<IEnumerable<NutritionistDto>> Get();
        Task<NutritionistDto> GetById(int id);
    }
}