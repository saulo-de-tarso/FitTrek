using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FitTrek.Application.Nutritionists.Commands.UpdateNutritionist;

public class UpdateNutritionistCommand : IRequest
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

    public DateOnly? DateOfBirth { get; set; }
}
