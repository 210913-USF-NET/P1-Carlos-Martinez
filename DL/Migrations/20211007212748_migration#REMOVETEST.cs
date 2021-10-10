using Microsoft.EntityFrameworkCore.Migrations;

namespace DL.Migrations
{
    public partial class migrationREMOVETEST : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TooBad",
                table: "StoreFronts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TooBad",
                table: "StoreFronts",
                type: "text",
                nullable: true);
        }
    }
}
