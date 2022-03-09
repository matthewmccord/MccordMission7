using Microsoft.EntityFrameworkCore.Migrations;

namespace MccordMission7.Migrations
{
    public partial class Purchased : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "PurchaseRecorded",
                table: "Purchases",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PurchaseRecorded",
                table: "Purchases");
        }
    }
}
