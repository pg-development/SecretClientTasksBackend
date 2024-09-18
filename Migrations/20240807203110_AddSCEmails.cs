using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SecretClientTasksBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddSCEmails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SCTasks",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "SCTasks",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "SCTasks",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.AddColumn<string>(
                name: "SCEmails",
                table: "SCTasks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SCEmails",
                table: "SCTasks");

            migrationBuilder.InsertData(
                table: "SCTasks",
                columns: new[] { "Id", "Address", "City", "Description", "EndDate", "Gratification", "Name", "StartDate", "Voivodeship", "WaitingPeriod" },
                values: new object[,]
                {
                    { 1L, "Długa 12", "Zgierz", "Testowy opis", new DateTime(2024, 5, 27, 22, 54, 28, 108, DateTimeKind.Local).AddTicks(2307), "20.00", "Testowa nazwa zlecenia", new DateTime(2024, 5, 13, 22, 54, 28, 108, DateTimeKind.Local).AddTicks(2271), "Łódzkie", "Karencja: 1 miesiąc" },
                    { 2L, "Cegielniana 27", "Łódź", "Testowy opis drugiego zlecenia", new DateTime(2024, 5, 27, 22, 54, 28, 108, DateTimeKind.Local).AddTicks(2313), "13.50", "Testowa nazwa drugiego zlecenia", new DateTime(2024, 5, 13, 22, 54, 28, 108, DateTimeKind.Local).AddTicks(2311), "Łódzkie", "Karencja: 1 miesiąc" },
                    { 3L, "Krótka 6", "Ozorków", "Testowy opis, który podobnie jak wyżej jest długi, powiedziałbym nawet, że bardzo długi czy nawet podobny do opisu, który swoją długością przypomina coś jeszcze dłuższego niż to do czego to zostało wcześniej porównane", new DateTime(2024, 5, 27, 22, 54, 28, 108, DateTimeKind.Local).AddTicks(2317), "8.00", "Testowa nazwa zlecenia, które jest trzecie i jest zleceniem, które ma długi opis, bo komuś się chyba najwidoczniej nudziło i jest urodzonym pisarzem", new DateTime(2024, 5, 13, 22, 54, 28, 108, DateTimeKind.Local).AddTicks(2315), "Łódzkie", "Karencja: 2 miesiące" }
                });
        }
    }
}
