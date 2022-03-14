using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DoctorOnline_Dashboard.Migrations
{
    public partial class UpdateTheNameOrderModelAndItsFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConsultantOrders");

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    orderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    orderCost = table.Column<int>(nullable: false),
                    patientId = table.Column<int>(nullable: false),
                    specialityId = table.Column<int>(nullable: false),
                    orderDate = table.Column<DateTime>(nullable: false),
                    orderStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.orderId);
                    table.ForeignKey(
                        name: "FK_Orders_Patients_patientId",
                        column: x => x.patientId,
                        principalTable: "Patients",
                        principalColumn: "patientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Specialities_specialityId",
                        column: x => x.specialityId,
                        principalTable: "Specialities",
                        principalColumn: "specialityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_patientId",
                table: "Orders",
                column: "patientId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_specialityId",
                table: "Orders",
                column: "specialityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.CreateTable(
                name: "ConsultantOrders",
                columns: table => new
                {
                    consultantOrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    consultantCost = table.Column<int>(type: "int", nullable: false),
                    consultantDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    consultantStatus = table.Column<int>(type: "int", nullable: false),
                    patientId = table.Column<int>(type: "int", nullable: false),
                    specialityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsultantOrders", x => x.consultantOrderId);
                    table.ForeignKey(
                        name: "FK_ConsultantOrders_Patients_patientId",
                        column: x => x.patientId,
                        principalTable: "Patients",
                        principalColumn: "patientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConsultantOrders_Specialities_specialityId",
                        column: x => x.specialityId,
                        principalTable: "Specialities",
                        principalColumn: "specialityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConsultantOrders_patientId",
                table: "ConsultantOrders",
                column: "patientId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsultantOrders_specialityId",
                table: "ConsultantOrders",
                column: "specialityId");
        }
    }
}
