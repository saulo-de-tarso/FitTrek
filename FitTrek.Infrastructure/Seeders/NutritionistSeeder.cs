using FitTrek.Application.Clients.Enums;
using FitTrek.Domain.Constants;
using FitTrek.Domain.Entities;
using FitTrek.Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;

namespace FitTrek.Infrastructure.Seeders;

internal class NutritionistSeeder(FitTrekDbContext dbContext) : INutritionistSeeder
{
    public async Task Seed()
    {
        if (await dbContext.Database.CanConnectAsync())
        {
            if (!dbContext.Nutritionists.Any())
            {
                var nutritionists = GetNutritionists();
                dbContext.Nutritionists.AddRange(nutritionists);
                await dbContext.SaveChangesAsync();
            }

            if (!dbContext.Roles.Any())
            {
                var roles = GetRoles();
                dbContext.Roles.AddRange(roles);
                await dbContext.SaveChangesAsync();
            }
        }
    }

    private IEnumerable<Nutritionist> GetNutritionists()
    {
      
        List<Nutritionist> nutritionists =
            [
                new()
                {
                    FirstName = "Luiz",
                    LastName = "Boça",
                    Email = "luizboca@fittrek.com",
                    PhoneNumber = "(11) 91111-1111",
                    DateOfBirth = new DateOnly(1992, 9, 12),
                    CurrentMonthlyRevenue = 150,
                    CreatedAt = DateTime.Now,
                    Clients =
                        [
                            new ()
                            {
                                FirstName = "Gil",
                                LastName = "Brother",
                                Email = "gilbrother@fittrek.com",
                                PhoneNumber = "(21) 92111-1111",
                                Gender = Gender.Male,
                                DateOfBirth = new DateOnly(1957, 7, 29),
                                HeightInCm = 160,
                                WeightInKg = 65,
                                SubscriptionPlan = SubscriptionPlan.Silver,
                                CreatedAt = DateTime.Now
                            }
                        ]
                }
            ];
        

        return nutritionists;
    }

    private IEnumerable<IdentityRole> GetRoles()
    {
        List<IdentityRole> roles =
            [
                new(UserRoles.Admin) {NormalizedName = UserRoles.Admin.ToUpper()},
                new(UserRoles.Nutritionist) {NormalizedName = UserRoles.Nutritionist.ToUpper()},
                new(UserRoles.Client) {NormalizedName = UserRoles.Client.ToUpper()}
            ];

        return roles;
    }

     
}
