using AutoMapper;
using FitTrek.Application.Meals.Commands.CreateMeal;
using FitTrek.Application.Meals.Commands.UpdateMeal;

//using FitTrek.Application.Meals.Commands.UpdateMeal;
using FitTrek.Domain.Entities;

namespace FitTrek.Application.Meals.Dtos;

public class MealsProfile : Profile
{
    public MealsProfile()
    {
        CreateMap<CreateMealCommand, Meal>()
        .AfterMap((src, dest) =>
        {
            dest.CreatedAt = DateTime.Now;
        });

        CreateMap<Meal, MealDto>();

        CreateMap<UpdateMealCommand, Meal>()
        .AfterMap((src, dest) =>
        {
            dest.UpdatedAt = DateTime.Now;
        });

    }

}
