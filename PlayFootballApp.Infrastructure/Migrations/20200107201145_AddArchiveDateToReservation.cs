using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PlayFootballApp.DataAccess.Migrations
{
    public partial class AddArchiveDateToReservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CancelDate",
                table: "Reservation",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "Reservation",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CancelDate",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "Reservation");
        }
    }
}
