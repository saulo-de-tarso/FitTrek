using FitTrek.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FitTrek.Infrastructure.Seeders;
using FitTrek.Domain.Repositories;
using FitTrek.Infrastructure.Repositories;
using FitTrek.Domain.Entities;
using Microsoft.AspNetCore.Identity;

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

        services.AddScoped<INutritionistSeeder, NutritionistSeeder>();
        services.AddScoped<INutritionistsRepository, NutritionistsRepository>();
        services.AddScoped<IClientsRepository, ClientsRepository>();
    }
}
