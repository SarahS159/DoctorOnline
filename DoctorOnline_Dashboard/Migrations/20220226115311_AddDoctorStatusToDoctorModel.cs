using Microsoft.EntityFrameworkCore.Migrations;

namespace DoctorOnline_Dashboard.Migrations
{
    public partial class AddDoctorStatusToDoctorModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "doctorStatus",
                table: "Doctors",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "doctorStatus",
                table: "Doctors");
        }
    }
}
