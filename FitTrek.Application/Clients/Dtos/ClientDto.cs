using FitTrek.Domain.Entities;

namespace FitTrek.Application.Clients.Dtos;

public class ClientDto
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
  
    public bool IsActive { get; set; } = true;
    public string SubscriptionPlan { get; set; } = default!;

    public DateTime CreatedAt { get; set; } = default!;
    public DateTime? UpdatedAt { get; set; }
}
