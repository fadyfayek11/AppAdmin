using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Admin.Migrations
{
    public partial class addRoomDescriptions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "DescriptionAr",
                table: "RoomDetails");

            migrationBuilder.DropColumn(
                name: "DescriptionEn",
                table: "RoomDetails");

            migrationBuilder.AddColumn<int>(
                name: "RoomDetailsId",
                table: "RoomDetails",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Photo", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "31d7d9a9-79b6-4d6e-af4b-b8aebb3c0405", 0, "eb2c5667-ed4d-4f4d-b704-b8f34ab65c37", null, false, false, null, null, "ADMIN", "AQAAAAEAACcQAAAAEGgLLewh/n6qvl5mfcu5qW9DBPMr17JaI+9ttddnNNqvCDeeJfIHmRhtkovSQf2fWw==", null, false, null, "76603255-eeb2-4b3d-9f7b-a7c772b34267", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Photo", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "92c0bbda-8809-48e2-979b-656c34286c80", 0, "d067e2e0-5f71-4a5e-9ed3-1a932c793c4d", null, false, false, null, null, "STAFF", "AQAAAAEAACcQAAAAELQbnw9xlxhV28+drrbAWfpxJql7NxG+AJMg2G4JJEqoC6P4jK43heO4eER1Ds1GeQ==", null, false, null, "88c6d5b2-de0c-48ba-b8b4-3a5217d5eba3", false, "staff" });

            migrationBuilder.CreateIndex(
                name: "IX_RoomDetails_RoomDetailsId",
                table: "RoomDetails",
                column: "RoomDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomDetails_RoomDetails_RoomDetailsId",
                table: "RoomDetails",
                column: "RoomDetailsId",
                principalTable: "RoomDetails",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomDetails_RoomDetails_RoomDetailsId",
                table: "RoomDetails");

            migrationBuilder.DropIndex(
                name: "IX_RoomDetails_RoomDetailsId",
                table: "RoomDetails");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "31d7d9a9-79b6-4d6e-af4b-b8aebb3c0405");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "92c0bbda-8809-48e2-979b-656c34286c80");

            migrationBuilder.DropColumn(
                name: "RoomDetailsId",
                table: "RoomDetails");

            migrationBuilder.AddColumn<string>(
                name: "DescriptionAr",
                table: "RoomDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DescriptionEn",
                table: "RoomDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Photo", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "199a2a2d-bd6a-437e-984b-12cf84f62f5c", 0, "7dff5aac-5b89-4715-9e27-914a2362bc0f", null, false, false, null, null, "ADMIN", "AQAAAAEAACcQAAAAEK9vJkdPWGg+iwV7m7D5JWp7Xbf3nmhM7V5FtM72Mk1y1oGRgCEvOTp7evxtmk7img==", null, false, null, "5dcfec64-cf3d-40f6-995f-6e3cb1f9ba0c", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Photo", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3dee8682-972a-4867-add6-f558b3b96de9", 0, "47f95148-d2fc-4b62-a713-0b4670665ed2", null, false, false, null, null, "STAFF", "AQAAAAEAACcQAAAAEHy8uqUVSCUXoqlwqZOvygEzKqBvJ76UF93OoyPZ11Yafv9kcTXHlA1HmRo9qyXRAQ==", null, false, null, "84190077-f348-474f-9c53-262352aa2a80", false, "staff" });
        }
    }
}
