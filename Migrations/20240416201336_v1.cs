using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SecretClientTasksBackend.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SCTasks",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Voivodeship = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gratification = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsTaken = table.Column<bool>(type: "bit", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SCEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SCPhoneNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SCTasks", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "SCTasks",
                columns: new[] { "Id", "Address", "City", "Description", "EndDate", "Gratification", "IsTaken", "Name", "SCEmail", "SCPhoneNumber", "StartDate", "Voivodeship" },
                values: new object[,]
                {
                    { 1L, "Długa 12", "Zgierz", "Testowy opis", new DateTime(2024, 4, 30, 22, 13, 35, 464, DateTimeKind.Local).AddTicks(719), 20.00m, false, "Testowa nazwa zlecenia", "", -1, new DateTime(2024, 4, 16, 22, 13, 35, 464, DateTimeKind.Local).AddTicks(681), "Łódzkie" },
                    { 2L, "Cegielniana 27", "Łódź", "Testowy opis drugiego zlecenia", new DateTime(2024, 4, 30, 22, 13, 35, 464, DateTimeKind.Local).AddTicks(725), 13.50m, false, "Testowa nazwa drugiego zlecenia", "", -1, new DateTime(2024, 4, 16, 22, 13, 35, 464, DateTimeKind.Local).AddTicks(724), "Łódzkie" },
                    { 3L, "Krótka 6", "Ozorków", "Testowy opis, który podobnie jak wyżej jest długi, powiedziałbym nawet, że bardzo długi czy nawet podobny do opisu, który swoją długością przypomina coś jeszcze dłuższego niż to do czego to zostało wcześniej porównane", new DateTime(2024, 4, 30, 22, 13, 35, 464, DateTimeKind.Local).AddTicks(730), 8.00m, false, "Testowa nazwa zlecenia, które jest trzecie i jest zleceniem, które ma długi opis, bo komuś się chyba najwidoczniej nudziło i jest urodzonym pisarzem", "", -1, new DateTime(2024, 4, 16, 22, 13, 35, 464, DateTimeKind.Local).AddTicks(728), "Łódzkie" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SCTasks");
        }
    }
}
