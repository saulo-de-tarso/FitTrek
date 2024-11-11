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

    public async Task<(IEnumerable<Nutritionist>, int)> GetAllMatchingNamesAsync(string? name, int pageSize, int pageNumber)
    {
        var nameLower = name?.ToLower();

        var baseQuery = dbContext.Nutritionists.
            Where(n => nameLower == null || n.FirstName.ToLower().Contains(nameLower)
                    || n.LastName.ToLower().Contains(nameLower)
                    || (n.FirstName + " " + n.LastName).ToLower().Contains(nameLower));

        var totalCount = await baseQuery.CountAsync();

        var nutritionists = await baseQuery
            .Skip(pageSize * (pageNumber - 1))
            .Take(pageSize)
            .Include(n => n.Clients)
            .ToListAsync();
            
            
        return (nutritionists, totalCount);
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
