using FitTrek.Application.Clients.Enums;
using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FitTrek.Application.Clients.Commands.UpdateClient;

public class UpdateClientCommand : IRequest
{
    [JsonIgnore]
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    [EmailAddress(ErrorMessage = "Please provide a valid email address.")]
    public string? Email { get; set; }
    [RegularExpression(@"^\([1-9]{2}\) 9[0-9]{4}-[0-9]{4}$",
        ErrorMessage = "The phone number must be in the format (XX) 9XXXX-XXXX. DDD can't have zeroes in it.")]
    public string? PhoneNumber { get; set; }
    [EnumDataType(typeof(Gender))]
    public Gender? Gender { get; set; }
    public DateOnly? DateOfBirth { get; set; }

    [Range(50, 300, ErrorMessage = "Height must be between 50 and 300 cm")]
    public int? HeightInCm { get; set; }
    [Range(0, 500, ErrorMessage = "Weight must be between 0 and 500 kg")]
    public decimal? WeightInKg { get; set; }

    [JsonIgnore]
    public int NutritionistId { get; set; }

    [EnumDataType(typeof(SubscriptionPlan))]
    public SubscriptionPlan? SubscriptionPlan { get; set; }
}
