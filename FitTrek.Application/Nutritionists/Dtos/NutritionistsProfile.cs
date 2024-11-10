using AutoMapper;

using FitTrek.Domain.Entities;
using System.Xml.Serialization;

namespace FitTrek.Application.Nutritionists.Dtos;

public class NutritionistsProfile : Profile
{
    public NutritionistsProfile()
    {
        CreateMap<CreateNutritionistDto, Nutritionist>()
            .AfterMap((src, dest) =>
            {
                dest.CreatedAt = DateTime.Now;
            });

        CreateMap<Nutritionist, NutritionistDto>();
    }
}

