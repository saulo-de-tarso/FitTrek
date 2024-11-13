using FitTrek.Domain.Entities;
using FitTrek.Domain.Repositories;
using FitTrek.Infrastructure.Persistence;
using FitTrek.Infrastructure.Repositories;
using FitTrek.Infrastructure.Seeders;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FitTrek.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("FitTrekDb");
        services.AddDbContext<FitTrekDbContext>(options =>
            options.UseSqlServer(connectionString)
                .EnableSensitiveDataLogging());

        services.AddIdentityApiEndpoints<User>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<FitTrekDbContext>();

        services.AddScoped<IFitTrekSeeder, FitTrekSeeder>();
        services.AddScoped<INutritionistsRepository, NutritionistsRepository>();
        services.AddScoped<IClientsRepository, ClientsRepository>();
        services.AddScoped<IDietPlansRepository, DietPlansRepository>();
        services.AddScoped<IMealsRepository, MealsRepository>();


    }
}
