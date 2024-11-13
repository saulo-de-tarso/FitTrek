
using FitTrek.Domain.Entities;

namespace FitTrek.Domain.Repositories;

public interface IDietPlansRepository
{
    Task<int> Create(DietPlan entity);

    Task DeleteById(DietPlan entity);

    Task<DietPlan?> GetByIdAsync(int id);

    Task SaveChanges();


}
