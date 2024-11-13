using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitTrek.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedIndexToDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientsStats");

            migrationBuilder.DropTable(
                name: "ProgressNotes");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Nutritionists",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Nutritionists",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Clients",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Clients",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Nutritionist_CurrentMonthlyRevenue_Filter",
                table: "Nutritionists",
                column: "CurrentMonthlyRevenue");

            migrationBuilder.CreateIndex(
                name: "IX_Nutritionist_FirstName_Filter",
                table: "Nutritionists",
                column: "FirstName");

            migrationBuilder.CreateIndex(
                name: "IX_Nutritionist_LastName_Filter",
                table: "Nutritionists",
                column: "LastName");

            migrationBuilder.CreateIndex(
                name: "IX_Client_FirstName_Filter",
                table: "Clients",
                column: "FirstName");

            migrationBuilder.CreateIndex(
                name: "IX_Client_HeightInCm_Filter",
                table: "Clients",
                column: "HeightInCm");

            migrationBuilder.CreateIndex(
                name: "IX_Client_LastName_Filter",
                table: "Clients",
                column: "LastName");

            migrationBuilder.CreateIndex(
                name: "IX_Client_WeightInKg_Filter",
                table: "Clients",
                column: "WeightInKg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Nutritionist_CurrentMonthlyRevenue_Filter",
                table: "Nutritionists");

            migrationBuilder.DropIndex(
                name: "IX_Nutritionist_FirstName_Filter",
                table: "Nutritionists");

            migrationBuilder.DropIndex(
                name: "IX_Nutritionist_LastName_Filter",
                table: "Nutritionists");

            migrationBuilder.DropIndex(
                name: "IX_Client_FirstName_Filter",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Client_HeightInCm_Filter",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Client_LastName_Filter",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Client_WeightInKg_Filter",
                table: "Clients");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Nutritionists",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Nutritionists",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateTable(
                name: "ClientsStats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArmCircumfernece = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BodyFatPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ChestCicumference = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    HipCircumference = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MuscleMassInKg = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WaistCircumference = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WeightInKg = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientsStats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientsStats_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProgressNotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NutritionistId = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgressNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProgressNotes_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProgressNotes_Nutritionists_NutritionistId",
                        column: x => x.NutritionistId,
                        principalTable: "Nutritionists",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientsStats_ClientId",
                table: "ClientsStats",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgressNotes_ClientId",
                table: "ProgressNotes",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgressNotes_NutritionistId",
                table: "ProgressNotes",
                column: "NutritionistId");
        }
    }
}
