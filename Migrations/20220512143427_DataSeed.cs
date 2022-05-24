using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentistBookingForm.Migrations
{
    public partial class DataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Abilities_AspNetUsers_DoctorId",
                table: "Abilities");

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<string>(
                name: "DoctorId",
                table: "Abilities",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71c70f75-a2e5-4d67-a96d-65b60d6798b8",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "4218ccbd-98c1-4942-bc51-dc57e58e5594", "7e39ab6c-a4ed-48bf-8a73-e747dab85d35" });

            migrationBuilder.AddForeignKey(
                name: "FK_Abilities_AspNetUsers_DoctorId",
                table: "Abilities",
                column: "DoctorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Abilities_AspNetUsers_DoctorId",
                table: "Abilities");

            migrationBuilder.AlterColumn<string>(
                name: "DoctorId",
                table: "Abilities",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.InsertData(
                table: "Abilities",
                columns: new[] { "Id", "DoctorId", "Name" },
                values: new object[] { 1, null, "Mihai" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71c70f75-a2e5-4d67-a96d-65b60d6798b8",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "11643fe3-be66-4949-9761-978e12de33d9", "adc769de-1108-4fc3-b476-6fc878693ea6" });

            migrationBuilder.AddForeignKey(
                name: "FK_Abilities_AspNetUsers_DoctorId",
                table: "Abilities",
                column: "DoctorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
