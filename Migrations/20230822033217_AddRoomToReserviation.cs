using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Admin.Migrations
{
    public partial class AddRoomToReserviation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "82f526e2-9e2c-4841-99ef-f9f905d1b152");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "df3dc5e6-70da-4039-98ef-3f8a17b99dbb");

            migrationBuilder.AddColumn<string>(
                name: "DescriptionAr",
                table: "Testimonies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TitleAr",
                table: "Testimonies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TitleAr",
                table: "News",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Photo", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "272fc19f-17cc-4d67-86b3-9b70ab6670cb", 0, "886c1d2c-2ee5-481d-94fa-e6441eb82a11", null, false, false, null, null, "STAFF", "AQAAAAEAACcQAAAAEEfSPotjVmAMYyvCBVCXt3N0OnFPV29c5qdfYeazUawxrKStYsRtDOLkVFh75STeRg==", null, false, null, "abffacd4-6d9e-4c55-9393-cdfa5069314d", false, "staff" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Photo", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c440d4c7-a024-480f-867c-deb6cdf1478a", 0, "db2e070a-6ff5-42ff-8dab-e702a587ebd3", null, false, false, null, null, "ADMIN", "AQAAAAEAACcQAAAAEGy9gCSorKHzcXu+BOwWBWUjM3VgTC0TMs/EGz0vUK1vqdHHdXYJDos4oFB6QrprGg==", null, false, null, "aa742245-6b86-43db-ab33-7907e7a3b994", false, "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_RoomId",
                table: "Reservations",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Rooms_RoomId",
                table: "Reservations",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Rooms_RoomId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_RoomId",
                table: "Reservations");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "272fc19f-17cc-4d67-86b3-9b70ab6670cb");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c440d4c7-a024-480f-867c-deb6cdf1478a");

            migrationBuilder.DropColumn(
                name: "DescriptionAr",
                table: "Testimonies");

            migrationBuilder.DropColumn(
                name: "TitleAr",
                table: "Testimonies");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "TitleAr",
                table: "News");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Photo", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "82f526e2-9e2c-4841-99ef-f9f905d1b152", 0, "ac904514-6f41-45b8-bf37-e2ffd61d3754", null, false, false, null, null, "ADMIN", "AQAAAAEAACcQAAAAED/l6sAi5PjY02xvFKD6A0zcBlNpRj2vrGCTp9x8VfYO8U82AJjChyd+/Grq8yNLqA==", null, false, null, "7297433e-1083-4038-9c62-9376f0591c16", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Photo", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "df3dc5e6-70da-4039-98ef-3f8a17b99dbb", 0, "9f04c9f7-786a-401e-a6bf-f0cceb26d7c6", null, false, false, null, null, "STAFF", "AQAAAAEAACcQAAAAENZCs4cXe+P7vrmTzCdSSei4CEiU4I09C3TNolBqc35IHPI5p/I3F9bGT9PR5tXpcw==", null, false, null, "489c64ac-2dcf-4a77-bcd6-c69dcc77b0bd", false, "staff" });
        }
    }
}
