﻿using FitTrek.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FitTrek.Infrastructure.Seeders;

namespace FitTrek.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("FitTrekDb");
        services.AddDbContext<FitTrekDbContext>(options => options.UseSqlServer(connectionString));

        services.AddScoped<INutritionistSeeder, NutritionistSeeder>();
    }
}
