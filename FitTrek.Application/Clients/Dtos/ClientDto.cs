using FitTrek.Application.Clients.Enums;
using FitTrek.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace FitTrek.Application.Clients.Dtos;

public class ClientDto
{
    public int Id { get; set; }

    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;
    [EnumDataType(typeof(Gender))]
    public Gender Gender { get; set; } = default!;
    public DateOnly DateOfBirth { get; set; } = default!;

    public int HeightInCm { get; set; }
    public decimal WeightInKg { get; set; }
  
    [EnumDataType(typeof(SubscriptionPlan))]
    public SubscriptionPlan SubscriptionPlan { get; set; } = default!;

    public DateTime CreatedAt { get; set; } = default!;
    public DateTime? UpdatedAt { get; set; }
}
