using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RacingCars.Migrations
{
    public partial class NewInitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarsDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Mileage = table.Column<long>(type: "bigint", nullable: false),
                    DateOfService = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarsDb", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NationalitiesDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NationalitiesDb", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PilotsDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Points = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PilotsDb", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RacesDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPilot = table.Column<int>(type: "int", nullable: false),
                    IdCar = table.Column<int>(type: "int", nullable: false),
                    Track = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfCompetition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mileage = table.Column<long>(type: "bigint", nullable: false),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Points = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RacesDb", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RacesDb_CarsDb_IdCar",
                        column: x => x.IdCar,
                        principalTable: "CarsDb",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RacesDb_PilotsDb_IdPilot",
                        column: x => x.IdPilot,
                        principalTable: "PilotsDb",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RacesDb_IdCar",
                table: "RacesDb",
                column: "IdCar");

            migrationBuilder.CreateIndex(
                name: "IX_RacesDb_IdPilot",
                table: "RacesDb",
                column: "IdPilot");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
               name: "NationalitiesDb");

            migrationBuilder.DropTable(
                name: "RacesDb");

            migrationBuilder.DropTable(
                name: "CarsDb");

            migrationBuilder.DropTable(
                name: "PilotsDb");
        }
    }
}
