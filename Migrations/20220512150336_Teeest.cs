using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentistBookingForm.Migrations
{
    public partial class Teeest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71c70f75-a2e5-4d67-a96d-65b60d6798b8",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "453157aa-8950-481c-9db0-b7c68a751b94", "094c1112-7f5f-455c-9d53-f7dca655e8c0" });

            migrationBuilder.InsertData(
                table: "Procedures",
                columns: new[] { "Id", "DoctorId", "Name" },
                values: new object[] { 1, "71c70f75-a2e5-4d67-a96d-65b60d6798b8", "Curatenie" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Procedures",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71c70f75-a2e5-4d67-a96d-65b60d6798b8",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "62a2fe1e-c290-4043-a682-adb52dfdf19b", "51b72ef2-df2d-4e70-8cef-b3dc7b2cb9ed" });
        }
    }
}
