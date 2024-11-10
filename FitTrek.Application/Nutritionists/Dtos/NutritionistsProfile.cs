using AutoMapper;

using FitTrek.Domain.Entities;

namespace FitTrek.Application.Nutritionists.Dtos;

public class NutritionistsProfile : Profile
{
    public NutritionistsProfile()
    {
        CreateMap<Nutritionist, NutritionistDto>();
    }
}

