using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentistBookingForm.Migrations
{
    public partial class DoctorSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "71c70f75-a2e5-4d67-a96d-65b60d6798b8", 0, "8f77f9b8-16f2-499d-8fe6-df86ac347b9f", "Doctor", "example@example.com", false, false, null, null, null, null, null, false, "a41b0974-19a9-408a-8d27-8dc08ead9d2c", false, "Vanea" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71c70f75-a2e5-4d67-a96d-65b60d6798b8");
        }
    }
}
