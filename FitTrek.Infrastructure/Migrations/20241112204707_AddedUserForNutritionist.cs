using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitTrek.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedUserForNutritionist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Nutritionists",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Nutritionists_UserId",
                table: "Nutritionists",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Nutritionists_AspNetUsers_UserId",
                table: "Nutritionists",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nutritionists_AspNetUsers_UserId",
                table: "Nutritionists");

            migrationBuilder.DropIndex(
                name: "IX_Nutritionists_UserId",
                table: "Nutritionists");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Nutritionists");
        }
    }
}
