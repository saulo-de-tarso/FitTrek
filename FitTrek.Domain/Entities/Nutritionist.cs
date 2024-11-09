﻿namespace FitTrek.Domain.Entities;

public class Nutritionist
{
    public int Id { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;

    public string Email { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;

    public decimal CurrentMonthlyRevenue { get; set; }

    public List<Client> Clients { get; set; } = new();

    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

}