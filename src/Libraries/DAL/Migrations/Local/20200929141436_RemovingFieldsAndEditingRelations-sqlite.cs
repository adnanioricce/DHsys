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

            migrationBuilder.DropColumn(
                name: "ProdutoId",
                table: "Products");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "TransactionItem",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 36, 561, DateTimeKind.Unspecified).AddTicks(5894), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "TEXT",
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 23, 22, 4, 38, 187, DateTimeKind.Unspecified).AddTicks(4925), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "TransactionItem",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 36, 561, DateTimeKind.Unspecified).AddTicks(5419), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "TEXT",
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 23, 22, 4, 38, 187, DateTimeKind.Unspecified).AddTicks(4445), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "Transaction",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 36, 554, DateTimeKind.Unspecified).AddTicks(4587), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "TEXT",
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 23, 22, 4, 38, 178, DateTimeKind.Unspecified).AddTicks(6666), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "Transaction",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 36, 554, DateTimeKind.Unspecified).AddTicks(4060), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "TEXT",
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 23, 22, 4, 38, 178, DateTimeKind.Unspecified).AddTicks(6214), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "Syncronization",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 36, 305, DateTimeKind.Unspecified).AddTicks(5361), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "TEXT",
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 23, 22, 4, 37, 923, DateTimeKind.Unspecified).AddTicks(9519), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "Syncronization",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 36, 299, DateTimeKind.Unspecified).AddTicks(1690), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "TEXT",
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 23, 22, 4, 37, 916, DateTimeKind.Unspecified).AddTicks(9943), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "Supplier",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 36, 545, DateTimeKind.Unspecified).AddTicks(8011), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "TEXT",
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 23, 22, 4, 38, 169, DateTimeKind.Unspecified).AddTicks(5542), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "Supplier",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 36, 545, DateTimeKind.Unspecified).AddTicks(7696), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "TEXT",
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 23, 22, 4, 38, 169, DateTimeKind.Unspecified).AddTicks(5205), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Supplier",
                nullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "StockEntry",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 36, 545, DateTimeKind.Unspecified).AddTicks(3337), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "TEXT",
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 23, 22, 4, 38, 169, DateTimeKind.Unspecified).AddTicks(568), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "StockEntry",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 36, 545, DateTimeKind.Unspecified).AddTicks(3030), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "TEXT",
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 23, 22, 4, 38, 169, DateTimeKind.Unspecified).AddTicks(229), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "ProductSupplier",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 36, 598, DateTimeKind.Unspecified).AddTicks(5630), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "TEXT",
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 23, 22, 4, 38, 240, DateTimeKind.Unspecified).AddTicks(3820), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "ProductSupplier",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 36, 598, DateTimeKind.Unspecified).AddTicks(5288), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "TEXT",
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 23, 22, 4, 38, 240, DateTimeKind.Unspecified).AddTicks(3486), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "ProductStockEntry",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 36, 598, DateTimeKind.Unspecified).AddTicks(365), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "TEXT",
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 23, 22, 4, 38, 239, DateTimeKind.Unspecified).AddTicks(8555), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "ProductStockEntry",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 36, 598, DateTimeKind.Unspecified).AddTicks(25), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "TEXT",
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 23, 22, 4, 38, 239, DateTimeKind.Unspecified).AddTicks(8102), new TimeSpan(0, 0, 0, 0, 0)));

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
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 36, 597, DateTimeKind.Unspecified).AddTicks(5503), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "TEXT",
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 23, 22, 4, 38, 239, DateTimeKind.Unspecified).AddTicks(1908), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "ProductShelfLife",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 36, 597, DateTimeKind.Unspecified).AddTicks(5144), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "TEXT",
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 23, 22, 4, 38, 239, DateTimeKind.Unspecified).AddTicks(859), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "Products",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 36, 595, DateTimeKind.Unspecified).AddTicks(9569), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "TEXT",
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 23, 22, 4, 38, 236, DateTimeKind.Unspecified).AddTicks(8518), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "Products",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 36, 595, DateTimeKind.Unspecified).AddTicks(9184), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "TEXT",
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 23, 22, 4, 38, 236, DateTimeKind.Unspecified).AddTicks(8005), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "ProductPrice",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 36, 597, DateTimeKind.Unspecified).AddTicks(392), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "TEXT",
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 23, 22, 4, 38, 238, DateTimeKind.Unspecified).AddTicks(2633), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "ProductPrice",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 36, 597, DateTimeKind.Unspecified).AddTicks(23), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "TEXT",
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 23, 22, 4, 38, 238, DateTimeKind.Unspecified).AddTicks(1784), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "ProductMedia",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 36, 596, DateTimeKind.Unspecified).AddTicks(5203), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "TEXT",
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 23, 22, 4, 38, 237, DateTimeKind.Unspecified).AddTicks(4916), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "ProductMedia",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 36, 596, DateTimeKind.Unspecified).AddTicks(4827), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "TEXT",
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 23, 22, 4, 38, 237, DateTimeKind.Unspecified).AddTicks(4481), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "MediaResource",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 36, 562, DateTimeKind.Unspecified).AddTicks(292), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "TEXT",
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 23, 22, 4, 38, 187, DateTimeKind.Unspecified).AddTicks(9451), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "MediaResource",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 36, 561, DateTimeKind.Unspecified).AddTicks(9965), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "TEXT",
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 23, 22, 4, 38, 187, DateTimeKind.Unspecified).AddTicks(9116), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "Billings",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 36, 567, DateTimeKind.Unspecified).AddTicks(1505), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "TEXT",
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 23, 22, 4, 38, 192, DateTimeKind.Unspecified).AddTicks(9758), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "Billings",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 36, 567, DateTimeKind.Unspecified).AddTicks(1106), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "TEXT",
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 23, 22, 4, 38, 192, DateTimeKind.Unspecified).AddTicks(9335), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "beneficiaries",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 36, 592, DateTimeKind.Unspecified).AddTicks(5418), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "TEXT",
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 23, 22, 4, 38, 232, DateTimeKind.Unspecified).AddTicks(4655), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "beneficiaries",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 36, 592, DateTimeKind.Unspecified).AddTicks(5038), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "TEXT",
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 23, 22, 4, 38, 232, DateTimeKind.Unspecified).AddTicks(4112), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "addresses",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 36, 570, DateTimeKind.Unspecified).AddTicks(6763), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "TEXT",
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 23, 22, 4, 38, 196, DateTimeKind.Unspecified).AddTicks(8313), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "addresses",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 36, 570, DateTimeKind.Unspecified).AddTicks(6422), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "TEXT",
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 23, 22, 4, 38, 196, DateTimeKind.Unspecified).AddTicks(7967), new TimeSpan(0, 0, 0, 0, 0)));
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

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "TransactionItem",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 23, 22, 4, 38, 187, DateTimeKind.Unspecified).AddTicks(4925), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 36, 561, DateTimeKind.Unspecified).AddTicks(5894), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "TransactionItem",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 23, 22, 4, 38, 187, DateTimeKind.Unspecified).AddTicks(4445), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 36, 561, DateTimeKind.Unspecified).AddTicks(5419), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "Transaction",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 23, 22, 4, 38, 178, DateTimeKind.Unspecified).AddTicks(6666), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 36, 554, DateTimeKind.Unspecified).AddTicks(4587), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "Transaction",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 23, 22, 4, 38, 178, DateTimeKind.Unspecified).AddTicks(6214), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 36, 554, DateTimeKind.Unspecified).AddTicks(4060), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "Syncronization",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 23, 22, 4, 37, 923, DateTimeKind.Unspecified).AddTicks(9519), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 36, 305, DateTimeKind.Unspecified).AddTicks(5361), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "Syncronization",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 23, 22, 4, 37, 916, DateTimeKind.Unspecified).AddTicks(9943), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 36, 299, DateTimeKind.Unspecified).AddTicks(1690), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "Supplier",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 23, 22, 4, 38, 169, DateTimeKind.Unspecified).AddTicks(5542), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 36, 545, DateTimeKind.Unspecified).AddTicks(8011), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "Supplier",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 23, 22, 4, 38, 169, DateTimeKind.Unspecified).AddTicks(5205), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 36, 545, DateTimeKind.Unspecified).AddTicks(7696), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "SupplierName",
                table: "Supplier",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "StockEntry",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 23, 22, 4, 38, 169, DateTimeKind.Unspecified).AddTicks(568), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 36, 545, DateTimeKind.Unspecified).AddTicks(3337), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "StockEntry",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 23, 22, 4, 38, 169, DateTimeKind.Unspecified).AddTicks(229), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 36, 545, DateTimeKind.Unspecified).AddTicks(3030), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTime>(
                name: "DrugMaturityDate",
                table: "StockEntry",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LotCode",
                table: "StockEntry",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "StockEntry",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "ProductSupplier",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 23, 22, 4, 38, 240, DateTimeKind.Unspecified).AddTicks(3820), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 36, 598, DateTimeKind.Unspecified).AddTicks(5630), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "ProductSupplier",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 23, 22, 4, 38, 240, DateTimeKind.Unspecified).AddTicks(3486), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 36, 598, DateTimeKind.Unspecified).AddTicks(5288), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "ProductStockEntry",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 23, 22, 4, 38, 239, DateTimeKind.Unspecified).AddTicks(8555), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 36, 598, DateTimeKind.Unspecified).AddTicks(365), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "ProductStockEntry",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 23, 22, 4, 38, 239, DateTimeKind.Unspecified).AddTicks(8102), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 36, 598, DateTimeKind.Unspecified).AddTicks(25), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "ProductShelfLife",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 23, 22, 4, 38, 239, DateTimeKind.Unspecified).AddTicks(1908), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 36, 597, DateTimeKind.Unspecified).AddTicks(5503), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "ProductShelfLife",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 23, 22, 4, 38, 239, DateTimeKind.Unspecified).AddTicks(859), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 36, 597, DateTimeKind.Unspecified).AddTicks(5144), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "Products",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 23, 22, 4, 38, 236, DateTimeKind.Unspecified).AddTicks(8518), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 36, 595, DateTimeKind.Unspecified).AddTicks(9569), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "Products",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 23, 22, 4, 38, 236, DateTimeKind.Unspecified).AddTicks(8005), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 36, 595, DateTimeKind.Unspecified).AddTicks(9184), new TimeSpan(0, 0, 0, 0, 0)));

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

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "ProductPrice",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 23, 22, 4, 38, 238, DateTimeKind.Unspecified).AddTicks(2633), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 36, 597, DateTimeKind.Unspecified).AddTicks(392), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "ProductPrice",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 23, 22, 4, 38, 238, DateTimeKind.Unspecified).AddTicks(1784), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 36, 597, DateTimeKind.Unspecified).AddTicks(23), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "ProductMedia",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 23, 22, 4, 38, 237, DateTimeKind.Unspecified).AddTicks(4916), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 36, 596, DateTimeKind.Unspecified).AddTicks(5203), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "ProductMedia",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 23, 22, 4, 38, 237, DateTimeKind.Unspecified).AddTicks(4481), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 36, 596, DateTimeKind.Unspecified).AddTicks(4827), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "MediaResource",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 23, 22, 4, 38, 187, DateTimeKind.Unspecified).AddTicks(9451), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 36, 562, DateTimeKind.Unspecified).AddTicks(292), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "MediaResource",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 23, 22, 4, 38, 187, DateTimeKind.Unspecified).AddTicks(9116), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 36, 561, DateTimeKind.Unspecified).AddTicks(9965), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "Billings",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 23, 22, 4, 38, 192, DateTimeKind.Unspecified).AddTicks(9758), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 36, 567, DateTimeKind.Unspecified).AddTicks(1505), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "Billings",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 23, 22, 4, 38, 192, DateTimeKind.Unspecified).AddTicks(9335), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 36, 567, DateTimeKind.Unspecified).AddTicks(1106), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "beneficiaries",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 23, 22, 4, 38, 232, DateTimeKind.Unspecified).AddTicks(4655), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 36, 592, DateTimeKind.Unspecified).AddTicks(5418), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "beneficiaries",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 23, 22, 4, 38, 232, DateTimeKind.Unspecified).AddTicks(4112), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 36, 592, DateTimeKind.Unspecified).AddTicks(5038), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "addresses",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 23, 22, 4, 38, 196, DateTimeKind.Unspecified).AddTicks(8313), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 36, 570, DateTimeKind.Unspecified).AddTicks(6763), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "addresses",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 23, 22, 4, 38, 196, DateTimeKind.Unspecified).AddTicks(7967), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 29, 14, 14, 36, 570, DateTimeKind.Unspecified).AddTicks(6422), new TimeSpan(0, 0, 0, 0, 0)));

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
