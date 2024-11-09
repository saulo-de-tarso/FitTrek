﻿namespace FitTrek.Domain.Entities;

public class ClientStats
{
    public int Id { get; set; }
    public DateOnly Date { get; set; }
    
    public decimal WeightInKg { get; set; }   
    public decimal BodyFatPercentage { get; set; }
    public decimal MuscleMassInKg { get; set; }
    
    public decimal WaistCircumference { get; set; }
    public decimal HipCircumference { get; set; }
    public decimal ChestCicumference { get; set; }
    public decimal ArmCircumfernece { get; set; }

    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}