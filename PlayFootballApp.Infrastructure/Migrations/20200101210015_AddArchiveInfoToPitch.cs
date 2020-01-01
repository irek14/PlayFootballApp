using Microsoft.EntityFrameworkCore.Migrations;

namespace PlayFootballApp.DataAccess.Migrations
{
    public partial class AddArchiveInfoToPitch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "Pitch",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "Pitch");
        }
    }
}
