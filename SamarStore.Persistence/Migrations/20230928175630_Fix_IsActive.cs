using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SamarStore.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Fix_IsActive : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2023, 9, 28, 21, 26, 30, 532, DateTimeKind.Local).AddTicks(9116));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2023, 9, 28, 21, 26, 30, 532, DateTimeKind.Local).AddTicks(9161));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2023, 9, 28, 21, 26, 30, 532, DateTimeKind.Local).AddTicks(9170));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2023, 9, 28, 20, 25, 7, 71, DateTimeKind.Local).AddTicks(1756));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2023, 9, 28, 20, 25, 7, 71, DateTimeKind.Local).AddTicks(1811));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2023, 9, 28, 20, 25, 7, 71, DateTimeKind.Local).AddTicks(1825));
        }
    }
}
