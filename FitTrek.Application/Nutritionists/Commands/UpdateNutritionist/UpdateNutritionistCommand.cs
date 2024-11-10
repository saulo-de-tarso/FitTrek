using MediatR;
using System.Text.Json.Serialization;

namespace FitTrek.Application.Nutritionists.Commands.UpdateNutritionist;

public class UpdateNutritionistCommand : IRequest
{
    [JsonIgnore]
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }

    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }

    public DateTime? DateOfBirth { get; set; }
}
