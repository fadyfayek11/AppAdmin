using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Admin.Migrations
{
    public partial class addRoomDescriptionsKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "DetailsDescription",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescriptionEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoomDetailsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailsDescription", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetailsDescription_RoomDetails_RoomDetailsId",
                        column: x => x.RoomDetailsId,
                        principalTable: "RoomDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Photo", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "344d01e6-ff12-41b8-a28f-72856e0eeebc", 0, "093bf302-ce98-417e-a9ee-3b70de975217", null, false, false, null, null, "ADMIN", "AQAAAAEAACcQAAAAEJzF8ehr3eJaBD4lJhdgy1RJ/RCebrfXQUXcBHNWlBAA6cNoLZKbne7OENJqELl0Xw==", null, false, null, "061e17df-3b3a-42dd-83b0-8ce577411a5d", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Photo", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3f001d71-955e-42ae-9eb7-ad70f892f064", 0, "05577179-5006-448f-9761-aa9004fd0f50", null, false, false, null, null, "STAFF", "AQAAAAEAACcQAAAAEA/FXkj/ETMMUsALvFuJfC4/CvtR9TmQFTgIXC3/WEtnl6JVLgOM1UO6sW5c2y8Lpw==", null, false, null, "3cf03713-bfac-4d84-890f-05cc08abaea1", false, "staff" });

            migrationBuilder.CreateIndex(
                name: "IX_DetailsDescription_RoomDetailsId",
                table: "DetailsDescription",
                column: "RoomDetailsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetailsDescription");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "344d01e6-ff12-41b8-a28f-72856e0eeebc");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f001d71-955e-42ae-9eb7-ad70f892f064");

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
    }
}
