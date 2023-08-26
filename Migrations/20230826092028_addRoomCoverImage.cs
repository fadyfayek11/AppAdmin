using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Admin.Migrations
{
    public partial class addRoomCoverImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6daf2d75-a44d-4bd2-8cb8-0f3d440f5f92");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd7a43d3-8f1d-4d9d-86e5-3c642701c9b6");

            migrationBuilder.AddColumn<string>(
                name: "CoverImagePath",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Photo", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "4d22c0c0-077a-45b5-86a5-89c47d238089", 0, "6a383387-2f71-4290-84d1-a9a50babd3e8", null, false, false, null, null, "ADMIN", "AQAAAAEAACcQAAAAEEJCefa2ciGbGKBdGpVyreMyJ11NP9pp6rlRCA+TqYG5FOKkoIhhCq+Ae/CFCw1Kpg==", null, false, null, "fe7e7a45-b877-4a3f-a0b1-a8c56339404d", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Photo", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "6714f825-7ead-43f9-8e1f-8f23b06076f8", 0, "abefc731-9ca5-468e-b534-b54d3945fdf1", null, false, false, null, null, "STAFF", "AQAAAAEAACcQAAAAEBKsYGJCnx9eiJeKC4svU1Av25QFAZ2hsAIKwU7g99goGhkcHj/L+hugye1bLsUWSw==", null, false, null, "581b6c42-a653-40bc-8fbe-398b1790549c", false, "staff" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4d22c0c0-077a-45b5-86a5-89c47d238089");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6714f825-7ead-43f9-8e1f-8f23b06076f8");

            migrationBuilder.DropColumn(
                name: "CoverImagePath",
                table: "Rooms");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Photo", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "6daf2d75-a44d-4bd2-8cb8-0f3d440f5f92", 0, "e574fd1e-3b0e-4772-b0b6-c75d9e6eb7ac", null, false, false, null, null, "STAFF", "AQAAAAEAACcQAAAAEB3IwwY5+lyVc0+Wc4+CrZXg9Y4Zy8LD61D6SqVjHHFtKslP8QHxMFw9suYAUIzamg==", null, false, null, "21ecb755-17c2-4494-876b-dc5f0ee4fe6e", false, "staff" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Photo", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "cd7a43d3-8f1d-4d9d-86e5-3c642701c9b6", 0, "63cdeda1-4e10-4cd3-9398-2cfce6a157a3", null, false, false, null, null, "ADMIN", "AQAAAAEAACcQAAAAEMMEM4NM1OJcr760Dp0jVOQk/0ItYLK6De3p4+X4PvUdFZ1FCoysljhbgsSZ/I+8nQ==", null, false, null, "8c5fbb3b-a2a5-4986-9adc-9e105d9ec851", false, "admin" });
        }
    }
}
