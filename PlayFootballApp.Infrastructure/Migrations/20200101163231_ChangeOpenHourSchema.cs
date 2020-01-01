using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PlayFootballApp.DataAccess.Migrations
{
    public partial class ChangeOpenHourSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PitchOpenHours_OpenHour",
                table: "PitchOpenHours");

            migrationBuilder.DropTable(
                name: "OpenHour");

            migrationBuilder.DropIndex(
                name: "IX_PitchOpenHours_OpenHourId",
                table: "PitchOpenHours");

            migrationBuilder.DropColumn(
                name: "OpenHourId",
                table: "PitchOpenHours");

            migrationBuilder.AddColumn<string>(
                name: "EndHour",
                table: "PitchOpenHours",
                maxLength: 8,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StartHour",
                table: "PitchOpenHours",
                maxLength: 8,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "WeekDay",
                table: "PitchOpenHours",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndHour",
                table: "PitchOpenHours");

            migrationBuilder.DropColumn(
                name: "StartHour",
                table: "PitchOpenHours");

            migrationBuilder.DropColumn(
                name: "WeekDay",
                table: "PitchOpenHours");

            migrationBuilder.AddColumn<Guid>(
                name: "OpenHourId",
                table: "PitchOpenHours",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "OpenHour",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EndHour = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    StartHour = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenHour", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PitchOpenHours_OpenHourId",
                table: "PitchOpenHours",
                column: "OpenHourId");

            migrationBuilder.AddForeignKey(
                name: "FK_PitchOpenHours_OpenHour",
                table: "PitchOpenHours",
                column: "OpenHourId",
                principalTable: "OpenHour",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
