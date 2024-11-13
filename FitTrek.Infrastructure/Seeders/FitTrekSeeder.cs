using FitTrek.Application.Clients.Enums;
using FitTrek.Domain.Constants;
using FitTrek.Domain.Entities;
using FitTrek.Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace FitTrek.Infrastructure.Seeders;

internal class FitTrekSeeder(FitTrekDbContext dbContext, 
    UserManager<User> userManager,
    IConfiguration configuration) : IFitTrekSeeder
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

            //seeding an admin
            var email = configuration["AdminUser:Email"];
            var user = await userManager.FindByEmailAsync(email);
            
            var password = configuration["AdminUser:Password"];

            if (user == null)
            {
                user = new User { Email = email };

                var result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                    await userManager.AddToRoleAsync(user, UserRoles.Admin);
            }
            else
            {
                var roles = await userManager.GetRolesAsync(user);
                if (!roles.Contains(UserRoles.Admin))
                    await userManager.AddToRoleAsync(user, UserRoles.Admin);

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

    private static async Task SeedAdminUser(UserManager<User> userManager)
    {
        var email = "admin@fittrek.com";
        var user = await userManager.FindByEmailAsync(email);

        
        var password = Environment.GetEnvironmentVariable("ADMIN_PASSWORD");

        if (user == null)
        {


            user = new User { Email = email };

            var result = await userManager.CreateAsync(user, password);
            if (result.Succeeded)
                await userManager.AddToRoleAsync(user, UserRoles.Admin);
        }
        else
        {
            var roles = await userManager.GetRolesAsync(user);
            if (!roles.Contains(UserRoles.Admin))
                await userManager.AddToRoleAsync(user, UserRoles.Admin);
            
        }
    }



}
