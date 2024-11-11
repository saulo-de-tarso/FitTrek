using FitTrek.Domain.Entities;
using FitTrek.Domain.Repositories;
using FitTrek.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FitTrek.Infrastructure.Repositories;

internal class NutritionistsRepository(FitTrekDbContext dbContext) : INutritionistsRepository
{
    public async Task<int> Create(Nutritionist entity)
    {
        dbContext.Nutritionists.Add(entity);
        await dbContext.SaveChangesAsync();
        return entity.Id;
    }

    public async Task Delete(Nutritionist entity)
    {
        dbContext.Remove(entity);
        await dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Nutritionist>> GetAllAsync()
    {
        var nutritionists = await dbContext.Nutritionists.
            Include(n => n.Clients)
            .ToListAsync();
        return nutritionists;
    }

    public async Task<Nutritionist?> GetByIdAsync(int id)
    {
        var nutritionist = await dbContext.Nutritionists.
            Include(n => n.Clients).
            FirstOrDefaultAsync(n => n.Id == id);

        return nutritionist;
    }

    public Task SaveChanges()
    => dbContext.SaveChangesAsync();
    
}
