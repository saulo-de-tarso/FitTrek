﻿using FitTrek.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FitTrek.Infrastructure.Persistence;

internal class FitTrekDbContext(DbContextOptions<FitTrekDbContext> options) : DbContext(options)
{
    internal DbSet<Nutritionist> Nutritionists { get; set; }
    internal DbSet<Client> Clients { get; set; }
    internal DbSet<DietPlan> DietPlans { get; set; }
    internal DbSet<Meal> Meals { get; set; }
    internal DbSet<ClientStats> ClientsStats { get; set; }
    internal DbSet<ProgressNotes> ProgressNotes { get; set; }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
                        
        //nutritionist relationships

        modelBuilder.Entity<Nutritionist>()
            .HasMany(n => n.Clients)
            .WithOne()
            .HasForeignKey(c => c.NutritionistId);

        modelBuilder.Entity<Nutritionist>()
            .HasMany(n => n.DietPlans)
            .WithOne()
            .HasForeignKey(dp => dp.NutritionistId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Nutritionist>()
            .HasMany(n => n.ProgressNotes)
            .WithOne()
            .HasForeignKey(pn => pn.NutritionistId)
            .OnDelete(DeleteBehavior.NoAction);

        //client relationships

        modelBuilder.Entity<Client>()
            .HasMany(c => c.DietPlans)
            .WithOne()
            .HasForeignKey(dp => dp.ClientId);

        modelBuilder.Entity<Client>()
            .HasMany(c => c.ClientStats)
            .WithOne()
            .HasForeignKey(cs => cs.ClientId);

        modelBuilder.Entity<Client>()
            .HasMany(c => c.ProgressNotes)
            .WithOne()
            .HasForeignKey(pn => pn.ClientId);


        //diet plan relationships
        modelBuilder.Entity<DietPlan>()
            .HasMany(dp => dp.Meals)
            .WithOne()
            .HasForeignKey(d => d.DietPlanId);


            

    }

}