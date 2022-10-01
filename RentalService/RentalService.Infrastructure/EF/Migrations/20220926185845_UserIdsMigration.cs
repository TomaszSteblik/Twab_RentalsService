using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalService.Infrastructure.Migrations
{
    public partial class UserIdsMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Rentals",
                table: "Rentals");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Rentals",
                newName: "RenterId");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Rentals",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "OwnerId",
                table: "Cars",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rentals",
                table: "Rentals",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Rentals",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Cars");

            migrationBuilder.RenameColumn(
                name: "RenterId",
                table: "Rentals",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rentals",
                table: "Rentals",
                column: "Id");
        }
    }
}
