using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SecretClientTasksBackend.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "WaitingPeriod",
                table: "SCTasks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "SCTasks",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "EndDate", "StartDate", "WaitingPeriod" },
                values: new object[] { new DateTime(2024, 5, 2, 22, 41, 31, 177, DateTimeKind.Local).AddTicks(2335), new DateTime(2024, 4, 18, 22, 41, 31, 177, DateTimeKind.Local).AddTicks(2297), "" });

            migrationBuilder.UpdateData(
                table: "SCTasks",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "EndDate", "StartDate", "WaitingPeriod" },
                values: new object[] { new DateTime(2024, 5, 2, 22, 41, 31, 177, DateTimeKind.Local).AddTicks(2341), new DateTime(2024, 4, 18, 22, 41, 31, 177, DateTimeKind.Local).AddTicks(2340), "" });

            migrationBuilder.UpdateData(
                table: "SCTasks",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "EndDate", "StartDate", "WaitingPeriod" },
                values: new object[] { new DateTime(2024, 5, 2, 22, 41, 31, 177, DateTimeKind.Local).AddTicks(2376), new DateTime(2024, 4, 18, 22, 41, 31, 177, DateTimeKind.Local).AddTicks(2374), "" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WaitingPeriod",
                table: "SCTasks");

            migrationBuilder.UpdateData(
                table: "SCTasks",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 4, 30, 22, 13, 35, 464, DateTimeKind.Local).AddTicks(719), new DateTime(2024, 4, 16, 22, 13, 35, 464, DateTimeKind.Local).AddTicks(681) });

            migrationBuilder.UpdateData(
                table: "SCTasks",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 4, 30, 22, 13, 35, 464, DateTimeKind.Local).AddTicks(725), new DateTime(2024, 4, 16, 22, 13, 35, 464, DateTimeKind.Local).AddTicks(724) });

            migrationBuilder.UpdateData(
                table: "SCTasks",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 4, 30, 22, 13, 35, 464, DateTimeKind.Local).AddTicks(730), new DateTime(2024, 4, 16, 22, 13, 35, 464, DateTimeKind.Local).AddTicks(728) });
        }
    }
}
