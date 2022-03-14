using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DoctorOnline_Dashboard.Migrations
{
    public partial class UpdateFieldsInfoInOrderModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Doctors_doctorid",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "orderDate",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "doctorid",
                table: "Orders",
                newName: "doctorId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_doctorid",
                table: "Orders",
                newName: "IX_Orders_doctorId");

            migrationBuilder.AddColumn<DateTime>(
                name: "changeStatusDate",
                table: "Orders",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "requestedDate",
                table: "Orders",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Doctors_doctorId",
                table: "Orders",
                column: "doctorId",
                principalTable: "Doctors",
                principalColumn: "doctorId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Doctors_doctorId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "changeStatusDate",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "requestedDate",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "doctorId",
                table: "Orders",
                newName: "doctorid");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_doctorId",
                table: "Orders",
                newName: "IX_Orders_doctorid");

            migrationBuilder.AddColumn<DateTime>(
                name: "orderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Doctors_doctorid",
                table: "Orders",
                column: "doctorid",
                principalTable: "Doctors",
                principalColumn: "doctorId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
