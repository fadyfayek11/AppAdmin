using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Admin.Migrations
{
    public partial class allowNullForRoomDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "272fc19f-17cc-4d67-86b3-9b70ab6670cb");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c440d4c7-a024-480f-867c-deb6cdf1478a");

            migrationBuilder.AlterColumn<string>(
                name: "DescriptionEn",
                table: "RoomDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "DescriptionAr",
                table: "RoomDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Photo", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "609b55a1-8d6c-4262-9109-120c976b9dc2", 0, "455f5ee5-1186-4792-858d-9a1f99637c3b", null, false, false, null, null, "STAFF", "AQAAAAEAACcQAAAAEPsijVzy/3Wju+sb8i/aiS0p6dGabcanCmgeNHLbf7oNEaeaSBw/QHECHgaBLHl8vw==", null, false, null, "a96f63d0-8230-49a9-811b-5916ec61fc2b", false, "staff" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Photo", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "886d2197-87e9-475c-bfac-e5ecd76f0477", 0, "33598d1f-b856-4177-a21c-57f8f78f1132", null, false, false, null, null, "ADMIN", "AQAAAAEAACcQAAAAEBbxruihgkSZ33RoyyLOosSB54L/0hWNDchIoln2oXZsn8PCl/yvd1vk7uqMHgJRyg==", null, false, null, "79a88452-b80c-41c9-8d86-36b77054c793", false, "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "609b55a1-8d6c-4262-9109-120c976b9dc2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "886d2197-87e9-475c-bfac-e5ecd76f0477");

            migrationBuilder.AlterColumn<string>(
                name: "DescriptionEn",
                table: "RoomDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DescriptionAr",
                table: "RoomDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Photo", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "272fc19f-17cc-4d67-86b3-9b70ab6670cb", 0, "886c1d2c-2ee5-481d-94fa-e6441eb82a11", null, false, false, null, null, "STAFF", "AQAAAAEAACcQAAAAEEfSPotjVmAMYyvCBVCXt3N0OnFPV29c5qdfYeazUawxrKStYsRtDOLkVFh75STeRg==", null, false, null, "abffacd4-6d9e-4c55-9393-cdfa5069314d", false, "staff" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Photo", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c440d4c7-a024-480f-867c-deb6cdf1478a", 0, "db2e070a-6ff5-42ff-8dab-e702a587ebd3", null, false, false, null, null, "ADMIN", "AQAAAAEAACcQAAAAEGy9gCSorKHzcXu+BOwWBWUjM3VgTC0TMs/EGz0vUK1vqdHHdXYJDos4oFB6QrprGg==", null, false, null, "aa742245-6b86-43db-ab33-7907e7a3b994", false, "admin" });
        }
    }
}
