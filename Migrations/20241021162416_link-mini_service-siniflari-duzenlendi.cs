using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DgmBobinajServer.Migrations
{
    /// <inheritdoc />
    public partial class linkmini_servicesiniflariduzenlendi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Links_Layouts_LayoutId",
                table: "Links");

            migrationBuilder.DropForeignKey(
                name: "FK_MiniServices_Layouts_LayoutId",
                table: "MiniServices");

            migrationBuilder.DropIndex(
                name: "IX_MiniServices_LayoutId",
                table: "MiniServices");

            migrationBuilder.DropIndex(
                name: "IX_Links_LayoutId",
                table: "Links");

            migrationBuilder.DropColumn(
                name: "LayoutId",
                table: "MiniServices");

            migrationBuilder.DropColumn(
                name: "LayoutId",
                table: "Links");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "LayoutId",
                table: "MiniServices",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LayoutId",
                table: "Links",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MiniServices_LayoutId",
                table: "MiniServices",
                column: "LayoutId");

            migrationBuilder.CreateIndex(
                name: "IX_Links_LayoutId",
                table: "Links",
                column: "LayoutId");

            migrationBuilder.AddForeignKey(
                name: "FK_Links_Layouts_LayoutId",
                table: "Links",
                column: "LayoutId",
                principalTable: "Layouts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MiniServices_Layouts_LayoutId",
                table: "MiniServices",
                column: "LayoutId",
                principalTable: "Layouts",
                principalColumn: "Id");
        }
    }
}
