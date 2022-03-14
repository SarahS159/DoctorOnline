using Microsoft.EntityFrameworkCore.Migrations;

namespace DoctorOnline_Dashboard.Migrations
{
    public partial class ChangeOrderCostDataTypeToDouble : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "orderCost",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "orderCost",
                table: "Orders",
                type: "int",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
