using Microsoft.EntityFrameworkCore.Migrations;

namespace DoctorOnline_Dashboard.Migrations
{
    public partial class dropForeignKeyconstraintOnDoctorIdinOrderModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Doctors_doctorId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_doctorId",
                table: "Orders");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Orders_doctorId",
                table: "Orders",
                column: "doctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Doctors_doctorId",
                table: "Orders",
                column: "doctorId",
                principalTable: "Doctors",
                principalColumn: "doctorId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
