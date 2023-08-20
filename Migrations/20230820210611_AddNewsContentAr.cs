using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Admin.Migrations
{
    public partial class AddNewsContentAr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e913ee7-81bf-44b5-94f1-6da90d1db758");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c05b27bc-94a0-4a88-8739-e5a74556c924");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "News",
                newName: "ContentEn");

            migrationBuilder.AddColumn<string>(
                name: "ContentAr",
                table: "News",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Photo", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "82f526e2-9e2c-4841-99ef-f9f905d1b152", 0, "ac904514-6f41-45b8-bf37-e2ffd61d3754", null, false, false, null, null, "ADMIN", "AQAAAAEAACcQAAAAED/l6sAi5PjY02xvFKD6A0zcBlNpRj2vrGCTp9x8VfYO8U82AJjChyd+/Grq8yNLqA==", null, false, null, "7297433e-1083-4038-9c62-9376f0591c16", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Photo", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "df3dc5e6-70da-4039-98ef-3f8a17b99dbb", 0, "9f04c9f7-786a-401e-a6bf-f0cceb26d7c6", null, false, false, null, null, "STAFF", "AQAAAAEAACcQAAAAENZCs4cXe+P7vrmTzCdSSei4CEiU4I09C3TNolBqc35IHPI5p/I3F9bGT9PR5tXpcw==", null, false, null, "489c64ac-2dcf-4a77-bcd6-c69dcc77b0bd", false, "staff" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "82f526e2-9e2c-4841-99ef-f9f905d1b152");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "df3dc5e6-70da-4039-98ef-3f8a17b99dbb");

            migrationBuilder.DropColumn(
                name: "ContentAr",
                table: "News");

            migrationBuilder.RenameColumn(
                name: "ContentEn",
                table: "News",
                newName: "Content");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Photo", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "9e913ee7-81bf-44b5-94f1-6da90d1db758", 0, "5ee3c1d1-dc39-4192-bdfe-da5cc14bf7f4", null, false, false, null, null, "ADMIN", "AQAAAAEAACcQAAAAELYvnZnePPg1jLN99EcxFGXpp7XpROMdmIMkztj+JSWfBjFgeITimU3j97dP2L92NQ==", null, false, null, "03f5afab-b89a-400f-948a-177fa3e0aa2d", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Photo", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c05b27bc-94a0-4a88-8739-e5a74556c924", 0, "3108dc42-77d3-4627-abe9-c0fc4af05fd1", null, false, false, null, null, "STAFF", "AQAAAAEAACcQAAAAEKqBQaEz+gPsmkb8YTAUBXszvmAVDJOveA18tyQQYEbSQdbyZpbjoYY/tdDHQA0Uqw==", null, false, null, "360b38ca-4e16-4f7b-abf9-1bcfb265a27d", false, "staff" });
        }
    }
}
