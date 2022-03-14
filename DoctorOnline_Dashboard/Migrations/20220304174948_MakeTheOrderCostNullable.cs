using Microsoft.EntityFrameworkCore.Migrations;

namespace DoctorOnline_Dashboard.Migrations
{
    public partial class MakeTheOrderCostNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
              name: "orderCost",
              table: "Orders",
              nullable: true,
              oldClrType: typeof(double),
              oldType: "float)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
           name: "orderCost",
           table: "Orders",
           type: "float",
           nullable: false,
           oldClrType: typeof(double),
           oldNullable: false);
        }
    }
}
