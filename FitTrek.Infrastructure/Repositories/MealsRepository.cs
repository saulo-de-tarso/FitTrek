using Azure.Core;
using FitTrek.Domain.Entities;
using FitTrek.Domain.Exceptions;
using FitTrek.Domain.Repositories;
using FitTrek.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FitTrek.Infrastructure.Repositories;

internal class MealsRepository(FitTrekDbContext dbContext) : IMealsRepository
{
    public async Task<int> Create(Meal entity)
    {
        dbContext.Meals.Add(entity);
        await dbContext.SaveChangesAsync();
        return entity.Id;
    }


    public async Task DeleteById(Meal entity)
    {
        dbContext.Remove(entity);

        await dbContext.SaveChangesAsync();
    }


    public Task SaveChanges()
    => dbContext.SaveChangesAsync();

}
