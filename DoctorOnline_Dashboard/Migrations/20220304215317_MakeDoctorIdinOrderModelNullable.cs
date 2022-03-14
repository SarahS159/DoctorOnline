using Microsoft.EntityFrameworkCore.Migrations;

namespace DoctorOnline_Dashboard.Migrations
{
    public partial class MakeDoctorIdinOrderModelNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
              name: "doctorId",
              table: "Orders",
              nullable: true,
              oldClrType: typeof(int),
              oldType: "int)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
             name: "doctorId",
             table: "Orders",
             type: "int",
             nullable: false,
             oldClrType: typeof(int),
             oldNullable: false);
        }
    }
}
