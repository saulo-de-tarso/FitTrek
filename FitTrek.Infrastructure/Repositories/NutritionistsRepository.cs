using FitTrek.Domain.Entities;
using FitTrek.Domain.Repositories;
using FitTrek.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FitTrek.Infrastructure.Repositories;

internal class NutritionistsRepository(FitTrekDbContext dbContext) : INutritionistsRepository
{
    public async Task<IEnumerable<Nutritionist>> GetAsync()
    {
        var nutritionists = await dbContext.Nutritionists.ToListAsync();
        return nutritionists;
    }
}
