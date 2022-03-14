using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DoctorOnline_Dashboard.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medicaments",
                columns: table => new
                {
                    medicamentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    medicamentName = table.Column<string>(nullable: false),
                    medicamentCount = table.Column<int>(nullable: false),
                    medicamentSchedule = table.Column<string>(nullable: false),
                    medicamentCost = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicaments", x => x.medicamentId);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    patientId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    patientName = table.Column<string>(nullable: false),
                    patientPassword = table.Column<string>(nullable: false),
                    patientGsm = table.Column<string>(nullable: false),
                    patientAge = table.Column<int>(nullable: false),
                    patientGender = table.Column<string>(nullable: false),
                    patientCity = table.Column<string>(nullable: true),
                    verificationCode = table.Column<string>(nullable: false),
                    isActive = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.patientId);
                });

            migrationBuilder.CreateTable(
                name: "Specialities",
                columns: table => new
                {
                    specialityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    specialityTitle = table.Column<string>(nullable: false),
                    specialityDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialities", x => x.specialityId);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    ticketId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ticketDescription = table.Column<string>(nullable: false),
                    patientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.ticketId);
                    table.ForeignKey(
                        name: "FK_Tickets_Patients_patientId",
                        column: x => x.patientId,
                        principalTable: "Patients",
                        principalColumn: "patientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConsultantOrders",
                columns: table => new
                {
                    consultantOrderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    consultantCost = table.Column<int>(nullable: false),
                    patientId = table.Column<int>(nullable: false),
                    specialityId = table.Column<int>(nullable: false),
                    consultantDate = table.Column<DateTime>(nullable: false),
                    consultantStatus = table.Column<int>(nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    doctorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    doctorName = table.Column<string>(nullable: false),
                    doctorPassword = table.Column<string>(nullable: false),
                    doctorGsm = table.Column<string>(nullable: false),
                    doctorSpeciality = table.Column<string>(nullable: false),
                    doctorCity = table.Column<string>(nullable: false),
                    doctorAddress = table.Column<string>(nullable: false),
                    doctorSchedule = table.Column<string>(nullable: false),
                    specialityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.doctorId);
                    table.ForeignKey(
                        name: "FK_Doctors_Specialities_specialityId",
                        column: x => x.specialityId,
                        principalTable: "Specialities",
                        principalColumn: "specialityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Patients_Doctors",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    patientId = table.Column<int>(nullable: false),
                    doctorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients_Doctors", x => x.id);
                    table.ForeignKey(
                        name: "FK_Patients_Doctors_Doctors_doctorId",
                        column: x => x.doctorId,
                        principalTable: "Doctors",
                        principalColumn: "doctorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Patients_Doctors_Patients_patientId",
                        column: x => x.patientId,
                        principalTable: "Patients",
                        principalColumn: "patientId",
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

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_specialityId",
                table: "Doctors",
                column: "specialityId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_Doctors_doctorId",
                table: "Patients_Doctors",
                column: "doctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_Doctors_patientId",
                table: "Patients_Doctors",
                column: "patientId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_patientId",
                table: "Tickets",
                column: "patientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConsultantOrders");

            migrationBuilder.DropTable(
                name: "Medicaments");

            migrationBuilder.DropTable(
                name: "Patients_Doctors");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Specialities");
        }
    }
}
