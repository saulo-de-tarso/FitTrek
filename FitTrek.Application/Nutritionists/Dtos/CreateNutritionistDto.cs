using System.Text.Json.Serialization;

namespace FitTrek.Application.Nutritionists.Dtos;

public class CreateNutritionistDto
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;

    public string Email { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;

    public DateTime DateOfBirth { get; set; } = default!;


}
