using AutoMapper;
using FitTrek.Application.Nutritionists.Commands.CreateNutritionist;
using FitTrek.Application.Nutritionists.Commands.UpdateNutritionist;
using FitTrek.Domain.Entities;

namespace FitTrek.Application.Nutritionists.Dtos;

public class NutritionistsProfile : Profile
{
    public NutritionistsProfile()
    {
        CreateMap<CreateNutritionistCommand, Nutritionist>()
            .AfterMap((src, dest) =>
            {
                dest.CreatedAt = DateTime.Now;
            });

        CreateMap<Nutritionist, NutritionistDto>();


        CreateMap<UpdateNutritionistCommand, Nutritionist>()
            .AfterMap((src, dest) =>
            {
                dest.UpdatedAt = DateTime.Now;
            });

        
    }
}

