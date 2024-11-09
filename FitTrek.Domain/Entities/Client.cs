namespace FitTrek.Domain.Entities;

public class Client
{
    public int Id { get; set; }
    
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;
    public string Gender { get; set; } = default!;
    public DateOnly DateOfBirth { get; set; }
    
    public int HeightInCm { get; set; } = default!;
    public decimal WeightInKg { get; set; } = default!;

    public int NutritionistId { get; set; }
    public bool IsActive { get; set; }
    public string SubscriptionPlan { get; set; } = default!;

    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

}
