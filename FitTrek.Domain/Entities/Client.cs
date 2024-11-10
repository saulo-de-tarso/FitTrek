namespace FitTrek.Domain.Entities;

public class Client
{
    public int Id { get; set; }
    
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;
    public string Gender { get; set; } = default!;
    public DateTime DateOfBirth { get; set; } = default!;

    public int HeightInCm { get; set; }
    public decimal WeightInKg { get; set; }

    public int NutritionistId { get; set; }
    public bool IsActive { get; set; } = true;
    public string SubscriptionPlan { get; set; } = default!;

    public List<DietPlan> DietPlans { get; set; } = new();
    public List<ClientStats> ClientStats { get; set; } = new();
    public List<ProgressNotes> ProgressNotes { get; set; } = new();

    public DateTime CreatedAt { get; set; } = default!;
    public DateTime? UpdatedAt { get; set; }

}
