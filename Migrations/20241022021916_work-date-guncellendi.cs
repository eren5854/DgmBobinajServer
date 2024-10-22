using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DgmBobinajServer.Migrations
{
    /// <inheritdoc />
    public partial class workdateguncellendi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "WorkDates");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "WorkDates");

            migrationBuilder.AddColumn<string>(
                name: "Time",
                table: "WorkDates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Time",
                table: "WorkDates");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "WorkDates",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartTime",
                table: "WorkDates",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
