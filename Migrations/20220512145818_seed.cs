using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentistBookingForm.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71c70f75-a2e5-4d67-a96d-65b60d6798b8",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "62a2fe1e-c290-4043-a682-adb52dfdf19b", "51b72ef2-df2d-4e70-8cef-b3dc7b2cb9ed" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71c70f75-a2e5-4d67-a96d-65b60d6798b8",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "511d4562-40a3-49ed-9733-0040f2dbc3e6", "073869d7-6b93-45ea-a1fa-d549f55e386c" });
        }
    }
}
