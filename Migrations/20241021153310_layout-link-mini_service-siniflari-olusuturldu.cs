using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DgmBobinajServer.Migrations
{
    /// <inheritdoc />
    public partial class layoutlinkmini_servicesiniflariolusuturldu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Layouts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Subtitle = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Layouts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Links",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Url = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false),
                    LinkType = table.Column<int>(type: "int", nullable: false),
                    LayoutId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Links_Layouts_LayoutId",
                        column: x => x.LayoutId,
                        principalTable: "Layouts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MiniServices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Subtitle = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LayoutId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MiniServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MiniServices_Layouts_LayoutId",
                        column: x => x.LayoutId,
                        principalTable: "Layouts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Links_LayoutId",
                table: "Links",
                column: "LayoutId");

            migrationBuilder.CreateIndex(
                name: "IX_MiniServices_LayoutId",
                table: "MiniServices",
                column: "LayoutId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Links");

            migrationBuilder.DropTable(
                name: "MiniServices");

            migrationBuilder.DropTable(
                name: "Layouts");
        }
    }
}
