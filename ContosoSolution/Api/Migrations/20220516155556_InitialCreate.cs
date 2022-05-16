using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NutrientType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NutrientType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nutrients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NutrientTypeId = table.Column<int>(type: "int", nullable: true),
                    Energy = table.Column<int>(type: "int", nullable: false),
                    Fiber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nutrients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nutrients_NutrientType_NutrientTypeId",
                        column: x => x.NutrientTypeId,
                        principalTable: "NutrientType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "NutrientType",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Macronutrient" });

            migrationBuilder.InsertData(
                table: "NutrientType",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Micronutrient" });

            migrationBuilder.CreateIndex(
                name: "IX_Nutrients_NutrientTypeId",
                table: "Nutrients",
                column: "NutrientTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Nutrients");

            migrationBuilder.DropTable(
                name: "NutrientType");
        }
    }
}
