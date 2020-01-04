using Microsoft.EntityFrameworkCore.Migrations;

namespace PlayFootballApp.DataAccess.Migrations
{
    public partial class AddReservedSpotsToSingleReservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReservedSpots",
                table: "Reservation",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReservedSpots",
                table: "Reservation");
        }
    }
}
