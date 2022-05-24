using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentistBookingForm.Migrations
{
    public partial class TestExemple5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71c70f75-a2e5-4d67-a96d-65b60d6798b8",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "5902e289-f555-4851-8acb-b899f0534c1f", "4fb2382a-355a-4d0b-8725-01d1a242c0c2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71c70f75-a2e5-4d67-a96d-65b60d6798b8",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "5d263de0-4e33-4bbc-97b4-3f9c647f2699", "2859257a-0574-47bc-b524-2c0b367270f6" });
        }
    }
}
