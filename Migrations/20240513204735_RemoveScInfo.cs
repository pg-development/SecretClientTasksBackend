using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SecretClientTasksBackend.Migrations
{
    /// <inheritdoc />
    public partial class RemoveScInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsTaken",
                table: "SCTasks");

            migrationBuilder.DropColumn(
                name: "SCEmail",
                table: "SCTasks");

            migrationBuilder.DropColumn(
                name: "SCPhoneNumber",
                table: "SCTasks");

            migrationBuilder.UpdateData(
                table: "SCTasks",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "EndDate", "StartDate", "WaitingPeriod" },
                values: new object[] { new DateTime(2024, 5, 27, 22, 47, 34, 630, DateTimeKind.Local).AddTicks(2773), new DateTime(2024, 5, 13, 22, 47, 34, 630, DateTimeKind.Local).AddTicks(2731), "Karencja: 1 miesiąc" });

            migrationBuilder.UpdateData(
                table: "SCTasks",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "EndDate", "StartDate", "WaitingPeriod" },
                values: new object[] { new DateTime(2024, 5, 27, 22, 47, 34, 630, DateTimeKind.Local).AddTicks(2778), new DateTime(2024, 5, 13, 22, 47, 34, 630, DateTimeKind.Local).AddTicks(2777), "Karencja: 1 miesiąc" });

            migrationBuilder.UpdateData(
                table: "SCTasks",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "EndDate", "StartDate", "WaitingPeriod" },
                values: new object[] { new DateTime(2024, 5, 27, 22, 47, 34, 630, DateTimeKind.Local).AddTicks(2783), new DateTime(2024, 5, 13, 22, 47, 34, 630, DateTimeKind.Local).AddTicks(2781), "Karencja: 2 miesiące" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsTaken",
                table: "SCTasks",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SCEmail",
                table: "SCTasks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SCPhoneNumber",
                table: "SCTasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "SCTasks",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "EndDate", "IsTaken", "SCEmail", "SCPhoneNumber", "StartDate", "WaitingPeriod" },
                values: new object[] { new DateTime(2024, 5, 2, 22, 41, 31, 177, DateTimeKind.Local).AddTicks(2335), false, "", -1, new DateTime(2024, 4, 18, 22, 41, 31, 177, DateTimeKind.Local).AddTicks(2297), "" });

            migrationBuilder.UpdateData(
                table: "SCTasks",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "EndDate", "IsTaken", "SCEmail", "SCPhoneNumber", "StartDate", "WaitingPeriod" },
                values: new object[] { new DateTime(2024, 5, 2, 22, 41, 31, 177, DateTimeKind.Local).AddTicks(2341), false, "", -1, new DateTime(2024, 4, 18, 22, 41, 31, 177, DateTimeKind.Local).AddTicks(2340), "" });

            migrationBuilder.UpdateData(
                table: "SCTasks",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "EndDate", "IsTaken", "SCEmail", "SCPhoneNumber", "StartDate", "WaitingPeriod" },
                values: new object[] { new DateTime(2024, 5, 2, 22, 41, 31, 177, DateTimeKind.Local).AddTicks(2376), false, "", -1, new DateTime(2024, 4, 18, 22, 41, 31, 177, DateTimeKind.Local).AddTicks(2374), "" });
        }
    }
}
