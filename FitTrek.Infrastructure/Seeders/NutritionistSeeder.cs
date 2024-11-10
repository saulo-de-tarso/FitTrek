using FitTrek.Domain.Entities;
using FitTrek.Infrastructure.Persistence;

namespace FitTrek.Infrastructure.Seeders;

internal class NutritionistSeeder(FitTrekDbContext dbContext) : INutritionistSeeder
{
    public async Task Seed()
    {
        if (await dbContext.Database.CanConnectAsync())
        {
            if (!dbContext.Nutritionists.Any())
            {
                var nutritionist = new Nutritionist()
                {
                    FirstName = "Luiz",
                    LastName = "Boça",
                    Email = "luizboca@fittrek.com",
                    PhoneNumber = "(11) 91111-1111",
                    DateOfBirth = new DateTime(1992, 9, 12),
                    CurrentMonthlyRevenue = 0,
                    CreatedAt = DateTime.Now,
                    Clients =
                    [
                        new ()
                        {
                            FirstName = "Gil",
                            LastName = "Brother",
                            Email = "gilbrother@fittrek.com",
                            PhoneNumber = "(21) 92111-1111",
                            Gender = "Male",
                            DateOfBirth = new DateTime(1957, 7, 29),
                            HeightInCm = 160,
                            WeightInKg = 65,
                            SubscriptionPlan = "Silver",
                            CreatedAt = DateTime.Now
                        }
                    ]
                };
                dbContext.Nutritionists.Add(nutritionist);
                await dbContext.SaveChangesAsync();
            }
        }
    }

     
}
