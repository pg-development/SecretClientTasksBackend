using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SecretClientTasksBackend.Migrations
{
    /// <inheritdoc />
    public partial class ChangeGratificationType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Gratification",
                table: "SCTasks",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.UpdateData(
                table: "SCTasks",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "EndDate", "Gratification", "StartDate" },
                values: new object[] { new DateTime(2024, 5, 27, 22, 54, 28, 108, DateTimeKind.Local).AddTicks(2307), "20.00", new DateTime(2024, 5, 13, 22, 54, 28, 108, DateTimeKind.Local).AddTicks(2271) });

            migrationBuilder.UpdateData(
                table: "SCTasks",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "EndDate", "Gratification", "StartDate" },
                values: new object[] { new DateTime(2024, 5, 27, 22, 54, 28, 108, DateTimeKind.Local).AddTicks(2313), "13.50", new DateTime(2024, 5, 13, 22, 54, 28, 108, DateTimeKind.Local).AddTicks(2311) });

            migrationBuilder.UpdateData(
                table: "SCTasks",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "EndDate", "Gratification", "StartDate" },
                values: new object[] { new DateTime(2024, 5, 27, 22, 54, 28, 108, DateTimeKind.Local).AddTicks(2317), "8.00", new DateTime(2024, 5, 13, 22, 54, 28, 108, DateTimeKind.Local).AddTicks(2315) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Gratification",
                table: "SCTasks",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "SCTasks",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "EndDate", "Gratification", "StartDate" },
                values: new object[] { new DateTime(2024, 5, 27, 22, 47, 34, 630, DateTimeKind.Local).AddTicks(2773), 20.00m, new DateTime(2024, 5, 13, 22, 47, 34, 630, DateTimeKind.Local).AddTicks(2731) });

            migrationBuilder.UpdateData(
                table: "SCTasks",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "EndDate", "Gratification", "StartDate" },
                values: new object[] { new DateTime(2024, 5, 27, 22, 47, 34, 630, DateTimeKind.Local).AddTicks(2778), 13.50m, new DateTime(2024, 5, 13, 22, 47, 34, 630, DateTimeKind.Local).AddTicks(2777) });

            migrationBuilder.UpdateData(
                table: "SCTasks",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "EndDate", "Gratification", "StartDate" },
                values: new object[] { new DateTime(2024, 5, 27, 22, 47, 34, 630, DateTimeKind.Local).AddTicks(2783), 8.00m, new DateTime(2024, 5, 13, 22, 47, 34, 630, DateTimeKind.Local).AddTicks(2781) });
        }
    }
}
