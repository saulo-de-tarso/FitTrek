using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitTrek.Application.DietPlans.Dtos;

public class DietPlanDto
{
    public int Id { get; set; }
    public string Goal { get; set; } = default!;
    public DateOnly StartDate { get; set; } = default!;
    public DateOnly EndDate { get; set; } = default!;

    public int Calories { get; set; } = default!;

    public DateTime CreatedAt { get; set; } = default!;
    public DateTime? UpdatedAt { get; set; }
}
