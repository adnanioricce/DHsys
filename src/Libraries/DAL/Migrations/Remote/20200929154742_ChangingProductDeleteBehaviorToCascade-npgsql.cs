using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations.Remote
{
    public partial class ChangingProductDeleteBehaviorToCascadenpgsql : Migration
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
        }
    }
}
