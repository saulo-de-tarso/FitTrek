using FitTrek.Application.Users;
using FitTrek.Domain.Entities;
using FitTrek.Domain.Enums;
using FitTrek.Domain.Repositories;
using FitTrek.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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

    public async Task<(IEnumerable<Nutritionist>, int)> GetAllMatchingAsync(string? name,
        int pageSize,
        int pageNumber,
        NutritionistSortBy? sortBy,
        SortDirection? sortDirection)
    {
        var nameLower = name?.ToLower();

        var baseQuery = dbContext.Nutritionists.
            Where(n => nameLower == null || n.FirstName.ToLower().Contains(nameLower)
                    || n.LastName.ToLower().Contains(nameLower)
                    || (n.FirstName + " " + n.LastName).ToLower().Contains(nameLower));

        var totalCount = await baseQuery.CountAsync();

        var columnsSelector = new Dictionary<string, Expression<Func<Nutritionist, object>>>
                {
                    { nameof(Nutritionist.FirstName), n => n.FirstName },
                    { nameof(Nutritionist.CurrentMonthlyRevenue), n => n.CurrentMonthlyRevenue }
                };


        if (sortBy == NutritionistSortBy.FirstName)
        {
            if (sortDirection == SortDirection.Ascending)
                baseQuery = baseQuery.OrderBy(columnsSelector[nameof(Nutritionist.FirstName)]);
            if (sortDirection == SortDirection.Descending)
                baseQuery = baseQuery.OrderByDescending(columnsSelector[nameof(Nutritionist.CurrentMonthlyRevenue)]);

        }

        if (sortBy == NutritionistSortBy.CurrentMonthlyRevenue)
        {
            if (sortDirection == SortDirection.Ascending)
                baseQuery = baseQuery.OrderBy(columnsSelector[nameof(Nutritionist.FirstName)]);
            if (sortDirection == SortDirection.Descending)
                baseQuery = baseQuery.OrderByDescending(columnsSelector[nameof(Nutritionist.CurrentMonthlyRevenue)]);

        }





        var nutritionists = await baseQuery
            .Skip(pageSize * (pageNumber - 1))
            .Take(pageSize)
            .ToListAsync();


        return (nutritionists, totalCount);
    }

    public async Task<Nutritionist?> GetByIdAsync(int id)
    {
        var nutritionist = await dbContext.Nutritionists.
            FirstOrDefaultAsync(n => n.Id == id);

        return nutritionist;
    }


    public async Task<Nutritionist> GetByUserIdAsync(string userId)
    {

        var nutritionist = await dbContext.Nutritionists.
            Include(n => n.Clients).
            FirstOrDefaultAsync(n => n.UserId == userId);

        return nutritionist!;
    }

    public Task SaveChanges()
    => dbContext.SaveChangesAsync();

}
