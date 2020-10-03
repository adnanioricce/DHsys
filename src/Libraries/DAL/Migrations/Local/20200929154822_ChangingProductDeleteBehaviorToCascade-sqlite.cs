using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations.Local
{
    public partial class ChangingProductDeleteBehaviorToCascadesqlite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductSupplier_Products_ProductId",
                table: "ProductSupplier");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSupplier_Products_ProductId",
                table: "ProductSupplier",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.DropForeignKey(
                name: "FK_Products_StockEntry_StockEntryId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "DrugInformation");

            migrationBuilder.DropIndex(
                name: "IX_Products_StockEntryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "TransactionTotal",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "SupplierName",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "DrugMaturityDate",
                table: "StockEntry");

            migrationBuilder.DropColumn(
                name: "LotCode",
                table: "StockEntry");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "StockEntry");

            migrationBuilder.DropColumn(
                name: "DrugCost",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DrugName",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "StockEntryId",
                table: "Products");


            migrationBuilder.AddColumn<string>(
                name: "LotCode",
                table: "ProductStockEntry",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ProductMaturityDate",
                table: "ProductStockEntry",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "ProductStockEntry",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Products",
                nullable: true);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductSupplier_Products_ProductId",
                table: "ProductSupplier");
            

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSupplier_Products_ProductId",
                table: "ProductSupplier",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
