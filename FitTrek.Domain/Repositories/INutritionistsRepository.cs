
using FitTrek.Domain.Entities;

namespace FitTrek.Domain.Repositories;

public interface INutritionistsRepository
{
    Task<int> Create(Nutritionist entity);
    Task Delete(Nutritionist entity);
    Task<IEnumerable<Nutritionist>> GetAllAsync();
    Task<(IEnumerable<Nutritionist>, int)> GetAllMatchingNamesAsync(string? name, int pageSize, int pageNumber);
    Task<Nutritionist?> GetByIdAsync(int id);
    Task SaveChanges();


}
