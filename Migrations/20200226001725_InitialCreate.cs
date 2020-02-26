using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MegaDesk2.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Desk",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Width = table.Column<int>(nullable: false),
                    Depth = table.Column<int>(nullable: false),
                    NumDrawers = table.Column<int>(nullable: false),
                    Shipping = table.Column<string>(nullable: true),
                    Material = table.Column<int>(nullable: false),
                    QuoteDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desk", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Desk");
        }
    }
}
