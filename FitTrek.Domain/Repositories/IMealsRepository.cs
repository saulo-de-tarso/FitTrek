
using FitTrek.Domain.Entities;

namespace FitTrek.Domain.Repositories;

public interface IMealsRepository
{
    Task<int> Create(Meal entity);

    Task DeleteById(Meal entity);

    Task SaveChanges();


}
