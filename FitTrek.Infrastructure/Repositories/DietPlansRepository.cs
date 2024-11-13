using FitTrek.Domain.Entities;
using FitTrek.Domain.Repositories;
using FitTrek.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FitTrek.Infrastructure.Repositories;

internal class DietPlansRepository(FitTrekDbContext dbContext) : IDietPlansRepository
{
    public async Task<int> Create(DietPlan entity)
    {
        dbContext.DietPlans.Add(entity);

        await dbContext.SaveChangesAsync();
        return entity.Id;
    }

    public async Task DeleteAll(IEnumerable<DietPlan> entities)
    {
        dbContext.RemoveRange(entities);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteById(DietPlan entity)
    {
        dbContext.Remove(entity);
        await dbContext.SaveChangesAsync();
    }

    public async Task<DietPlan?> GetByIdAsync(int id)
    {
        var DietPlan = await dbContext.DietPlans.
            FirstOrDefaultAsync(n => n.Id == id);

        return DietPlan;
    }

    public Task SaveChanges()
    => dbContext.SaveChangesAsync();

}
