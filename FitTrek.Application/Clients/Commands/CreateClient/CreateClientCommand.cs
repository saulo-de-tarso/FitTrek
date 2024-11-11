using MediatR;
using System.Text.Json.Serialization;

namespace FitTrek.Application.Clients.Commands.CreateClient;

public class CreateClientCommand : IRequest<int>
{
    
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;
    public string Gender { get; set; } = default!;
    public DateTime DateOfBirth { get; set; } = default!;

    public int HeightInCm { get; set; }
    public decimal WeightInKg { get; set; }

    [JsonIgnore]
    public int NutritionistId { get; set; }
    public bool IsActive { get; set; } = true;
    public string SubscriptionPlan { get; set; } = default!;
}
