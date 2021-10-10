using Microsoft.EntityFrameworkCore.Migrations;

namespace DL.Migrations
{
    public partial class migration05 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Product",
                table: "Inventory");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_ProductId",
                table: "Inventory",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_StoreFrontId",
                table: "Inventory",
                column: "StoreFrontId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Products_ProductId",
                table: "Inventory",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_StoreFronts_StoreFrontId",
                table: "Inventory",
                column: "StoreFrontId",
                principalTable: "StoreFronts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Products_ProductId",
                table: "Inventory");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_StoreFronts_StoreFrontId",
                table: "Inventory");

            migrationBuilder.DropIndex(
                name: "IX_Inventory_ProductId",
                table: "Inventory");

            migrationBuilder.DropIndex(
                name: "IX_Inventory_StoreFrontId",
                table: "Inventory");

            migrationBuilder.AddColumn<string>(
                name: "Product",
                table: "Inventory",
                type: "text",
                nullable: true);
        }
    }
}
