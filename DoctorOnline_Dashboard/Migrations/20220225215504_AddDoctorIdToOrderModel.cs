using Microsoft.EntityFrameworkCore.Migrations;

namespace DoctorOnline_Dashboard.Migrations
{
    public partial class AddDoctorIdToOrderModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "doctorid",
                table: "Orders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_doctorid",
                table: "Orders",
                column: "doctorid");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Doctors_doctorid",
                table: "Orders",
                column: "doctorid",
                principalTable: "Doctors",
                principalColumn: "doctorId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Doctors_doctorid",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_doctorid",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "doctorid",
                table: "Orders");
        }
    }
}
