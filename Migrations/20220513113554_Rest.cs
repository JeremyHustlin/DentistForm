using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentistBookingForm.Migrations
{
    public partial class Rest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserNameDoc",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71c70f75-a2e5-4d67-a96d-65b60d6798b8",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp", "UserName", "UserNameDoc" },
                values: new object[] { "e0553ccd-87d8-403c-a2a0-cfe1272eb359", "412a0046-68e8-4fb5-9e2a-d02c45061165", null, "Vanea" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserNameDoc",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71c70f75-a2e5-4d67-a96d-65b60d6798b8",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp", "UserName" },
                values: new object[] { "03242bbb-185a-41fc-8b29-fdaae3344a4e", "391e3315-ca36-4fd3-9498-30d7fd2754bb", "Vanea" });
        }
    }
}
