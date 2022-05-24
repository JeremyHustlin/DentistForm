using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentistBookingForm.Migrations
{
    public partial class removedUnusedField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserNameDoc",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserNameDoc",
                table: "Abilities");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71c70f75-a2e5-4d67-a96d-65b60d6798b8",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "5d263de0-4e33-4bbc-97b4-3f9c647f2699", "2859257a-0574-47bc-b524-2c0b367270f6" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserNameDoc",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserNameDoc",
                table: "Abilities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserNameDoc",
                value: "Vanea");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71c70f75-a2e5-4d67-a96d-65b60d6798b8",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp", "UserNameDoc" },
                values: new object[] { "4c3e44e7-2150-421e-9469-8d14758dce75", "e592082d-e901-41a5-8c77-dd019b622043", "Vanea" });
        }
    }
}
