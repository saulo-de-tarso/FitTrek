using Microsoft.AspNetCore.Identity;

namespace FitTrek.Domain.Entities;

public class User : IdentityUser
{
    public Nutritionist Nutritionist { get; set; } = default!;
}
