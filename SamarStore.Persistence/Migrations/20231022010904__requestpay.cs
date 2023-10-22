using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SamarStore.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class _requestpay : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RequestPay",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    IsPaid = table.Column<bool>(type: "bit", nullable: false),
                    PaidDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    Authority = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefId = table.Column<long>(type: "bigint", nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestPay", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestPay_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2023, 10, 22, 4, 39, 4, 631, DateTimeKind.Local).AddTicks(303));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2023, 10, 22, 4, 39, 4, 631, DateTimeKind.Local).AddTicks(347));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2023, 10, 22, 4, 39, 4, 631, DateTimeKind.Local).AddTicks(415));

            migrationBuilder.CreateIndex(
                name: "IX_RequestPay_UserId",
                table: "RequestPay",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequestPay");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2023, 10, 21, 13, 35, 3, 486, DateTimeKind.Local).AddTicks(600));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2023, 10, 21, 13, 35, 3, 486, DateTimeKind.Local).AddTicks(657));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2023, 10, 21, 13, 35, 3, 486, DateTimeKind.Local).AddTicks(668));
        }
    }
}
