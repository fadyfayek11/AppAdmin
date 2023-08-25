using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Admin.Migrations
{
    public partial class IsIconflag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "344d01e6-ff12-41b8-a28f-72856e0eeebc");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f001d71-955e-42ae-9eb7-ad70f892f064");

            migrationBuilder.AddColumn<bool>(
                name: "IsIcon",
                table: "DetailsDescription",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Photo", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "6daf2d75-a44d-4bd2-8cb8-0f3d440f5f92", 0, "e574fd1e-3b0e-4772-b0b6-c75d9e6eb7ac", null, false, false, null, null, "STAFF", "AQAAAAEAACcQAAAAEB3IwwY5+lyVc0+Wc4+CrZXg9Y4Zy8LD61D6SqVjHHFtKslP8QHxMFw9suYAUIzamg==", null, false, null, "21ecb755-17c2-4494-876b-dc5f0ee4fe6e", false, "staff" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Photo", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "cd7a43d3-8f1d-4d9d-86e5-3c642701c9b6", 0, "63cdeda1-4e10-4cd3-9398-2cfce6a157a3", null, false, false, null, null, "ADMIN", "AQAAAAEAACcQAAAAEMMEM4NM1OJcr760Dp0jVOQk/0ItYLK6De3p4+X4PvUdFZ1FCoysljhbgsSZ/I+8nQ==", null, false, null, "8c5fbb3b-a2a5-4986-9adc-9e105d9ec851", false, "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6daf2d75-a44d-4bd2-8cb8-0f3d440f5f92");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd7a43d3-8f1d-4d9d-86e5-3c642701c9b6");

            migrationBuilder.DropColumn(
                name: "IsIcon",
                table: "DetailsDescription");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Photo", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "344d01e6-ff12-41b8-a28f-72856e0eeebc", 0, "093bf302-ce98-417e-a9ee-3b70de975217", null, false, false, null, null, "ADMIN", "AQAAAAEAACcQAAAAEJzF8ehr3eJaBD4lJhdgy1RJ/RCebrfXQUXcBHNWlBAA6cNoLZKbne7OENJqELl0Xw==", null, false, null, "061e17df-3b3a-42dd-83b0-8ce577411a5d", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Photo", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3f001d71-955e-42ae-9eb7-ad70f892f064", 0, "05577179-5006-448f-9761-aa9004fd0f50", null, false, false, null, null, "STAFF", "AQAAAAEAACcQAAAAEA/FXkj/ETMMUsALvFuJfC4/CvtR9TmQFTgIXC3/WEtnl6JVLgOM1UO6sW5c2y8Lpw==", null, false, null, "3cf03713-bfac-4d84-890f-05cc08abaea1", false, "staff" });
        }
    }
}
