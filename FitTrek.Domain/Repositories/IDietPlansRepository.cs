
using FitTrek.Domain.Entities;

namespace FitTrek.Domain.Repositories;

public interface IDietPlansRepository
{
    Task<int> Create(DietPlan entity);
    Task DeleteAll(IEnumerable<DietPlan> entities);
    Task DeleteById(DietPlan entity);

    Task<DietPlan?> GetByIdAsync(int id);

    Task SaveChanges();


}
