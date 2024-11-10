using FitTrek.Application.Nutritionists;
using FitTrek.Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FitTrek.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<INutritionistsService, NutritionistsService>();
    }
}
