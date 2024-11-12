using MediatR;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Numerics;

namespace FitTrek.Application.Nutritionists.Commands.CreateNutritionist;

public class CreateNutritionistCommand : IRequest<int>
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
    
    public DateTime DateOfBirth { get; set; } = default!;
}
