using FitTrek.Domain.Entities;
using FitTrek.Domain.Repositories;
using FitTrek.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.Arm;

namespace FitTrek.Infrastructure.Repositories;

internal class DietPlansRepository(FitTrekDbContext dbContext) : IDietPlansRepository
{
    public async Task<int> Create(DietPlan entity)
    {
        dbContext.DietPlans.Add(entity);

        await dbContext.SaveChangesAsync();
        return entity.Id;
    }


    public async Task DeleteById(DietPlan entity)
    {
        dbContext.Remove(entity);
        await dbContext.SaveChangesAsync();
    }

    public async Task<DietPlan?> GetByIdAsync(int id)
    {
        var DietPlan = await dbContext.DietPlans.
            Include(dp => dp.Meals).
            FirstOrDefaultAsync(dp => dp.Id == id);

        return DietPlan;
    }

    public Task SaveChanges()
    => dbContext.SaveChangesAsync();

}
