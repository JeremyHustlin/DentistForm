using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentistBookingForm.Migrations
{
    public partial class TestDocId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AvailableTimeSlots_AspNetUsers_DoctorId",
                table: "AvailableTimeSlots");

            migrationBuilder.DropForeignKey(
                name: "FK_Procedures_AspNetUsers_DoctorId",
                table: "Procedures");

            migrationBuilder.AlterColumn<string>(
                name: "DoctorId",
                table: "Procedures",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DoctorId",
                table: "AvailableTimeSlots",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Abilities",
                columns: new[] { "Id", "DoctorId", "Name" },
                values: new object[] { 1, "71c70f75-a2e5-4d67-a96d-65b60d6798b8", "Inalbire" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71c70f75-a2e5-4d67-a96d-65b60d6798b8",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "511d4562-40a3-49ed-9733-0040f2dbc3e6", "073869d7-6b93-45ea-a1fa-d549f55e386c" });

            migrationBuilder.AddForeignKey(
                name: "FK_AvailableTimeSlots_AspNetUsers_DoctorId",
                table: "AvailableTimeSlots",
                column: "DoctorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Procedures_AspNetUsers_DoctorId",
                table: "Procedures",
                column: "DoctorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AvailableTimeSlots_AspNetUsers_DoctorId",
                table: "AvailableTimeSlots");

            migrationBuilder.DropForeignKey(
                name: "FK_Procedures_AspNetUsers_DoctorId",
                table: "Procedures");

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<string>(
                name: "DoctorId",
                table: "Procedures",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "DoctorId",
                table: "AvailableTimeSlots",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71c70f75-a2e5-4d67-a96d-65b60d6798b8",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "4218ccbd-98c1-4942-bc51-dc57e58e5594", "7e39ab6c-a4ed-48bf-8a73-e747dab85d35" });

            migrationBuilder.AddForeignKey(
                name: "FK_AvailableTimeSlots_AspNetUsers_DoctorId",
                table: "AvailableTimeSlots",
                column: "DoctorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Procedures_AspNetUsers_DoctorId",
                table: "Procedures",
                column: "DoctorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
