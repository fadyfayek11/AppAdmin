using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Admin.Migrations
{
    public partial class addWithBreakFastFlag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "609b55a1-8d6c-4262-9109-120c976b9dc2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "886d2197-87e9-475c-bfac-e5ecd76f0477");

            migrationBuilder.AddColumn<bool>(
                name: "WithBreakFast",
                table: "Reservations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Photo", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "199a2a2d-bd6a-437e-984b-12cf84f62f5c", 0, "7dff5aac-5b89-4715-9e27-914a2362bc0f", null, false, false, null, null, "ADMIN", "AQAAAAEAACcQAAAAEK9vJkdPWGg+iwV7m7D5JWp7Xbf3nmhM7V5FtM72Mk1y1oGRgCEvOTp7evxtmk7img==", null, false, null, "5dcfec64-cf3d-40f6-995f-6e3cb1f9ba0c", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Photo", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3dee8682-972a-4867-add6-f558b3b96de9", 0, "47f95148-d2fc-4b62-a713-0b4670665ed2", null, false, false, null, null, "STAFF", "AQAAAAEAACcQAAAAEHy8uqUVSCUXoqlwqZOvygEzKqBvJ76UF93OoyPZ11Yafv9kcTXHlA1HmRo9qyXRAQ==", null, false, null, "84190077-f348-474f-9c53-262352aa2a80", false, "staff" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "199a2a2d-bd6a-437e-984b-12cf84f62f5c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3dee8682-972a-4867-add6-f558b3b96de9");

            migrationBuilder.DropColumn(
                name: "WithBreakFast",
                table: "Reservations");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Photo", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "609b55a1-8d6c-4262-9109-120c976b9dc2", 0, "455f5ee5-1186-4792-858d-9a1f99637c3b", null, false, false, null, null, "STAFF", "AQAAAAEAACcQAAAAEPsijVzy/3Wju+sb8i/aiS0p6dGabcanCmgeNHLbf7oNEaeaSBw/QHECHgaBLHl8vw==", null, false, null, "a96f63d0-8230-49a9-811b-5916ec61fc2b", false, "staff" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Photo", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "886d2197-87e9-475c-bfac-e5ecd76f0477", 0, "33598d1f-b856-4177-a21c-57f8f78f1132", null, false, false, null, null, "ADMIN", "AQAAAAEAACcQAAAAEBbxruihgkSZ33RoyyLOosSB54L/0hWNDchIoln2oXZsn8PCl/yvd1vk7uqMHgJRyg==", null, false, null, "79a88452-b80c-41c9-8d86-36b77054c793", false, "admin" });
        }
    }
}
