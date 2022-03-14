using Microsoft.EntityFrameworkCore.Migrations;

namespace DoctorOnline_Dashboard.Migrations
{
    public partial class AddDoctorNameAndSpecialitytitleToOrdermodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "doctorName",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "specialityTitle",
                table: "Orders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "doctorName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "specialityTitle",
                table: "Orders");
        }
    }
}
