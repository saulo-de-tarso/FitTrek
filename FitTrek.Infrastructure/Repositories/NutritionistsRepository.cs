using FitTrek.Domain.Entities;
using FitTrek.Domain.Repositories;
using FitTrek.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FitTrek.Infrastructure.Repositories;

internal class NutritionistsRepository(FitTrekDbContext dbContext) : INutritionistsRepository
{
    public async Task<int> Create(Nutritionist nutritionist)
    {
        dbContext.Nutritionists.Add(nutritionist);
        await dbContext.SaveChangesAsync();
        return nutritionist.Id;
    }

    public async Task<IEnumerable<Nutritionist>> GetAsync()
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
}
