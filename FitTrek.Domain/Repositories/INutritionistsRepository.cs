
using FitTrek.Domain.Entities;

namespace FitTrek.Domain.Repositories;

public interface INutritionistsRepository
{
    Task<int> Create(Nutritionist entity);
    Task Delete(Nutritionist entity);
    Task<IEnumerable<Nutritionist>> GetAllAsync();
    Task<Nutritionist?> GetByIdAsync(int id);
    Task SaveChanges();


}
