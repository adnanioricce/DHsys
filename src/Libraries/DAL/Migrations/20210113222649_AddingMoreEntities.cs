using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DAL.Migrations
{
    public partial class AddingMoreEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {            
            migrationBuilder.AlterColumn<string>(
                name: "Stripe",
                table: "Products",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");                        
            
            migrationBuilder.AddColumn<int>(
                name: "ProductTemplateId",
                table: "Category",
                type: "integer",
                nullable: true);
                      
            migrationBuilder.CreateTable(
                name: "ProductTemplate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    CommercialName = table.Column<string>(type: "text", nullable: true),
                    ManufacturerName = table.Column<string>(type: "text", nullable: true),
                    ManufacturerCountry = table.Column<string>(type: "text", nullable: true),
                    OwnerOfRegistry = table.Column<string>(type: "text", nullable: true),
                    RegistryCode = table.Column<string>(type: "text", nullable: true),
                    RegistryPublicationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateOfRegistryUpdate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    RegistryValidity = table.Column<string>(type: "text", nullable: true),
                    MedicalProductModel = table.Column<string>(type: "text", nullable: true),
                    Classification = table.Column<string>(type: "text", nullable: true),
                    RiskClass = table.Column<int>(type: "integer", nullable: false),
                    ActivePrinciple = table.Column<string>(type: "text", nullable: true),
                    Concentration = table.Column<string>(type: "text", nullable: true),
                    FisicForm = table.Column<string>(type: "text", nullable: true),
                    UseRestriction = table.Column<string>(type: "text", nullable: true),
                    PrescriptionNeeded = table.Column<bool>(type: "boolean", nullable: false),
                    Stripe = table.Column<int>(type: "integer", nullable: false),
                    IsPricedFixed = table.Column<bool>(type: "boolean", nullable: false),
                    LaboratoryName = table.Column<string>(type: "text", nullable: true),
                    EndCustomerPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    CostPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    UniqueCode = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2021, 1, 13, 22, 26, 48, 994, DateTimeKind.Unspecified).AddTicks(5861), new TimeSpan(0, 0, 0, 0, 0))),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2021, 1, 13, 22, 26, 48, 994, DateTimeKind.Unspecified).AddTicks(6370), new TimeSpan(0, 0, 0, 0, 0)))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTemplate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Taxes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Percentage = table.Column<decimal>(type: "numeric", nullable: false),
                    ProductTemplateId = table.Column<int>(type: "integer", nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2021, 1, 13, 22, 26, 48, 961, DateTimeKind.Unspecified).AddTicks(4976), new TimeSpan(0, 0, 0, 0, 0))),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2021, 1, 13, 22, 26, 48, 961, DateTimeKind.Unspecified).AddTicks(5404), new TimeSpan(0, 0, 0, 0, 0)))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taxes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Taxes_ProductTemplate_ProductTemplateId",
                        column: x => x.ProductTemplateId,
                        principalTable: "ProductTemplate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductTax",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TaxId = table.Column<int>(type: "integer", nullable: false),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    UniqueCode = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2021, 1, 13, 22, 26, 48, 987, DateTimeKind.Unspecified).AddTicks(3048), new TimeSpan(0, 0, 0, 0, 0))),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2021, 1, 13, 22, 26, 48, 987, DateTimeKind.Unspecified).AddTicks(3577), new TimeSpan(0, 0, 0, 0, 0)))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTax", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductTax_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductTax_Taxes_TaxId",
                        column: x => x.TaxId,
                        principalTable: "Taxes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Category_ProductTemplateId",
                table: "Category",
                column: "ProductTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTax_ProductId",
                table: "ProductTax",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTax_TaxId",
                table: "ProductTax",
                column: "TaxId");

            migrationBuilder.CreateIndex(
                name: "IX_Taxes_ProductTemplateId",
                table: "Taxes",
                column: "ProductTemplateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_ProductTemplate_ProductTemplateId",
                table: "Category",
                column: "ProductTemplateId",
                principalTable: "ProductTemplate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_ProductTemplate_ProductTemplateId",
                table: "Category");

            migrationBuilder.DropTable(
                name: "AnvisaFixedProductPrice");

            migrationBuilder.DropTable(
                name: "ProductTax");

            migrationBuilder.DropTable(
                name: "Taxes");

            migrationBuilder.DropTable(
                name: "ProductTemplate");

            migrationBuilder.DropIndex(
                name: "IX_Category_ProductTemplateId",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "RiskClass",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductTemplateId",
                table: "Category");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "Syncronization",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 3, 19, 11, 10, 335, DateTimeKind.Unspecified).AddTicks(742), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 13, 22, 26, 48, 506, DateTimeKind.Unspecified).AddTicks(3127), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "Syncronization",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 3, 19, 11, 10, 323, DateTimeKind.Unspecified).AddTicks(8875), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 13, 22, 26, 48, 494, DateTimeKind.Unspecified).AddTicks(3547), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "Supplier",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 3, 19, 11, 10, 615, DateTimeKind.Unspecified).AddTicks(7045), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 13, 22, 26, 48, 861, DateTimeKind.Unspecified).AddTicks(8849), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "Supplier",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 3, 19, 11, 10, 615, DateTimeKind.Unspecified).AddTicks(6424), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 13, 22, 26, 48, 861, DateTimeKind.Unspecified).AddTicks(8129), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "StockEntry",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 3, 19, 11, 10, 609, DateTimeKind.Unspecified).AddTicks(3662), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 13, 22, 26, 48, 854, DateTimeKind.Unspecified).AddTicks(9926), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "StockEntry",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 3, 19, 11, 10, 609, DateTimeKind.Unspecified).AddTicks(3145), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 13, 22, 26, 48, 854, DateTimeKind.Unspecified).AddTicks(9353), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "StockChange",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 3, 19, 11, 10, 608, DateTimeKind.Unspecified).AddTicks(3049), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 13, 22, 26, 48, 853, DateTimeKind.Unspecified).AddTicks(8419), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "StockChange",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 3, 19, 11, 10, 608, DateTimeKind.Unspecified).AddTicks(2579), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 13, 22, 26, 48, 853, DateTimeKind.Unspecified).AddTicks(7947), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "ProductSupplier",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 3, 19, 11, 10, 716, DateTimeKind.Unspecified).AddTicks(3538), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 13, 22, 26, 48, 986, DateTimeKind.Unspecified).AddTicks(3545), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "ProductSupplier",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 3, 19, 11, 10, 716, DateTimeKind.Unspecified).AddTicks(2981), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 13, 22, 26, 48, 986, DateTimeKind.Unspecified).AddTicks(2805), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "ProductStockEntry",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 3, 19, 11, 10, 715, DateTimeKind.Unspecified).AddTicks(3412), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 13, 22, 26, 48, 985, DateTimeKind.Unspecified).AddTicks(2917), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "ProductStockEntry",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 3, 19, 11, 10, 715, DateTimeKind.Unspecified).AddTicks(2802), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 13, 22, 26, 48, 985, DateTimeKind.Unspecified).AddTicks(2364), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "ProductShelfLife",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 3, 19, 11, 10, 714, DateTimeKind.Unspecified).AddTicks(6220), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 13, 22, 26, 48, 984, DateTimeKind.Unspecified).AddTicks(7276), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "ProductShelfLife",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 3, 19, 11, 10, 714, DateTimeKind.Unspecified).AddTicks(5543), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 13, 22, 26, 48, 984, DateTimeKind.Unspecified).AddTicks(6798), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<int>(
                name: "Stripe",
                table: "Products",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "Products",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 3, 19, 11, 10, 711, DateTimeKind.Unspecified).AddTicks(8752), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 13, 22, 26, 48, 981, DateTimeKind.Unspecified).AddTicks(7191), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "Products",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 3, 19, 11, 10, 711, DateTimeKind.Unspecified).AddTicks(8292), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 13, 22, 26, 48, 981, DateTimeKind.Unspecified).AddTicks(6666), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "ProductPrice",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 3, 19, 11, 10, 713, DateTimeKind.Unspecified).AddTicks(9592), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 13, 22, 26, 48, 984, DateTimeKind.Unspecified).AddTicks(1891), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "ProductPrice",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 3, 19, 11, 10, 713, DateTimeKind.Unspecified).AddTicks(9079), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 13, 22, 26, 48, 984, DateTimeKind.Unspecified).AddTicks(1235), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "ProductMedia",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 3, 19, 11, 10, 713, DateTimeKind.Unspecified).AddTicks(463), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 13, 22, 26, 48, 983, DateTimeKind.Unspecified).AddTicks(900), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "ProductMedia",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 3, 19, 11, 10, 712, DateTimeKind.Unspecified).AddTicks(9918), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 13, 22, 26, 48, 983, DateTimeKind.Unspecified).AddTicks(117), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "ProductCategory",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 3, 19, 11, 10, 704, DateTimeKind.Unspecified).AddTicks(5229), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 13, 22, 26, 48, 970, DateTimeKind.Unspecified).AddTicks(3525), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "ProductCategory",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 3, 19, 11, 10, 704, DateTimeKind.Unspecified).AddTicks(4607), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 13, 22, 26, 48, 970, DateTimeKind.Unspecified).AddTicks(2357), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "POSOrderItem",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 3, 19, 11, 10, 628, DateTimeKind.Unspecified).AddTicks(2571), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 13, 22, 26, 48, 875, DateTimeKind.Unspecified).AddTicks(9776), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "POSOrderItem",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 3, 19, 11, 10, 628, DateTimeKind.Unspecified).AddTicks(2014), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 13, 22, 26, 48, 875, DateTimeKind.Unspecified).AddTicks(9192), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "POSOrder",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 3, 19, 11, 10, 624, DateTimeKind.Unspecified).AddTicks(1752), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 13, 22, 26, 48, 871, DateTimeKind.Unspecified).AddTicks(4994), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "POSOrder",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 3, 19, 11, 10, 624, DateTimeKind.Unspecified).AddTicks(1163), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 13, 22, 26, 48, 871, DateTimeKind.Unspecified).AddTicks(4408), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "MediaResource",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 3, 19, 11, 10, 628, DateTimeKind.Unspecified).AddTicks(6959), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 13, 22, 26, 48, 876, DateTimeKind.Unspecified).AddTicks(4575), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "MediaResource",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 3, 19, 11, 10, 628, DateTimeKind.Unspecified).AddTicks(6539), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 13, 22, 26, 48, 876, DateTimeKind.Unspecified).AddTicks(4150), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "Category",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 3, 19, 11, 10, 702, DateTimeKind.Unspecified).AddTicks(8074), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 13, 22, 26, 48, 968, DateTimeKind.Unspecified).AddTicks(5068), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "Category",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 3, 19, 11, 10, 702, DateTimeKind.Unspecified).AddTicks(7532), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 13, 22, 26, 48, 968, DateTimeKind.Unspecified).AddTicks(4568), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "Billings",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 3, 19, 11, 10, 632, DateTimeKind.Unspecified).AddTicks(5154), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 13, 22, 26, 48, 881, DateTimeKind.Unspecified).AddTicks(7830), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "Billings",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 3, 19, 11, 10, 632, DateTimeKind.Unspecified).AddTicks(4651), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 13, 22, 26, 48, 881, DateTimeKind.Unspecified).AddTicks(7320), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "beneficiaries",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 3, 19, 11, 10, 701, DateTimeKind.Unspecified).AddTicks(6618), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 13, 22, 26, 48, 960, DateTimeKind.Unspecified).AddTicks(7632), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "beneficiaries",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 3, 19, 11, 10, 701, DateTimeKind.Unspecified).AddTicks(5874), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 13, 22, 26, 48, 960, DateTimeKind.Unspecified).AddTicks(6984), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "addresses",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 3, 19, 11, 10, 636, DateTimeKind.Unspecified).AddTicks(765), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 13, 22, 26, 48, 885, DateTimeKind.Unspecified).AddTicks(6158), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "addresses",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 1, 3, 19, 11, 10, 636, DateTimeKind.Unspecified).AddTicks(240), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 1, 13, 22, 26, 48, 885, DateTimeKind.Unspecified).AddTicks(5660), new TimeSpan(0, 0, 0, 0, 0)));
        }
    }
}
