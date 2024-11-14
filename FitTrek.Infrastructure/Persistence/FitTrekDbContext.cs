using FitTrek.Application.Clients.Enums;
using FitTrek.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Xml;

namespace FitTrek.Infrastructure.Persistence;

internal class FitTrekDbContext(DbContextOptions<FitTrekDbContext> options) 
    : IdentityDbContext<User>(options)
{
    internal DbSet<Nutritionist> Nutritionists { get; set; }
    internal DbSet<Client> Clients { get; set; }
    internal DbSet<DietPlan> DietPlans { get; set; }
    internal DbSet<Meal> Meals { get; set; }
    
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //user relationships
        
        modelBuilder.Entity<User>()
            .HasOne(u => u.Nutritionist)
            .WithOne(n => n.User)
            .HasForeignKey<Nutritionist>(n => n.UserId);


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

        //nutritionist indexes
        
        modelBuilder.Entity<Nutritionist>()
            .HasIndex(n => n.FirstName)
            .HasDatabaseName("IX_Nutritionist_FirstName_Filter");

        modelBuilder.Entity<Nutritionist>()
            .HasIndex(n => n.LastName)
            .HasDatabaseName("IX_Nutritionist_LastName_Filter");

        modelBuilder.Entity<Nutritionist>()
            .HasIndex(n => n.CurrentMonthlyRevenue)
            .HasDatabaseName("IX_Nutritionist_CurrentMonthlyRevenue_Filter");





        //client relationships

        modelBuilder.Entity<Client>()
            .HasMany(c => c.DietPlans)
            .WithOne()
            .HasForeignKey(dp => dp.ClientId);

        //client indexes

        modelBuilder.Entity<Client>()
            .HasIndex(n => n.FirstName)
            .HasDatabaseName("IX_Client_FirstName_Filter");

        modelBuilder.Entity<Client>()
            .HasIndex(n => n.LastName)
            .HasDatabaseName("IX_Client_LastName_Filter");

        modelBuilder.Entity<Client>()
            .HasIndex(n => n.WeightInKg)
            .HasDatabaseName("IX_Client_WeightInKg_Filter");

        modelBuilder.Entity<Client>()
            .HasIndex(n => n.HeightInCm)
            .HasDatabaseName("IX_Client_HeightInCm_Filter");



        //converting enum types

        modelBuilder.Entity<Client>()
            .Property(c => c.Gender)
            .HasConversion(
                g => g.ToString(),     
                g => (Gender)Enum.Parse(typeof(Gender), g)  
            );

        modelBuilder.Entity<Client>()
            .Property(c => c.SubscriptionPlan)
            .HasConversion(
                sp => sp.ToString(),     
                sp => (SubscriptionPlan)Enum.Parse(typeof(SubscriptionPlan), sp)  
            );


        //diet plan relationships
        modelBuilder.Entity<DietPlan>()
            .HasMany(dp => dp.Meals)
            .WithOne()
            .HasForeignKey(d => d.DietPlanId);


            

    }

}
