
using FitTrek.Domain.Entities;

namespace FitTrek.Domain.Repositories;

public interface INutritionistsRepository
{
    Task<IEnumerable<Nutritionist>> GetAsync();
    Task<Nutritionist?> GetByIdAsync(int id);
}
