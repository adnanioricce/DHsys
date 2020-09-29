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

            migrationBuilder.DropColumn(
                name: "ProdutoId",
                table: "Products");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "TransactionItem",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 5, 553, DateTimeKind.Unspecified).AddTicks(9133), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 19, 4, 11, 8, 360, DateTimeKind.Unspecified).AddTicks(280), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "TransactionItem",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 5, 553, DateTimeKind.Unspecified).AddTicks(8485), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 19, 4, 11, 8, 359, DateTimeKind.Unspecified).AddTicks(9697), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "Transaction",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 5, 547, DateTimeKind.Unspecified).AddTicks(502), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 19, 4, 11, 8, 348, DateTimeKind.Unspecified).AddTicks(9983), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "Transaction",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 5, 547, DateTimeKind.Unspecified).AddTicks(118), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 19, 4, 11, 8, 348, DateTimeKind.Unspecified).AddTicks(9504), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "Syncronization",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 5, 306, DateTimeKind.Unspecified).AddTicks(5910), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 19, 4, 11, 8, 30, DateTimeKind.Unspecified).AddTicks(5500), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "Syncronization",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 5, 298, DateTimeKind.Unspecified).AddTicks(3800), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 19, 4, 11, 8, 23, DateTimeKind.Unspecified).AddTicks(7503), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "Supplier",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 5, 538, DateTimeKind.Unspecified).AddTicks(2898), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 19, 4, 11, 8, 321, DateTimeKind.Unspecified).AddTicks(4677), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "Supplier",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 5, 538, DateTimeKind.Unspecified).AddTicks(2575), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 19, 4, 11, 8, 321, DateTimeKind.Unspecified).AddTicks(4207), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Supplier",
                nullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "StockEntry",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 5, 537, DateTimeKind.Unspecified).AddTicks(7958), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 19, 4, 11, 8, 320, DateTimeKind.Unspecified).AddTicks(7513), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "StockEntry",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 5, 537, DateTimeKind.Unspecified).AddTicks(7611), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 19, 4, 11, 8, 320, DateTimeKind.Unspecified).AddTicks(6790), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "ProductSupplier",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 5, 594, DateTimeKind.Unspecified).AddTicks(8162), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 19, 4, 11, 8, 417, DateTimeKind.Unspecified).AddTicks(8789), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "ProductSupplier",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 5, 594, DateTimeKind.Unspecified).AddTicks(7839), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 19, 4, 11, 8, 417, DateTimeKind.Unspecified).AddTicks(8214), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "ProductStockEntry",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 5, 594, DateTimeKind.Unspecified).AddTicks(3092), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 19, 4, 11, 8, 416, DateTimeKind.Unspecified).AddTicks(9873), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "ProductStockEntry",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 5, 594, DateTimeKind.Unspecified).AddTicks(2759), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 19, 4, 11, 8, 416, DateTimeKind.Unspecified).AddTicks(9222), new TimeSpan(0, 0, 0, 0, 0)));

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

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "ProductShelfLife",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 5, 593, DateTimeKind.Unspecified).AddTicks(7926), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 19, 4, 11, 8, 416, DateTimeKind.Unspecified).AddTicks(1761), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "ProductShelfLife",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 5, 593, DateTimeKind.Unspecified).AddTicks(7579), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 19, 4, 11, 8, 416, DateTimeKind.Unspecified).AddTicks(1158), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "Products",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 5, 592, DateTimeKind.Unspecified).AddTicks(2004), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 19, 4, 11, 8, 414, DateTimeKind.Unspecified).AddTicks(5634), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "Products",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 5, 592, DateTimeKind.Unspecified).AddTicks(1693), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 19, 4, 11, 8, 414, DateTimeKind.Unspecified).AddTicks(4659), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Products",
                nullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "ProductPrice",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 5, 593, DateTimeKind.Unspecified).AddTicks(2656), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 19, 4, 11, 8, 415, DateTimeKind.Unspecified).AddTicks(3912), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "ProductPrice",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 5, 593, DateTimeKind.Unspecified).AddTicks(2289), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 19, 4, 11, 8, 415, DateTimeKind.Unspecified).AddTicks(3057), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "MediaResource",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 5, 554, DateTimeKind.Unspecified).AddTicks(5357), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 19, 4, 11, 8, 365, DateTimeKind.Unspecified).AddTicks(45), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "MediaResource",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 5, 554, DateTimeKind.Unspecified).AddTicks(4830), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 19, 4, 11, 8, 364, DateTimeKind.Unspecified).AddTicks(9612), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "Billings",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 5, 561, DateTimeKind.Unspecified).AddTicks(3172), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 19, 4, 11, 8, 371, DateTimeKind.Unspecified).AddTicks(2733), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "Billings",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 5, 561, DateTimeKind.Unspecified).AddTicks(2642), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 19, 4, 11, 8, 371, DateTimeKind.Unspecified).AddTicks(2154), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "beneficiaries",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 5, 588, DateTimeKind.Unspecified).AddTicks(8487), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 19, 4, 11, 8, 409, DateTimeKind.Unspecified).AddTicks(8324), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "beneficiaries",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 5, 588, DateTimeKind.Unspecified).AddTicks(8110), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 19, 4, 11, 8, 409, DateTimeKind.Unspecified).AddTicks(7622), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "addresses",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 5, 566, DateTimeKind.Unspecified).AddTicks(429), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 19, 4, 11, 8, 374, DateTimeKind.Unspecified).AddTicks(9231), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "addresses",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 5, 565, DateTimeKind.Unspecified).AddTicks(9986), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 19, 4, 11, 8, 374, DateTimeKind.Unspecified).AddTicks(8884), new TimeSpan(0, 0, 0, 0, 0)));

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

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "TransactionItem",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 19, 4, 11, 8, 360, DateTimeKind.Unspecified).AddTicks(280), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 5, 553, DateTimeKind.Unspecified).AddTicks(9133), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "TransactionItem",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 19, 4, 11, 8, 359, DateTimeKind.Unspecified).AddTicks(9697), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 5, 553, DateTimeKind.Unspecified).AddTicks(8485), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "Transaction",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 19, 4, 11, 8, 348, DateTimeKind.Unspecified).AddTicks(9983), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 5, 547, DateTimeKind.Unspecified).AddTicks(502), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "Transaction",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 19, 4, 11, 8, 348, DateTimeKind.Unspecified).AddTicks(9504), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 5, 547, DateTimeKind.Unspecified).AddTicks(118), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<decimal>(
                name: "TransactionTotal",
                table: "Transaction",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "Syncronization",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 19, 4, 11, 8, 30, DateTimeKind.Unspecified).AddTicks(5500), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 5, 306, DateTimeKind.Unspecified).AddTicks(5910), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "Syncronization",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 19, 4, 11, 8, 23, DateTimeKind.Unspecified).AddTicks(7503), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 5, 298, DateTimeKind.Unspecified).AddTicks(3800), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "Supplier",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 19, 4, 11, 8, 321, DateTimeKind.Unspecified).AddTicks(4677), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 5, 538, DateTimeKind.Unspecified).AddTicks(2898), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "Supplier",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 19, 4, 11, 8, 321, DateTimeKind.Unspecified).AddTicks(4207), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 5, 538, DateTimeKind.Unspecified).AddTicks(2575), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "SupplierName",
                table: "Supplier",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "StockEntry",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 19, 4, 11, 8, 320, DateTimeKind.Unspecified).AddTicks(7513), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 5, 537, DateTimeKind.Unspecified).AddTicks(7958), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "StockEntry",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 19, 4, 11, 8, 320, DateTimeKind.Unspecified).AddTicks(6790), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 5, 537, DateTimeKind.Unspecified).AddTicks(7611), new TimeSpan(0, 0, 0, 0, 0)));

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

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "ProductSupplier",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 19, 4, 11, 8, 417, DateTimeKind.Unspecified).AddTicks(8789), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 5, 594, DateTimeKind.Unspecified).AddTicks(8162), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "ProductSupplier",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 19, 4, 11, 8, 417, DateTimeKind.Unspecified).AddTicks(8214), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 5, 594, DateTimeKind.Unspecified).AddTicks(7839), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "ProductStockEntry",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 19, 4, 11, 8, 416, DateTimeKind.Unspecified).AddTicks(9873), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 5, 594, DateTimeKind.Unspecified).AddTicks(3092), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "ProductStockEntry",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 19, 4, 11, 8, 416, DateTimeKind.Unspecified).AddTicks(9222), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 5, 594, DateTimeKind.Unspecified).AddTicks(2759), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "ProductShelfLife",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 19, 4, 11, 8, 416, DateTimeKind.Unspecified).AddTicks(1761), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 5, 593, DateTimeKind.Unspecified).AddTicks(7926), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "ProductShelfLife",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 19, 4, 11, 8, 416, DateTimeKind.Unspecified).AddTicks(1158), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 5, 593, DateTimeKind.Unspecified).AddTicks(7579), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "Products",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 19, 4, 11, 8, 414, DateTimeKind.Unspecified).AddTicks(5634), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 5, 592, DateTimeKind.Unspecified).AddTicks(2004), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "Products",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 19, 4, 11, 8, 414, DateTimeKind.Unspecified).AddTicks(4659), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 5, 592, DateTimeKind.Unspecified).AddTicks(1693), new TimeSpan(0, 0, 0, 0, 0)));

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

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "ProductPrice",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 19, 4, 11, 8, 415, DateTimeKind.Unspecified).AddTicks(3912), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 5, 593, DateTimeKind.Unspecified).AddTicks(2656), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "ProductPrice",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 19, 4, 11, 8, 415, DateTimeKind.Unspecified).AddTicks(3057), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 5, 593, DateTimeKind.Unspecified).AddTicks(2289), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "MediaResource",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 19, 4, 11, 8, 365, DateTimeKind.Unspecified).AddTicks(45), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 5, 554, DateTimeKind.Unspecified).AddTicks(5357), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "MediaResource",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 19, 4, 11, 8, 364, DateTimeKind.Unspecified).AddTicks(9612), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 5, 554, DateTimeKind.Unspecified).AddTicks(4830), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "Billings",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 19, 4, 11, 8, 371, DateTimeKind.Unspecified).AddTicks(2733), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 5, 561, DateTimeKind.Unspecified).AddTicks(3172), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "Billings",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 19, 4, 11, 8, 371, DateTimeKind.Unspecified).AddTicks(2154), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 5, 561, DateTimeKind.Unspecified).AddTicks(2642), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "beneficiaries",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 19, 4, 11, 8, 409, DateTimeKind.Unspecified).AddTicks(8324), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 5, 588, DateTimeKind.Unspecified).AddTicks(8487), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "beneficiaries",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 19, 4, 11, 8, 409, DateTimeKind.Unspecified).AddTicks(7622), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 5, 588, DateTimeKind.Unspecified).AddTicks(8110), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "addresses",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 19, 4, 11, 8, 374, DateTimeKind.Unspecified).AddTicks(9231), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 5, 566, DateTimeKind.Unspecified).AddTicks(429), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "addresses",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 19, 4, 11, 8, 374, DateTimeKind.Unspecified).AddTicks(8884), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 5, 565, DateTimeKind.Unspecified).AddTicks(9986), new TimeSpan(0, 0, 0, 0, 0)));

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
