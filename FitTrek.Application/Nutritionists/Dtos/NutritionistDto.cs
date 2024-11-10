using FitTrek.Application.Clients.Dtos;

namespace FitTrek.Application.Nutritionists.Dtos;

public class NutritionistDto
{
    public int Id { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;

    public string Email { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;

    public DateOnly DateOfBirth { get; set; } = default!;
    public decimal CurrentMonthlyRevenue { get; set; }

    public List<ClientDto> Clients { get; set; } = [];
    
    public DateTime CreatedAt { get; set; } = default!;
    public DateTime? UpdatedAt { get; set; }
}
