using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Admin.Migrations
{
    public partial class addSeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admins_AspNetUsers_UserId",
                table: "Admins");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4d22c0c0-077a-45b5-86a5-89c47d238089");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6714f825-7ead-43f9-8e1f-8f23b06076f8");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Admins",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", "70e9ef61-a140-4e0e-90c8-f6dbbb785aca", "Admin", "ADMIN" },
                    { "2", "2510027f-fed7-4ee4-a4e3-76c72ae874ee", "RootAdmin", "ROOTADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Photo", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, "56910753-205f-47ab-a374-f9ddda432e21", "admin@sanabat.com", true, false, null, "ADMIN@SANABAT.COM", "ADMIN", "AQAAAAEAACcQAAAAEJbMEHfwFdGP8BgO8v8FSADNIsOjiXAiOQqax8chaXIAA+CQNc6jNILPhLmD8wN1Ag==", null, false, null, "e4dc0b4a-9337-480b-bbca-aa8ab8f7d214", false, "admin" },
                    { "2", 0, "f02d1cbc-bb1f-4609-806e-61afc8b93a07", "root@sanabat.com", true, false, null, "ROOT@SANABAT.COM", "Root", "AQAAAAEAACcQAAAAEO7SqXdrbRlGBR4MA6TLmaSM483zrhjqMor8HKn6HBdmlWIWcDLZWst6/YXFDBE4nQ==", null, false, null, "808ea46d-c8f9-46de-bb9c-69988257280f", false, "root" }
                });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "CreatedDate", "IsRoot", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "1" },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "2" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1", "1" },
                    { "2", "2" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Admins_AspNetUsers_UserId",
                table: "Admins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admins_AspNetUsers_UserId",
                table: "Admins");

            migrationBuilder.DeleteData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "1" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "2" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Admins",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Photo", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "4d22c0c0-077a-45b5-86a5-89c47d238089", 0, "6a383387-2f71-4290-84d1-a9a50babd3e8", null, false, false, null, null, "ADMIN", "AQAAAAEAACcQAAAAEEJCefa2ciGbGKBdGpVyreMyJ11NP9pp6rlRCA+TqYG5FOKkoIhhCq+Ae/CFCw1Kpg==", null, false, null, "fe7e7a45-b877-4a3f-a0b1-a8c56339404d", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Photo", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "6714f825-7ead-43f9-8e1f-8f23b06076f8", 0, "abefc731-9ca5-468e-b534-b54d3945fdf1", null, false, false, null, null, "STAFF", "AQAAAAEAACcQAAAAEBKsYGJCnx9eiJeKC4svU1Av25QFAZ2hsAIKwU7g99goGhkcHj/L+hugye1bLsUWSw==", null, false, null, "581b6c42-a653-40bc-8fbe-398b1790549c", false, "staff" });

            migrationBuilder.AddForeignKey(
                name: "FK_Admins_AspNetUsers_UserId",
                table: "Admins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
