using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DAL.Migrations.Remote
{
    public partial class RemovingFieldsAndEditingRelationsnpgsql : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "ProductMedia",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UniqueCode = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 5, 592, DateTimeKind.Unspecified).AddTicks(7160), new TimeSpan(0, 0, 0, 0, 0))),
                    LastUpdatedOn = table.Column<DateTimeOffset>(nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 5, 592, DateTimeKind.Unspecified).AddTicks(7533), new TimeSpan(0, 0, 0, 0, 0))),
                    MediaResourceId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    IsThumbnail = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductMedia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductMedia_MediaResource_MediaResourceId",
                        column: x => x.MediaResourceId,
                        principalTable: "MediaResource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductMedia_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductMedia_MediaResourceId",
                table: "ProductMedia",
                column: "MediaResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductMedia_ProductId",
                table: "ProductMedia",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductMedia");

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

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Products");

            migrationBuilder.AddColumn<decimal>(
                name: "TransactionTotal",
                table: "Transaction",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);            

            migrationBuilder.AddColumn<string>(
                name: "SupplierName",
                table: "Supplier",
                type: "text",
                nullable: true);
            

            migrationBuilder.AddColumn<DateTime>(
                name: "DrugMaturityDate",
                table: "StockEntry",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LotCode",
                table: "StockEntry",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "StockEntry",
                type: "integer",
                nullable: true);           

            migrationBuilder.AddColumn<decimal>(
                name: "DrugCost",
                table: "Products",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DrugName",
                table: "Products",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StockEntryId",
                table: "Products",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProdutoId",
                table: "Products",
                type: "text",
                nullable: true);            

            migrationBuilder.CreateTable(
                name: "DrugInformation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CounterIndication = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 9, 19, 4, 11, 8, 411, DateTimeKind.Unspecified).AddTicks(6906), new TimeSpan(0, 0, 0, 0, 0))),
                    DrugId = table.Column<int>(type: "integer", nullable: true),
                    HowToUse = table.Column<string>(type: "text", nullable: true),
                    HowWorks = table.Column<string>(type: "text", nullable: true),
                    Indication = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 9, 19, 4, 11, 8, 411, DateTimeKind.Unspecified).AddTicks(7611), new TimeSpan(0, 0, 0, 0, 0))),
                    MinimalAgeOfUse = table.Column<int>(type: "integer", nullable: true),
                    ProfessionalBule = table.Column<string>(type: "text", nullable: true),
                    Substances = table.Column<string>(type: "text", nullable: true),
                    TypeOfUse = table.Column<string>(type: "text", nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true),
                    UserBule = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrugInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DrugInformation_Products_DrugId",
                        column: x => x.DrugId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_StockEntryId",
                table: "Products",
                column: "StockEntryId");

            migrationBuilder.CreateIndex(
                name: "IX_DrugInformation_DrugId",
                table: "DrugInformation",
                column: "DrugId");

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
