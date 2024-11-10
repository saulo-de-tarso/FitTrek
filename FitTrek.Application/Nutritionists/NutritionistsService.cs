using FitTrek.Domain.Entities;
using FitTrek.Domain.Repositories;
using Microsoft.Extensions.Logging;


namespace FitTrek.Application.Nutritionists;

internal class NutritionistsService(INutritionistsRepository nutritionistsRepository, ILogger<NutritionistsService> logger) : INutritionistsService
{
    public async Task<IEnumerable<Nutritionist>> Get()
    {
        logger.LogInformation("Getting all nutritionists");
        var nutritionists = await nutritionistsRepository.GetAsync();
        return nutritionists;

    }
}