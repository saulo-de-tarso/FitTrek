using FitTrek.Application.Clients.Enums;
using FitTrek.Application.Common.Enums;
using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FitTrek.Application.Clients.Commands.CreateClient;

public class CreateClientCommand : IRequest<int>
{

    [Required]
    public string FirstName { get; set; } = default!;
    [Required]
    public string LastName { get; set; } = default!;
    [Required]
    [EmailAddress(ErrorMessage = "Please provide a valid email address.")]
    public string Email { get; set; } = default!;
    [Required]
    [RegularExpression(@"^\([1-9]{2}\) 9[0-9]{4}-[0-9]{4}$", 
        ErrorMessage = "The phone number must be in the format (XX) 9XXXX-XXXX. DDD can't have zeroes in it.")]
    public string PhoneNumber { get; set; } = default!;
    [Required]
    [EnumDataType(typeof(GenderEnum), ErrorMessage = "Gender must be Male, Female or Other")]
    public string Gender { get; set; } = default!;
    [Required]
    public DateTime DateOfBirth { get; set; } = default!;

    [Required]
    [Range(50, 300, ErrorMessage = "Height must be between 50 and 300 cm")]
    public int HeightInCm { get; set; }
    [Required]
    [Range(0, 500, ErrorMessage = "Weight must be between 0 and 500 kg")]
    public decimal WeightInKg { get; set; }

    [JsonIgnore]
    public int NutritionistId { get; set; }
    public bool IsActive { get; set; } = true;
    [Required]
    [EnumDataType(typeof(SubscriptionPlanEnum), ErrorMessage = "Subscription plan must be Silver, Gold or Platinum")]
    public string SubscriptionPlan { get; set; } = default!;
}
