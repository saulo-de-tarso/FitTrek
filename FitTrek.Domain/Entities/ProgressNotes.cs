﻿namespace FitTrek.Domain.Entities;

public class ProgressNotes
{
    public int Id { get; set; }
    public DateOnly Date { get; set; }
    public string Note { get; set; } = default!;

    public int ClientId { get; set; }
    public int NutritionistId { get; set; }

    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }


}