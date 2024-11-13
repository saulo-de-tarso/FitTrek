
using FitTrek.Domain.Entities;
using FitTrek.Domain.Enums;

namespace FitTrek.Domain.Repositories;

public interface INutritionistsRepository
{
    Task<int> Create(Nutritionist entity);
    Task Delete(Nutritionist entity);
    Task<IEnumerable<Nutritionist>> GetAllAsync();
    Task<(IEnumerable<Nutritionist>, int)> GetAllMatchingAsync(string? name, int pageSize, int pageNumber,
        NutritionistSortBy? sortBy, SortDirection? sortDirection);
    Task<Nutritionist?> GetByIdAsync(int id);
    Task<Nutritionist> GetByUserIdAsync(string userId);
    Task SaveChanges();


}
