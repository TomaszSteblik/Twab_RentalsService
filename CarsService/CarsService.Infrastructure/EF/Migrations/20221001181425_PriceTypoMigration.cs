using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarsService.Infrastructure.Migrations
{
    public partial class PriceTypoMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DollarsPerHours",
                table: "Cars",
                newName: "DollarsPerHour");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DollarsPerHour",
                table: "Cars",
                newName: "DollarsPerHours");
        }
    }
}
