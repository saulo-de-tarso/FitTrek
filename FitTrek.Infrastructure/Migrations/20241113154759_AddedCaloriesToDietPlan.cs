using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitTrek.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedCaloriesToDietPlan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Calories",
                table: "DietPlans",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Calories",
                table: "DietPlans");
        }
    }
}
