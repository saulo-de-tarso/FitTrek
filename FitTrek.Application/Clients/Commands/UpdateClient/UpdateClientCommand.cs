using MediatR;
using System.Text.Json.Serialization;

namespace FitTrek.Application.Clients.Commands.UpdateClient;

public class UpdateClientCommand : IRequest
{
    [JsonIgnore]
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Gender { get; set; }
    public DateTime? DateOfBirth { get; set; }

    public int? HeightInCm { get; set; }
    public decimal? WeightInKg { get; set; }

    [JsonIgnore]
    public int NutritionistId { get; set; }

    public bool? IsActive { get; set; }
    public string? SubscriptionPlan { get; set; }
}
