using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations.Local
{
    public partial class RemovingFieldsAndEditingRelationssqlite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_StockEntry_StockEntryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_StockEntryId",
                table: "Products");

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

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "LotCode",
                table: "ProductStockEntry");

            migrationBuilder.DropColumn(
                name: "ProductMaturityDate",
                table: "ProductStockEntry");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "ProductStockEntry");
           

            migrationBuilder.AddColumn<decimal>(
                name: "DrugCost",
                table: "Products",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StockEntryId",
                table: "Products",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProdutoId",
                table: "Products",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_StockEntryId",
                table: "Products",
                column: "StockEntryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_StockEntry_StockEntryId",
                table: "Products",
                column: "StockEntryId",
                principalTable: "StockEntry",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
