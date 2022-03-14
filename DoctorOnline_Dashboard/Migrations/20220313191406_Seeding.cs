using Microsoft.EntityFrameworkCore.Migrations;

namespace DoctorOnline_Dashboard.Migrations
{
    public partial class Seeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into Schedules(doctorId, startDate, endDate, creationDate) values (3, '2022-03-13 08:00:00','2022-03-14 18:30:00', SYSDATETIME()) ");
            migrationBuilder.Sql("insert into Schedules(doctorId, startDate, endDate, creationDate) values (1, '2022-03-13 08:00:00','2022-03-14 18:30:00', SYSDATETIME()) ");
            migrationBuilder.Sql("insert into Schedules(doctorId, startDate, endDate, creationDate) values (2, '2022-03-13 08:00:00','2022-03-14 18:30:00', SYSDATETIME()) ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
