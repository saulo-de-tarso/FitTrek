using FitTrek.Domain.Entities;

namespace FitTrek.Application.Dtos;

public class NutritionistDto
{
    public int Id { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;

    public string Email { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;

    public DateOnly DateOfBirth { get; set; } = default!;

    public List<Client> Clients { get; set; } = new();
    
    public DateTime CreatedAt { get; set; } = default!;
    public DateTime? UpdatedAt { get; set; }
}
