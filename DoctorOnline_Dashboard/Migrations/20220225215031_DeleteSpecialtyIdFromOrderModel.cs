﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace DoctorOnline_Dashboard.Migrations
{
    public partial class DeleteSpecialtyIdFromOrderModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Specialities_specialityId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_specialityId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "specialityId",
                table: "Orders");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "specialityId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_specialityId",
                table: "Orders",
                column: "specialityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Specialities_specialityId",
                table: "Orders",
                column: "specialityId",
                principalTable: "Specialities",
                principalColumn: "specialityId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
