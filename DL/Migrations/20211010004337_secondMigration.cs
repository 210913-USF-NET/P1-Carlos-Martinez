using Microsoft.EntityFrameworkCore.Migrations;

namespace DL.Migrations
{
    public partial class secondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Products_ProductId",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "StoreFrontID",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "hasDefaultStore",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "StoreFronts",
                newName: "StoreName");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "LineItem",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "OrdersId",
                table: "LineItem",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Inventory",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Customers",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Customers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_StoreFrontId",
                table: "Orders",
                column: "StoreFrontId");

            migrationBuilder.CreateIndex(
                name: "IX_LineItem_OrdersId",
                table: "LineItem",
                column: "OrdersId");

            migrationBuilder.CreateIndex(
                name: "IX_LineItem_ProductId",
                table: "LineItem",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Products_ProductId",
                table: "Inventory",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LineItem_Orders_OrdersId",
                table: "LineItem",
                column: "OrdersId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LineItem_Products_ProductId",
                table: "LineItem",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_StoreFronts_StoreFrontId",
                table: "Orders",
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
                name: "FK_LineItem_Orders_OrdersId",
                table: "LineItem");

            migrationBuilder.DropForeignKey(
                name: "FK_LineItem_Products_ProductId",
                table: "LineItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_StoreFronts_StoreFrontId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_StoreFrontId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_LineItem_OrdersId",
                table: "LineItem");

            migrationBuilder.DropIndex(
                name: "IX_LineItem_ProductId",
                table: "LineItem");

            migrationBuilder.DropColumn(
                name: "OrdersId",
                table: "LineItem");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "StoreName",
                table: "StoreFronts",
                newName: "Name");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "LineItem",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Inventory",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Customers",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Customers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StoreFrontID",
                table: "Customers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "hasDefaultStore",
                table: "Customers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Products_ProductId",
                table: "Inventory",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
