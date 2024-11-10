using AutoMapper;
using FitTrek.Application.Nutritionists.Dtos;
using FitTrek.Domain.Entities;
using FitTrek.Domain.Repositories;
using Microsoft.Extensions.Logging;


namespace FitTrek.Application.Nutritionists;

internal class NutritionistsService(INutritionistsRepository nutritionistsRepository, 
    ILogger<NutritionistsService> logger,
    IMapper mapper) : INutritionistsService
{
    public async Task<int> Create(CreateNutritionistDto createNutritionistDto)
    {
        logger.LogInformation("Creating a new nutritionist");

        var nutritionist = mapper.Map<Nutritionist>(createNutritionistDto);

        nutritionist.CreatedAt = DateTime.Now;

        int id = await nutritionistsRepository.Create(nutritionist);

        return id;

    }

    public async Task<IEnumerable<NutritionistDto>> Get()
    {
        logger.LogInformation("Getting all nutritionists");
        var nutritionists = await nutritionistsRepository.GetAsync();

        var nutritionistsDto = mapper.Map<IEnumerable<NutritionistDto>>(nutritionists);

        return nutritionistsDto;

    }

    public async Task<NutritionistDto?> GetById(int id)
    {
        logger.LogInformation($"Getting nutritionist with id {id}");
        var nutritionist = await nutritionistsRepository.GetByIdAsync(id);

        var nutritionistDto = mapper.Map<NutritionistDto>(nutritionist);

        return nutritionistDto;
    }
}