using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitTrek.Application.Meals.Dtos;

public class MealDto
{
    public int Id { get; set; }
    public string MealType { get; set; } = default!;
    public string Description { get; set; } = default!;

    public int Calories { get; set; }
    public int Carbs { get; set; }
    public int Proteins { get; set; }
    public int Fats { get; set; }

    public DateTime CreatedAt { get; set; } = default!;
    public DateTime? UpdatedAt { get; set; }
}
