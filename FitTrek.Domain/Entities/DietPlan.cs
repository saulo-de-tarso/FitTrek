namespace FitTrek.Domain.Entities;

public class DietPlan
{
    public int Id { get; set; }
    public string Goal { get; set; } = default!;
    public DateOnly StartDate { get; set; } = default!;
    public DateOnly EndDate { get; set; } = default!;

    public int ClientId { get; set; }
    public int NutritionistId { get; set; }

    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
