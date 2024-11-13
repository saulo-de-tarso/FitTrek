using AutoMapper;
using FitTrek.Application.DietPlans.Commands.CreateDietPlan;
using FitTrek.Application.DietPlans.Commands.UpdateDietPlan;
using FitTrek.Domain.Entities;

namespace FitTrek.Application.DietPlans.Dtos;

public class DietPlansProfile : Profile
{
    public DietPlansProfile()
    {
        CreateMap<CreateDietPlanCommand, DietPlan>()
        .AfterMap((src, dest) =>
        {
            dest.CreatedAt = DateTime.Now;
        });

        CreateMap<DietPlan, DietPlanDto>();


        CreateMap<UpdateDietPlanCommand, DietPlan>()
        .AfterMap((src, dest) =>
        {
            dest.UpdatedAt = DateTime.Now;
        });

    }

}
