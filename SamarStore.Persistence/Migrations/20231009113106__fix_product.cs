using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SamarStore.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class _fix_product : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersInRoles_Roles_RoleId",
                table: "UsersInRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersInRoles_Users_UserId",
                table: "UsersInRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersInRoles",
                table: "UsersInRoles");

            migrationBuilder.RenameTable(
                name: "UsersInRoles",
                newName: "UserInRoles");

            migrationBuilder.RenameIndex(
                name: "IX_UsersInRoles_UserId",
                table: "UserInRoles",
                newName: "IX_UserInRoles_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UsersInRoles_RoleId",
                table: "UserInRoles",
                newName: "IX_UserInRoles_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserInRoles",
                table: "UserInRoles",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2023, 10, 9, 15, 1, 6, 310, DateTimeKind.Local).AddTicks(3578));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2023, 10, 9, 15, 1, 6, 310, DateTimeKind.Local).AddTicks(3617));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2023, 10, 9, 15, 1, 6, 310, DateTimeKind.Local).AddTicks(3626));

            migrationBuilder.AddForeignKey(
                name: "FK_UserInRoles_Roles_RoleId",
                table: "UserInRoles",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserInRoles_Users_UserId",
                table: "UserInRoles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserInRoles_Roles_RoleId",
                table: "UserInRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserInRoles_Users_UserId",
                table: "UserInRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserInRoles",
                table: "UserInRoles");

            migrationBuilder.RenameTable(
                name: "UserInRoles",
                newName: "UsersInRoles");

            migrationBuilder.RenameIndex(
                name: "IX_UserInRoles_UserId",
                table: "UsersInRoles",
                newName: "IX_UsersInRoles_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserInRoles_RoleId",
                table: "UsersInRoles",
                newName: "IX_UsersInRoles_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersInRoles",
                table: "UsersInRoles",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2023, 10, 9, 14, 13, 13, 206, DateTimeKind.Local).AddTicks(7090));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2023, 10, 9, 14, 13, 13, 206, DateTimeKind.Local).AddTicks(7129));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2023, 10, 9, 14, 13, 13, 206, DateTimeKind.Local).AddTicks(7138));

            migrationBuilder.AddForeignKey(
                name: "FK_UsersInRoles_Roles_RoleId",
                table: "UsersInRoles",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersInRoles_Users_UserId",
                table: "UsersInRoles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
