using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DAL.Migrations.Remote
{
    public partial class AddingPOSOrders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beneficiaries_Addresses_AddressId",
                table: "Beneficiaries");

            migrationBuilder.DropForeignKey(
                name: "FK_Beneficiaries_Addresses_AddressId1",
                table: "Beneficiaries");

            migrationBuilder.DropForeignKey(
                name: "FK_Supplier_Addresses_AddressId",
                table: "Supplier");
            
            migrationBuilder.DropPrimaryKey(
                name: "PK_Beneficiaries",
                table: "Beneficiaries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses");

            migrationBuilder.RenameTable(
                name: "Beneficiaries",
                newName: "beneficiaries");

            migrationBuilder.RenameTable(
                name: "Addresses",
                newName: "addresses");

            migrationBuilder.RenameIndex(
                name: "IX_Beneficiaries_AddressId1",
                table: "beneficiaries",
                newName: "IX_beneficiaries_AddressId1");

            migrationBuilder.RenameIndex(
                name: "IX_Beneficiaries_AddressId",
                table: "beneficiaries",
                newName: "IX_beneficiaries_AddressId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_beneficiaries",
                table: "beneficiaries",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_addresses",
                table: "addresses",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "POSOrder",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UniqueCode = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 9, 14, 2, 8, 50, 541, DateTimeKind.Unspecified).AddTicks(3769), new TimeSpan(0, 0, 0, 0, 0))),
                    LastUpdatedOn = table.Column<DateTimeOffset>(nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 9, 14, 2, 8, 50, 541, DateTimeKind.Unspecified).AddTicks(4286), new TimeSpan(0, 0, 0, 0, 0))),
                    POSOrderTotal = table.Column<decimal>(nullable: false),
                    PaymentMethod = table.Column<int>(nullable: false),
                    HasDealWithStore = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_POSOrder", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "POSOrderItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UniqueCode = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 9, 14, 2, 8, 50, 523, DateTimeKind.Unspecified).AddTicks(8252), new TimeSpan(0, 0, 0, 0, 0))),
                    LastUpdatedOn = table.Column<DateTimeOffset>(nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 9, 14, 2, 8, 50, 523, DateTimeKind.Unspecified).AddTicks(8665), new TimeSpan(0, 0, 0, 0, 0))),
                    DrugUniqueCode = table.Column<string>(nullable: true),
                    DrugId = table.Column<int>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    CustomerValue = table.Column<decimal>(nullable: false),
                    CostPrice = table.Column<decimal>(nullable: false),
                    POSOrderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_POSOrderItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_POSOrderItem_Products_DrugId",
                        column: x => x.DrugId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_POSOrderItem_POSOrder_POSOrderId",
                        column: x => x.POSOrderId,
                        principalTable: "POSOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_POSOrderItem_DrugId",
                table: "POSOrderItem",
                column: "DrugId");

            migrationBuilder.CreateIndex(
                name: "IX_POSOrderItem_POSOrderId",
                table: "POSOrderItem",
                column: "POSOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_beneficiaries_addresses_AddressId",
                table: "beneficiaries",
                column: "AddressId",
                principalTable: "addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_beneficiaries_addresses_AddressId1",
                table: "beneficiaries",
                column: "AddressId",
                principalTable: "addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Supplier_addresses_AddressId",
                table: "Supplier",
                column: "AddressId",
                principalTable: "addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_beneficiaries_addresses_AddressId",
                table: "beneficiaries");

            migrationBuilder.DropForeignKey(
                name: "FK_beneficiaries_addresses_AddressId1",
                table: "beneficiaries");

            migrationBuilder.DropForeignKey(
                name: "FK_Supplier_addresses_AddressId",
                table: "Supplier");

            migrationBuilder.DropTable(
                name: "POSOrderItem");

            migrationBuilder.DropTable(
                name: "POSOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_beneficiaries",
                table: "beneficiaries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_addresses",
                table: "addresses");

            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.RenameTable(
                name: "beneficiaries",
                newName: "Beneficiaries");

            migrationBuilder.RenameTable(
                name: "addresses",
                newName: "Addresses");

            migrationBuilder.RenameIndex(
                name: "IX_beneficiaries_AddressId1",
                table: "Beneficiaries",
                newName: "IX_Beneficiaries_AddressId1");

            migrationBuilder.RenameIndex(
                name: "IX_beneficiaries_AddressId",
                table: "Beneficiaries",
                newName: "IX_Beneficiaries_AddressId");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "Syncronization",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 12, 4, 9, 40, 785, DateTimeKind.Unspecified).AddTicks(5173), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 14, 2, 8, 50, 307, DateTimeKind.Unspecified).AddTicks(231), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "Syncronization",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 12, 4, 9, 40, 783, DateTimeKind.Unspecified).AddTicks(848), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 14, 2, 8, 50, 300, DateTimeKind.Unspecified).AddTicks(9413), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "Supplier",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 12, 4, 9, 41, 18, DateTimeKind.Unspecified).AddTicks(6010), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 14, 2, 8, 50, 520, DateTimeKind.Unspecified).AddTicks(5413), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "Supplier",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 12, 4, 9, 41, 18, DateTimeKind.Unspecified).AddTicks(5539), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 14, 2, 8, 50, 520, DateTimeKind.Unspecified).AddTicks(5095), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "StockEntry",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 12, 4, 9, 41, 17, DateTimeKind.Unspecified).AddTicks(7771), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 14, 2, 8, 50, 520, DateTimeKind.Unspecified).AddTicks(562), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "StockEntry",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 12, 4, 9, 41, 17, DateTimeKind.Unspecified).AddTicks(7238), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 14, 2, 8, 50, 520, DateTimeKind.Unspecified).AddTicks(234), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "ProductSupplier",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 12, 4, 9, 41, 78, DateTimeKind.Unspecified).AddTicks(570), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 14, 2, 8, 50, 589, DateTimeKind.Unspecified).AddTicks(7238), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "ProductSupplier",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 12, 4, 9, 41, 77, DateTimeKind.Unspecified).AddTicks(9607), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 14, 2, 8, 50, 589, DateTimeKind.Unspecified).AddTicks(6866), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "ProductStockEntry",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 12, 4, 9, 41, 76, DateTimeKind.Unspecified).AddTicks(7110), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 14, 2, 8, 50, 589, DateTimeKind.Unspecified).AddTicks(1655), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "ProductStockEntry",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 12, 4, 9, 41, 76, DateTimeKind.Unspecified).AddTicks(6605), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 14, 2, 8, 50, 589, DateTimeKind.Unspecified).AddTicks(1242), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "ProductShelfLife",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 12, 4, 9, 41, 75, DateTimeKind.Unspecified).AddTicks(9616), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 14, 2, 8, 50, 588, DateTimeKind.Unspecified).AddTicks(5855), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "ProductShelfLife",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 12, 4, 9, 41, 75, DateTimeKind.Unspecified).AddTicks(9155), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 14, 2, 8, 50, 588, DateTimeKind.Unspecified).AddTicks(5530), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<int>(
                name: "ProdutoId",
                table: "Products",
                type: "integer",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "Products",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 12, 4, 9, 41, 68, DateTimeKind.Unspecified).AddTicks(838), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 14, 2, 8, 50, 587, DateTimeKind.Unspecified).AddTicks(6611), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "Products",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 12, 4, 9, 41, 68, DateTimeKind.Unspecified).AddTicks(408), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 14, 2, 8, 50, 587, DateTimeKind.Unspecified).AddTicks(6198), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "ProductPrice",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 12, 4, 9, 41, 75, DateTimeKind.Unspecified).AddTicks(2218), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 14, 2, 8, 50, 588, DateTimeKind.Unspecified).AddTicks(1423), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "ProductPrice",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 12, 4, 9, 41, 75, DateTimeKind.Unspecified).AddTicks(1678), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 14, 2, 8, 50, 588, DateTimeKind.Unspecified).AddTicks(1072), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "DrugInformation",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 12, 4, 9, 41, 68, DateTimeKind.Unspecified).AddTicks(8154), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 14, 2, 8, 50, 586, DateTimeKind.Unspecified).AddTicks(326), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "DrugInformation",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 12, 4, 9, 41, 68, DateTimeKind.Unspecified).AddTicks(7749), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 14, 2, 8, 50, 585, DateTimeKind.Unspecified).AddTicks(9984), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "Billings",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 12, 4, 9, 41, 37, DateTimeKind.Unspecified).AddTicks(7832), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 14, 2, 8, 50, 557, DateTimeKind.Unspecified).AddTicks(2557), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "Billings",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 12, 4, 9, 41, 37, DateTimeKind.Unspecified).AddTicks(7278), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 14, 2, 8, 50, 557, DateTimeKind.Unspecified).AddTicks(2122), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "Beneficiaries",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 12, 4, 9, 41, 67, DateTimeKind.Unspecified).AddTicks(1459), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 14, 2, 8, 50, 584, DateTimeKind.Unspecified).AddTicks(9489), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "Beneficiaries",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 12, 4, 9, 41, 67, DateTimeKind.Unspecified).AddTicks(1000), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 14, 2, 8, 50, 584, DateTimeKind.Unspecified).AddTicks(9142), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdatedOn",
                table: "Addresses",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 12, 4, 9, 41, 38, DateTimeKind.Unspecified).AddTicks(9839), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 14, 2, 8, 50, 561, DateTimeKind.Unspecified).AddTicks(56), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "Addresses",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2020, 9, 12, 4, 9, 41, 38, DateTimeKind.Unspecified).AddTicks(9507), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValue: new DateTimeOffset(new DateTime(2020, 9, 14, 2, 8, 50, 560, DateTimeKind.Unspecified).AddTicks(9718), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Beneficiaries",
                table: "Beneficiaries",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "agenda",
                schema: "public",
                columns: table => new
                {
                    bairro = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    cep = table.Column<string>(type: "character varying(9)", maxLength: 9, nullable: true),
                    cidade = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    codigo = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    endereco = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    fone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    nome = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "agenda (2)",
                schema: "public",
                columns: table => new
                {
                    bairro = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    cep = table.Column<string>(type: "character varying(9)", maxLength: 9, nullable: true),
                    cidade = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    codigo = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    endereco = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    fone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    nome = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "balcon",
                schema: "public",
                columns: table => new
                {
                    bacodi = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true),
                    bacomi = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    badevol = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    banome = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    comis_ace = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    comis_bo = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    comis_eti = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    comis_out = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    comis_per = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    comis_perc = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    comis_var = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    cpf = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    senha = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "brindes",
                schema: "public",
                columns: table => new
                {
                    codigo = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    nome = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    pontos = table.Column<decimal>(type: "numeric(4,0)", nullable: true),
                    qtde = table.Column<decimal>(type: "numeric(4,0)", nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "cadlab",
                schema: "public",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    dt_alter = table.Column<DateTime>(type: "date", nullable: true),
                    foapel = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    fobair = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    focepe = table.Column<string>(type: "character varying(9)", maxLength: 9, nullable: true),
                    focida = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: true),
                    focont = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    foende = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    foesta = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    fofaxe = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    foibge = table.Column<string>(type: "character varying(7)", maxLength: 7, nullable: true),
                    fonome = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    fonume = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    fotel2 = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    fotele = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    labrev = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: true),
                    lacgce = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    lacodi = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    lacond = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    laiest = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    laperc = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    latipo = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    laulno = table.Column<string>(type: "character varying(7)", maxLength: 7, nullable: true),
                    laultc = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    nomarq = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "cadlabold",
                schema: "public",
                columns: table => new
                {
                    dt_alter = table.Column<DateTime>(type: "date", nullable: true),
                    foapel = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    focepe = table.Column<string>(type: "character varying(9)", maxLength: 9, nullable: true),
                    focida = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: true),
                    focont = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    foende = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    foesta = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    fofaxe = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    fonome = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    fotel2 = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    fotele = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    ibgeest = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    ibgemun = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    labrev = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: true),
                    lacgce = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    lacodi = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    lacond = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    laiest = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    laperc = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    latipo = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    laulno = table.Column<string>(type: "character varying(7)", maxLength: 7, nullable: true),
                    laultc = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    nomarq = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "cadprom",
                schema: "public",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    fonome = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    fotele = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    lacodi = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UniqueCode = table.Column<string>(type: "text", nullable: true),
                    valid = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "caixa",
                schema: "public",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    cx_adm = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    cx_atend = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    cx_cart = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    cx_data = table.Column<DateTime>(type: "date", nullable: true),
                    cx_rec = table.Column<DateTime>(type: "date", nullable: true),
                    cx_tipo = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    cx_valor = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UniqueCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "cancdia",
                schema: "public",
                columns: table => new
                {
                    codemp = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true),
                    codfun = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    data = table.Column<DateTime>(type: "date", nullable: true),
                    datac = table.Column<DateTime>(type: "date", nullable: true),
                    filial = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ticket = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "cartao",
                schema: "public",
                columns: table => new
                {
                    codigo = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    nome = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    parcel = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    prazo = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    qtde = table.Column<decimal>(type: "numeric(1,0)", nullable: true),
                    taxa = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "cdesp",
                schema: "public",
                columns: table => new
                {
                    banco = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true),
                    chpag = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: true),
                    cont = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    desc = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    doc = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    dtdesc = table.Column<DateTime>(type: "date", nullable: true),
                    dtpag = table.Column<DateTime>(type: "date", nullable: true),
                    dtvenc = table.Column<DateTime>(type: "date", nullable: true),
                    jurdin = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    jurper = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    multa = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    valor = table.Column<decimal>(type: "numeric(9,2)", nullable: true),
                    vlpag = table.Column<decimal>(type: "numeric(9,2)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "chdevol",
                schema: "public",
                columns: table => new
                {
                    agencia = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    banco = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true),
                    cheque = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: true),
                    cliente = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    conta = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    data = table.Column<DateTime>(type: "date", nullable: true),
                    datae = table.Column<DateTime>(type: "date", nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UniqueCode = table.Column<string>(type: "text", nullable: true),
                    valor = table.Column<decimal>(type: "numeric(12,2)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "cheque",
                schema: "public",
                columns: table => new
                {
                    agencia = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    baixa = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    banco = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true),
                    cheque = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: true),
                    cliente = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    conta = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    data = table.Column<DateTime>(type: "date", nullable: true),
                    datae = table.Column<DateTime>(type: "date", nullable: true),
                    filial = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    obs = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    rg = table.Column<string>(type: "character varying(17)", maxLength: 17, nullable: true),
                    situacao = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    telefone = table.Column<string>(type: "character varying(17)", maxLength: 17, nullable: true),
                    ticket = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true),
                    valor = table.Column<decimal>(type: "numeric(12,2)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "cli_med",
                schema: "public",
                columns: table => new
                {
                    cpf_crm = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    endereco = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    fone = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    nome = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    sexo = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "clicheq",
                schema: "public",
                columns: table => new
                {
                    bairro = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    cep = table.Column<string>(type: "character varying(9)", maxLength: 9, nullable: true),
                    cidade = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    codigo = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    cpf = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    datanasc = table.Column<DateTime>(type: "date", nullable: true),
                    endereco = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    fone = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    nome = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    rg = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "cliente",
                schema: "public",
                columns: table => new
                {
                    clbairro = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    clcep = table.Column<string>(type: "character varying(9)", maxLength: 9, nullable: true),
                    clcida = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    clcodi = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    clcompra = table.Column<DateTime>(type: "date", nullable: true),
                    clcpf = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    clcred = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    cldebi = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    cldesc = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    cldesmed = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    cldesper = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    clende = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    clestado = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    cllime = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    clnasc = table.Column<DateTime>(type: "date", nullable: true),
                    clnome = table.Column<string>(type: "character varying(35)", maxLength: 35, nullable: true),
                    clobs = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    clpagto = table.Column<decimal>(type: "numeric(2,0)", nullable: true),
                    clrg = table.Column<string>(type: "character varying(19)", maxLength: 19, nullable: true),
                    cltele = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    clupagto = table.Column<DateTime>(type: "date", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UniqueCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "clipago",
                schema: "public",
                columns: table => new
                {
                    cliente = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    credito = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    data = table.Column<DateTime>(type: "date", nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UniqueCode = table.Column<string>(type: "text", nullable: true),
                    valor = table.Column<decimal>(type: "numeric(10,2)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "contas",
                schema: "public",
                columns: table => new
                {
                    cod = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    hist = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UniqueCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "conv",
                schema: "public",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    cvbalc = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true),
                    cvcomissao = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    cvdata = table.Column<DateTime>(type: "date", nullable: true),
                    cvdtrec = table.Column<DateTime>(type: "date", nullable: true),
                    cventrega = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    cvfilial = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true),
                    cvlibcom = table.Column<DateTime>(type: "date", nullable: true),
                    cvnota = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    cvobsv = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    cvpsuso = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    cvreceita = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    cvtick = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    cvtitular = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    cvvalocrz = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    cvvalourv = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    fucdem = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true),
                    fucodi = table.Column<string>(type: "character varying(18)", maxLength: 18, nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UniqueCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "convenio",
                schema: "public",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    cvbalc = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true),
                    cvcomissao = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    cvdata = table.Column<DateTime>(type: "date", nullable: true),
                    cvdtrec = table.Column<DateTime>(type: "date", nullable: true),
                    cventrega = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    cvfilial = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true),
                    cvlibcom = table.Column<DateTime>(type: "date", nullable: true),
                    cvmesdesc = table.Column<DateTime>(type: "date", nullable: true),
                    cvnota = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    cvobsv = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    cvpsuso = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    cvrec = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    cvreceita = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    cvtick = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    cvtitular = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    cvvalocrz = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    cvvalourv = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    fucdem = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true),
                    fucodi = table.Column<string>(type: "character varying(18)", maxLength: 18, nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UniqueCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "cpagar",
                schema: "public",
                columns: table => new
                {
                    banco = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true),
                    chpag = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: true),
                    cont = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    desc = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    doc = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    dtdesc = table.Column<DateTime>(type: "date", nullable: true),
                    dtemiss = table.Column<DateTime>(type: "date", nullable: true),
                    dtpag = table.Column<DateTime>(type: "date", nullable: true),
                    dtvenc = table.Column<DateTime>(type: "date", nullable: true),
                    forn = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    jurdin = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    jurper = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    multa = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    titulo = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    valor = table.Column<decimal>(type: "numeric(9,2)", nullable: true),
                    vlpag = table.Column<decimal>(type: "numeric(9,2)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "debcli",
                schema: "public",
                columns: table => new
                {
                    bacodi = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true),
                    clbalc = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true),
                    clcodi = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    cldata = table.Column<DateTime>(type: "date", nullable: true),
                    cldesc = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    clobs = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    clpago = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    clqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    cltick = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    comissao = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    descomp = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    dt_pagto = table.Column<DateTime>(type: "date", nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true),
                    vl_pago = table.Column<decimal>(type: "numeric(12,2)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "delivery",
                schema: "public",
                columns: table => new
                {
                    acumulado = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    aposentado = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    bairro = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    balcon = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true),
                    cep = table.Column<string>(type: "character varying(9)", maxLength: 9, nullable: true),
                    cidade = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    clclassi = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    clobs1 = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    clobs2 = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    codigo = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    cpf = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    datanasc = table.Column<DateTime>(type: "date", nullable: true),
                    descmed = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    descout = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    dtcad = table.Column<DateTime>(type: "date", nullable: true),
                    endereco = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    fone = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    impresso = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    nome = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true),
                    rg = table.Column<string>(type: "character varying(19)", maxLength: 19, nullable: true),
                    ult_compra = table.Column<DateTime>(type: "date", nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "despesas",
                schema: "public",
                columns: table => new
                {
                    caixa = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    data = table.Column<DateTime>(type: "date", nullable: true),
                    historico = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UniqueCode = table.Column<string>(type: "text", nullable: true),
                    valor = table.Column<decimal>(type: "numeric(12,2)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "empresa",
                schema: "public",
                columns: table => new
                {
                    codgolden = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    des_ace = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    des_b = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    des_etic = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    des_fech = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    des_nota = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    des_perf = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    des_rest = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    des_tick = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    des_var = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    descplac = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    embair = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: true),
                    embloq = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    emcep = table.Column<string>(type: "character varying(9)", maxLength: 9, nullable: true),
                    emcgce = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    emcida = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: true),
                    emcodi = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true),
                    emcont = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    emcontrato = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    emdebito = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    emende = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    emesta = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    emetico = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    emfax = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    emfech = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    emfilial = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    EmgCorea = table.Column<string>(type: "text", nullable: true),
                    emguia = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    eminsc = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    emlimite = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    emnume = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    emobs = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    emobs1 = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    emperf = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    emprint = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    emraso = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    emreceita = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    emtele = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    ibgeest = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    ibgemun = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    libperf = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    perc_desc = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true),
                    vidaav = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    vidalk = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    vidapc = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "encomen",
                schema: "public",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    endata = table.Column<DateTime>(type: "date", nullable: true),
                    enqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ent",
                schema: "public",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    descfin = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    desconto = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    descrep = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    endata = table.Column<DateTime>(type: "date", nullable: true),
                    enqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    envalo = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    envalodes = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    estant = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    etiqueta = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    fornec = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    impresso = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    impretq = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    notafis = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prfabr = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    soetiq = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true),
                    usuario = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "entpro",
                schema: "public",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    descfin = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    desconto = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    descrep = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    emissnf = table.Column<DateTime>(type: "date", nullable: true),
                    endata = table.Column<DateTime>(type: "date", nullable: true),
                    enqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    envalo = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    envalodes = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    estant = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    etiqueta = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    fornec = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    impresso = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    impretq = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    lote = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    notafis = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: true),
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prfabr = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    soetiq = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true),
                    usuario = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "estq0045",
                schema: "public",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    est_minimo = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    prbarra = table.Column<string>(type: "character varying(13)", maxLength: 13, nullable: true),
                    prcdse = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prdesc = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    prestq = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    secao = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "etiqperf",
                schema: "public",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prcons = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    prconsf = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    prdesc1 = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    prdesc2 = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "etiqprom",
                schema: "public",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prcons = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    prconsf = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    prdesc1 = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    prdesc2 = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "etiqueta",
                schema: "public",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prcons = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    prdesc1 = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    prdesc2 = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "faltas",
                schema: "public",
                columns: table => new
                {
                    balcon = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    data = table.Column<DateTime>(type: "date", nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "fechconv",
                schema: "public",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    data = table.Column<DateTime>(type: "date", nullable: true),
                    fucdem = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UniqueCode = table.Column<string>(type: "text", nullable: true),
                    valor = table.Column<decimal>(type: "numeric(12,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "filial",
                schema: "public",
                columns: table => new
                {
                    aplica1 = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    aplica10 = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    aplica2 = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    aplica3 = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    aplica4 = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    aplica5 = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    aplica6 = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    aplica7 = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    aplica8 = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    aplica9 = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    desc1 = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    desc10 = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    desc2 = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    desc3 = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    desc4 = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    desc5 = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    desc6 = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    desc7 = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    desc8 = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    desc9 = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    filcep = table.Column<string>(type: "character varying(9)", maxLength: 9, nullable: true),
                    filcgce = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    filcida = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: true),
                    filcodi = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true),
                    filcont = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    filende = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    filesta = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    filfax = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    filinsc = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    filnome = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    filtele = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    subsec1 = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    subsec10 = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    subsec2 = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    subsec3 = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    subsec4 = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    subsec5 = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    subsec6 = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    subsec7 = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    subsec8 = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    subsec9 = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "funcio",
                schema: "public",
                columns: table => new
                {
                    codgolden = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    datademi = table.Column<DateTime>(type: "date", nullable: true),
                    demitido = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    fubai = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    fubloq = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    fucdem = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true),
                    fucep = table.Column<string>(type: "character varying(9)", maxLength: 9, nullable: true),
                    fucid = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    fucodi = table.Column<string>(type: "character varying(18)", maxLength: 18, nullable: true),
                    fudata = table.Column<DateTime>(type: "date", nullable: true),
                    fudepto = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true),
                    fuend = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    fuest = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    fufone = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: true),
                    fuident = table.Column<string>(type: "character varying(18)", maxLength: 18, nullable: true),
                    fulimite = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    funome = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    fuobs1 = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    fuobs2 = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    fuobs3 = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    fuplano = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true),
                    fusit = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    impresso = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    totdebcr = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    totdebsr = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "histor",
                schema: "public",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    desconto = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    distrib = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    notafis = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    pedido = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: true),
                    recebto = table.Column<DateTime>(type: "date", nullable: true),
                    total = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true),
                    vencto = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ibpt",
                schema: "public",
                columns: table => new
                {
                    codigo = table.Column<string>(type: "character varying(9)", maxLength: 9, nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    imp1 = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    imp2 = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UniqueCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "invent",
                schema: "public",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    lote = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prdesc = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    prreg = table.Column<string>(type: "character varying(13)", maxLength: 13, nullable: true),
                    qtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    tpmed = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "logsys",
                schema: "public",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    data = table.Column<DateTime>(type: "date", nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    nivel = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true),
                    opcao = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: true),
                    time = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true),
                    usuario = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "malclien",
                schema: "public",
                columns: table => new
                {
                    acumulado = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    aposentado = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    bairro = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    balcon = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true),
                    cep = table.Column<string>(type: "character varying(9)", maxLength: 9, nullable: true),
                    cidade = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    clclassi = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    clobs1 = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    clobs2 = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    codigo = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    cpf = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    datanasc = table.Column<DateTime>(type: "date", nullable: true),
                    descmed = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    descout = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    dtcad = table.Column<DateTime>(type: "date", nullable: true),
                    endereco = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    filial = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    fone = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    impresso = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    nome = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true),
                    rg = table.Column<string>(type: "character varying(19)", maxLength: 19, nullable: true),
                    ult_compra = table.Column<DateTime>(type: "date", nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "merctran",
                schema: "public",
                columns: table => new
                {
                    comissao = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    desconto = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    descricao = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    estoque = table.Column<decimal>(type: "numeric(4,0)", nullable: true),
                    etiqueta = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prcons = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    prconsd = table.Column<decimal>(type: "numeric(12,4)", nullable: true),
                    qtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true),
                    vl_total = table.Column<decimal>(type: "numeric(12,2)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "mov",
                schema: "public",
                columns: table => new
                {
                    admcart = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    bacodi = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true),
                    caixa = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    cancelado = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    cartaoc = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    cheque = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    chequepre = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    codcli = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    cpf = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    data = table.Column<DateTime>(type: "date", nullable: true),
                    dinheiro = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    ecf = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: true),
                    hora = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    n_fiscal = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    nome = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    popular = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    ticket = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    tipo = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    tot_ant = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    tot_ven = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    tpvd = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "movm",
                schema: "public",
                columns: table => new
                {
                    admcart = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    bacodi = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true),
                    caixa = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    cancelado = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    cartaoc = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    cheque = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    chequepre = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    codcli = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    data = table.Column<DateTime>(type: "date", nullable: true),
                    dinheiro = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    hora = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    n_fiscal = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    ticket = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    tipo = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    tot_ant = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    tot_ven = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    tpvd = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "movme",
                schema: "public",
                columns: table => new
                {
                    bacodi = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true),
                    cancelado = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    codcli = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    data = table.Column<DateTime>(type: "date", nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    pedido = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    ticket = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    tipo = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    tot_comis = table.Column<decimal>(type: "numeric(12,4)", nullable: true),
                    tot_descon = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    tpvd = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true),
                    vl_tot = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    vl_unit = table.Column<decimal>(type: "numeric(12,4)", nullable: true),
                    vlliquid = table.Column<decimal>(type: "numeric(12,2)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "movmes",
                schema: "public",
                columns: table => new
                {
                    bacodi = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true),
                    cancelado = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    codcli = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    data = table.Column<DateTime>(type: "date", nullable: true),
                    ecf = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    pedido = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    ticket = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    tipo = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    tot_comis = table.Column<decimal>(type: "numeric(12,4)", nullable: true),
                    tot_descon = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    tpvd = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true),
                    vl_tot = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    vl_unit = table.Column<decimal>(type: "numeric(12,4)", nullable: true),
                    vlliquid = table.Column<decimal>(type: "numeric(12,2)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "movnf",
                schema: "public",
                columns: table => new
                {
                    cancelado = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    cpf = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    data = table.Column<DateTime>(type: "date", nullable: true),
                    descricao = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    ecf = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    ticket = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true),
                    vl_tot = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    vl_unit = table.Column<decimal>(type: "numeric(12,4)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "movpop",
                schema: "public",
                columns: table => new
                {
                    balc_cpf = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: true),
                    cancelado = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    compdia = table.Column<decimal>(type: "numeric(5,0)", nullable: true),
                    compmes = table.Column<decimal>(type: "numeric(5,0)", nullable: true),
                    cpfcli = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    crm = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    data = table.Column<DateTime>(type: "date", nullable: true),
                    datarec = table.Column<DateTime>(type: "date", nullable: true),
                    ecf = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    senha = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: true),
                    ticket = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    tot_descon = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true),
                    vl_tot = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    vl_unit = table.Column<decimal>(type: "numeric(12,4)", nullable: true),
                    vlliquid = table.Column<decimal>(type: "numeric(12,2)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "natureza",
                schema: "public",
                columns: table => new
                {
                    codigo = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    nome = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "newcli",
                schema: "public",
                columns: table => new
                {
                    bairro = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    cep = table.Column<string>(type: "character varying(9)", maxLength: 9, nullable: true),
                    cidade = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    clclassi = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    codigo = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    datanasc = table.Column<DateTime>(type: "date", nullable: true),
                    desconto = table.Column<decimal>(type: "numeric(2,0)", nullable: true),
                    endereco = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    fone = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    impresso = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    nome = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    rg = table.Column<string>(type: "character varying(19)", maxLength: 19, nullable: true),
                    tipo = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    ult_compra = table.Column<DateTime>(type: "date", nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "newconv",
                schema: "public",
                columns: table => new
                {
                    cvdata = table.Column<DateTime>(type: "date", nullable: true),
                    cvdtrec = table.Column<DateTime>(type: "date", nullable: true),
                    cventrega = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    cvfilial = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true),
                    cvnota = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    cvobsv = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    cvpsuso = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    cvreceita = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    cvtick = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    cvtitular = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    cvvalocrz = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    cvvalourv = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    fucdem = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true),
                    fucodi = table.Column<string>(type: "character varying(18)", maxLength: 18, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "newfunc",
                schema: "public",
                columns: table => new
                {
                    codgolden = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    datademi = table.Column<DateTime>(type: "date", nullable: true),
                    demitido = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    fubai = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    fubloq = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    fucdem = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true),
                    fucep = table.Column<string>(type: "character varying(9)", maxLength: 9, nullable: true),
                    fucid = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    fucodi = table.Column<string>(type: "character varying(18)", maxLength: 18, nullable: true),
                    fudata = table.Column<DateTime>(type: "date", nullable: true),
                    fudepto = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true),
                    fuend = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    fuest = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    fufone = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: true),
                    fulimite = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    funome = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    fuobs1 = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    fuobs2 = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    fuobs3 = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    fusit = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    impresso = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    totdebcr = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    totdebsr = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "newprec",
                schema: "public",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    prcddt = table.Column<DateTime>(type: "date", nullable: true),
                    prcdlucr = table.Column<decimal>(type: "numeric(10,6)", nullable: true),
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prcons = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    prconscv = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    prfabr = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "newprod",
                schema: "public",
                columns: table => new
                {
                    coddcb = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    codesta = table.Column<string>(type: "character varying(9)", maxLength: 9, nullable: true),
                    codfis = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    comissao = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    desc_max = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    est_minimo = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    etbarra = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    etgraf = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    prbarra = table.Column<string>(type: "character varying(13)", maxLength: 13, nullable: true),
                    prcddt = table.Column<DateTime>(type: "date", nullable: true),
                    prcdimp = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    prcdimp2 = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    prcdla = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    prcdlucr = table.Column<decimal>(type: "numeric(10,6)", nullable: true),
                    prcdse = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    prclas = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prcons = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    prconscv = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    prdata = table.Column<DateTime>(type: "date", nullable: true),
                    prdesc = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    prdesconv = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    prdtul = table.Column<DateTime>(type: "date", nullable: true),
                    premb = table.Column<decimal>(type: "numeric(4,0)", nullable: true),
                    prentr = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    prestq = table.Column<decimal>(type: "numeric(4,0)", nullable: true),
                    pretiq = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    prfabr = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    pricms = table.Column<decimal>(type: "numeric(2,0)", nullable: true),
                    prloca = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    prmesant = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    prneutro = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true),
                    prnola = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    prnose = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    prpis = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    prpopular = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    prporta = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prpos = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true),
                    prpret = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    prreg = table.Column<string>(type: "character varying(13)", maxLength: 13, nullable: true),
                    prsal = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    prsitu = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    prtestq = table.Column<decimal>(type: "numeric(4,0)", nullable: true),
                    prulte = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    secao = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    tipo = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    ul_ven = table.Column<DateTime>(type: "date", nullable: true),
                    ultfor = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    ultped = table.Column<DateTime>(type: "date", nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true),
                    vendant = table.Column<decimal>(type: "numeric(4,0)", nullable: true),
                    vendatu = table.Column<decimal>(type: "numeric(4,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "newtab",
                schema: "public",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    mesano = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    newtab = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "nfe",
                schema: "public",
                columns: table => new
                {
                    campo = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    codigo = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    descricao = table.Column<string>(type: "character varying(35)", maxLength: 35, nullable: true),
                    icms = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    imp = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ncm = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: true),
                    prcdimp = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    qtde = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true),
                    valor = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: true),
                    vltot = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "nota",
                schema: "public",
                columns: table => new
                {
                    @base = table.Column<decimal>(name: "base", type: "numeric(12,2)", nullable: true),
                    basesub = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    cliente = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    icms = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    icmssub = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    n_fiscal = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: true),
                    n_natu = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: true),
                    natureza = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    nbase12 = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    nbase18 = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    nbase25 = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    nbase7 = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    ncancelada = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    ndata = table.Column<DateTime>(type: "date", nullable: true),
                    nicms12 = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    nicms18 = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    nicms25 = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    nicms7 = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    nvalor = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "notaf",
                schema: "public",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    num_nota = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "nped",
                schema: "public",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    numped = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "num_tmp",
                schema: "public",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    numero = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "numped",
                schema: "public",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    desconto = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    fornec = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    numero = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    przentrega = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    przpagto = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ped0204",
                schema: "public",
                columns: table => new
                {
                    codint = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    eloja1 = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    eloja2 = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    eloja3 = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    eloja4 = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    forn = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    mloja1 = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    mloja2 = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    mloja3 = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    mloja4 = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    nloja1 = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    nloja2 = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    nloja3 = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    nloja4 = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    prbarra = table.Column<string>(type: "character varying(13)", maxLength: 13, nullable: true),
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prdesc = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true),
                    valor = table.Column<decimal>(type: "numeric(10,2)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ped0301",
                schema: "public",
                columns: table => new
                {
                    codint = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    eloja1 = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    eloja2 = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    eloja3 = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    eloja4 = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    forn = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    mloja1 = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    mloja2 = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    mloja3 = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    mloja4 = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    nloja1 = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    nloja2 = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    nloja3 = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    nloja4 = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    prbarra = table.Column<string>(type: "character varying(13)", maxLength: 13, nullable: true),
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prdesc = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true),
                    valor = table.Column<decimal>(type: "numeric(10,2)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ped0406",
                schema: "public",
                columns: table => new
                {
                    codint = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    eloja1 = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    eloja2 = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    eloja3 = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    eloja4 = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    forn = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    mloja1 = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    mloja2 = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    mloja3 = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    mloja4 = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    nloja1 = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    nloja2 = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    nloja3 = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    nloja4 = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    prbarra = table.Column<string>(type: "character varying(13)", maxLength: 13, nullable: true),
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prdesc = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true),
                    valor = table.Column<decimal>(type: "numeric(10,2)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ped1103",
                schema: "public",
                columns: table => new
                {
                    codint = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    eloja1 = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    eloja2 = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    eloja3 = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    eloja4 = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    forn = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    mloja1 = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    mloja2 = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    mloja3 = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    mloja4 = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    nloja1 = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    nloja2 = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    nloja3 = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    nloja4 = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    prbarra = table.Column<string>(type: "character varying(13)", maxLength: 13, nullable: true),
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prdesc = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true),
                    valor = table.Column<decimal>(type: "numeric(10,2)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ped1406",
                schema: "public",
                columns: table => new
                {
                    codint = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    eloja1 = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    eloja2 = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    eloja3 = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    eloja4 = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    forn = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    mloja1 = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    mloja2 = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    mloja3 = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    mloja4 = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    nloja1 = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    nloja2 = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    nloja3 = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    nloja4 = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    prbarra = table.Column<string>(type: "character varying(13)", maxLength: 13, nullable: true),
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prdesc = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true),
                    valor = table.Column<decimal>(type: "numeric(10,2)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ped1912",
                schema: "public",
                columns: table => new
                {
                    codint = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    eloja1 = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    eloja2 = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    eloja3 = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    eloja4 = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    forn = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    mloja1 = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    mloja2 = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    mloja3 = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    mloja4 = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    nloja1 = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    nloja2 = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    nloja3 = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    nloja4 = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    prbarra = table.Column<string>(type: "character varying(13)", maxLength: 13, nullable: true),
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prdesc = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true),
                    valor = table.Column<decimal>(type: "numeric(10,2)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "pedidos",
                schema: "public",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    prcdla = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prdata = table.Column<DateTime>(type: "date", nullable: true),
                    prfabr = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    status = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "prodextr",
                schema: "public",
                columns: table => new
                {
                    concor1 = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    concor2 = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    concor3 = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    concor4 = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prcons = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    prdesc = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "prodneg",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prdata = table.Column<DateTime>(type: "date", nullable: true),
                    prestq = table.Column<decimal>(type: "numeric(4,0)", nullable: true),
                    prhora = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(4,0)", nullable: true),
                    prtipo = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "produto",
                schema: "public",
                columns: table => new
                {
                    coddcb = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    codesta = table.Column<string>(type: "character varying(9)", maxLength: 9, nullable: true),
                    codfis = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    comissao = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    desc_max = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    est_minimo = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    etbarra = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    etgraf = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    prbarra = table.Column<string>(type: "character varying(13)", maxLength: 13, nullable: true),
                    prcddt = table.Column<DateTime>(type: "date", nullable: true),
                    prcdimp = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    prcdimp2 = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    prcdla = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    prcdlucr = table.Column<decimal>(type: "numeric(10,6)", nullable: true),
                    prcdse = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    prclas = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prcons = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    prconscv = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    prdata = table.Column<DateTime>(type: "date", nullable: true),
                    prdesc = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    prdesconv = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    prdtul = table.Column<DateTime>(type: "date", nullable: true),
                    premb = table.Column<decimal>(type: "numeric(4,0)", nullable: true),
                    prentr = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    prestq = table.Column<decimal>(type: "numeric(4,0)", nullable: true),
                    pretiq = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    prfabr = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    prfinal = table.Column<decimal>(type: "numeric(4,0)", nullable: true),
                    prfixa = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    pricms = table.Column<decimal>(type: "numeric(2,0)", nullable: true),
                    prinicial = table.Column<decimal>(type: "numeric(4,0)", nullable: true),
                    prloca = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    prlote = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    prmesant = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    prncms = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: true),
                    prneutro = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true),
                    prnola = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    prnose = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    prpis = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    prpopular = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    prporta = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prpos = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true),
                    prpret = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    prprinci = table.Column<string>(type: "character varying(130)", maxLength: 130, nullable: true),
                    prpromo = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    prreg = table.Column<string>(type: "character varying(13)", maxLength: 13, nullable: true),
                    prsal = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    prsitu = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    prtestq = table.Column<decimal>(type: "numeric(4,0)", nullable: true),
                    prulte = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    prun = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    prvalid = table.Column<DateTime>(type: "date", nullable: true),
                    secao = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    tipo = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    ul_ven = table.Column<DateTime>(type: "date", nullable: true),
                    ultfor = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    ultped = table.Column<DateTime>(type: "date", nullable: true),
                    ultpreco = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true),
                    vendant = table.Column<decimal>(type: "numeric(4,0)", nullable: true),
                    vendatu = table.Column<decimal>(type: "numeric(4,0)", nullable: true),
                    vlcomis = table.Column<decimal>(type: "numeric(12,2)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "produtoold",
                schema: "public",
                columns: table => new
                {
                    coddcb = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    codesta = table.Column<string>(type: "character varying(9)", maxLength: 9, nullable: true),
                    codfis = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    comissao = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    desc_max = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    est_minimo = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    etbarra = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    etgraf = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    prbarra = table.Column<string>(type: "character varying(13)", maxLength: 13, nullable: true),
                    prcddt = table.Column<DateTime>(type: "date", nullable: true),
                    prcdimp = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    prcdimp2 = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    prcdla = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    prcdlucr = table.Column<decimal>(type: "numeric(10,6)", nullable: true),
                    prcdse = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    prclas = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prcons = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    prconscv = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    prdata = table.Column<DateTime>(type: "date", nullable: true),
                    prdesc = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    prdesconv = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    prdtul = table.Column<DateTime>(type: "date", nullable: true),
                    premb = table.Column<decimal>(type: "numeric(4,0)", nullable: true),
                    prentr = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    prestq = table.Column<decimal>(type: "numeric(4,0)", nullable: true),
                    pretiq = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    prfabr = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    prfixa = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    pricms = table.Column<decimal>(type: "numeric(2,0)", nullable: true),
                    prinicial = table.Column<decimal>(type: "numeric(4,0)", nullable: true),
                    prloca = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    prlote = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    prmesant = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    prncms = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: true),
                    prneutro = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true),
                    prnola = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    prnose = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    prpis = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    prpopular = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    prporta = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prpos = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true),
                    prpret = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    prprinci = table.Column<string>(type: "character varying(130)", maxLength: 130, nullable: true),
                    prpromo = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    prreg = table.Column<string>(type: "character varying(13)", maxLength: 13, nullable: true),
                    prsal = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    prsitu = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    prtestq = table.Column<decimal>(type: "numeric(4,0)", nullable: true),
                    prulte = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    prun = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    prvalid = table.Column<DateTime>(type: "date", nullable: true),
                    secao = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    tipo = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    ul_ven = table.Column<DateTime>(type: "date", nullable: true),
                    ultfor = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    ultped = table.Column<DateTime>(type: "date", nullable: true),
                    ultpreco = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    vendant = table.Column<decimal>(type: "numeric(4,0)", nullable: true),
                    vendatu = table.Column<decimal>(type: "numeric(4,0)", nullable: true),
                    vlcomis = table.Column<decimal>(type: "numeric(12,2)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "psico",
                schema: "public",
                columns: table => new
                {
                    barras = table.Column<string>(type: "character varying(13)", maxLength: 13, nullable: true),
                    cid = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    cnpj = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    crm = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    data = table.Column<DateTime>(type: "date", nullable: true),
                    emissao = table.Column<DateTime>(type: "date", nullable: true),
                    fone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    fornec = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    idade = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    lote = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    motivo = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    nasc = table.Column<DateTime>(type: "date", nullable: true),
                    nf = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: true),
                    nome = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    nomemed = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    orgao = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true),
                    paciente = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    porta = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prdesc = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    prolong = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    prreg = table.Column<string>(type: "character varying(13)", maxLength: 13, nullable: true),
                    qtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    receita = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    rg = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: true),
                    sexo = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    ticket = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    tipo = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    tpcons = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    tpidade = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    tpmed = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    tpreceita = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    uf = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    ufcons = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    unidade = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true),
                    usomed = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "rancliqt",
                schema: "public",
                columns: table => new
                {
                    bacodi = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true),
                    cancelado = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    codcli = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    data = table.Column<DateTime>(type: "date", nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    ticket = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    tipo = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    tot_comis = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    tot_descon = table.Column<decimal>(type: "numeric(2,0)", nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true),
                    vl_tot = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    vl_unit = table.Column<decimal>(type: "numeric(12,2)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ranclivl",
                schema: "public",
                columns: table => new
                {
                    bacodi = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true),
                    caixa = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    cancelado = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    codcli = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    data = table.Column<DateTime>(type: "date", nullable: true),
                    hora = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    n_fiscal = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    ticket = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    tipo = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    tot_ven = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "reconst",
                schema: "public",
                columns: table => new
                {
                    arquivo = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    data = table.Column<DateTime>(type: "date", nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    necessita = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    posicao = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "reducao",
                schema: "public",
                columns: table => new
                {
                    acresc = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: true),
                    acresfin = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: true),
                    aliquota = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    cancela = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: true),
                    cns = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    cnsi = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: true),
                    coo = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    data = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    desconto = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: true),
                    gtda = table.Column<string>(type: "character varying(18)", maxLength: 18, nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    nsi = table.Column<string>(type: "character varying(126)", maxLength: 126, nullable: true),
                    rzaut = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    sangria = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    supri = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: true),
                    tributo = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "relator",
                schema: "public",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    nivel = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    relatorio = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "res_ano",
                schema: "public",
                columns: table => new
                {
                    cli_atds = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    descrec = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    diastrab = table.Column<decimal>(type: "numeric(2,0)", nullable: true),
                    entradas = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    mes_ref = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    rec_fiado = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    tot_estoq = table.Column<decimal>(type: "numeric(15,2)", nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true),
                    vda_conv = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    vda_vista = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    ven_fiado = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    ven_mes = table.Column<decimal>(type: "numeric(15,2)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "retirada",
                schema: "public",
                columns: table => new
                {
                    caixa = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    data = table.Column<DateTime>(type: "date", nullable: true),
                    hora = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UniqueCode = table.Column<string>(type: "text", nullable: true),
                    valorch = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    valordh = table.Column<decimal>(type: "numeric(12,2)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "sal",
                schema: "public",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    salcod = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    salnome = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "secao",
                schema: "public",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    secodi = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    senome = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "senha",
                schema: "public",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    sen = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: true),
                    sencheq = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    sencit = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    senclich = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    senclip = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    sencont = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    sendate = table.Column<DateTime>(type: "date", nullable: true),
                    sendefa = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    sendesc = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    sendesc1 = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    sendesc2 = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    sendesc3 = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    sendesc4 = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    sendesc5 = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    sendesc6 = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    sendia = table.Column<decimal>(type: "numeric(3,0)", nullable: true),
                    senestq = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    senetq = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    senetqb = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    senetqe = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    senetqp = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    senfia = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    senfiacr = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    senfiatr = table.Column<decimal>(type: "numeric(3,0)", nullable: true),
                    senfis = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    senlin = table.Column<decimal>(type: "numeric(3,0)", nullable: true),
                    senman = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    senmdprint = table.Column<decimal>(type: "numeric(2,0)", nullable: true),
                    senmulta = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    senniv = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    senpar = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    senpcli = table.Column<DateTime>(type: "date", nullable: true),
                    senpme = table.Column<decimal>(type: "numeric(5,0)", nullable: true),
                    senponto = table.Column<decimal>(type: "numeric(5,0)", nullable: true),
                    senport = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    senprint = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    senprot = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: true),
                    senrec = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    senrel = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    senrepete = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    senver = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    senvlpon = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "servico",
                schema: "public",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    svcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    svcomb = table.Column<decimal>(type: "numeric(2,0)", nullable: true),
                    svdesc = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    svpr01 = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    svpr02 = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    svpr03 = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    svpr04 = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    svpr05 = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    svprec = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    svven1 = table.Column<decimal>(type: "numeric(5,0)", nullable: true),
                    svven2 = table.Column<decimal>(type: "numeric(5,0)", nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "sistema",
                schema: "public",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ticket = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true),
                    usuario = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "slpharma",
                schema: "public",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    reconst = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "spool",
                schema: "public",
                columns: table => new
                {
                    arquivo = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: true),
                    data = table.Column<DateTime>(type: "date", nullable: true),
                    descr = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    hora = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    nivel = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "subsecao",
                schema: "public",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    secaopert = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    subimpost = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    subncm = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: true),
                    subsecodi = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    subselucr = table.Column<decimal>(type: "numeric(8,6)", nullable: true),
                    subsenome = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    subseprec = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true),
                    valrec = table.Column<decimal>(type: "numeric(3,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tabela",
                schema: "public",
                columns: table => new
                {
                    abc = table.Column<string>(type: "character varying(9)", maxLength: 9, nullable: true),
                    barra = table.Column<decimal>(type: "numeric(13,0)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ctr = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    custom = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    des = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true),
                    dtvig = table.Column<DateTime>(type: "date", nullable: true),
                    fra1 = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    ipi = table.Column<decimal>(type: "numeric(6,2)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    lab_nom = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    med_apr = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true),
                    med_des = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true),
                    med_princi = table.Column<string>(type: "character varying(130)", maxLength: 130, nullable: true),
                    med_regims = table.Column<string>(type: "character varying(13)", maxLength: 13, nullable: true),
                    negpos = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true),
                    neutro = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true),
                    nom = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    pco1 = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    pla1 = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    uni = table.Column<decimal>(type: "numeric(3,0)", nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "temp",
                schema: "public",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    desconto = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    descricao = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prcons = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    prconsd = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    qtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true),
                    vl_total = table.Column<decimal>(type: "numeric(12,2)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tempo",
                schema: "public",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    desconto = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    descricao = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    estoque = table.Column<decimal>(type: "numeric(4,0)", nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    pedido = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prcons = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    prconsd = table.Column<decimal>(type: "numeric(12,4)", nullable: true),
                    qtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true),
                    vl_total = table.Column<decimal>(type: "numeric(12,2)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ticket",
                schema: "public",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ecf = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ticket = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "transfer",
                schema: "public",
                columns: table => new
                {
                    balcon = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    etiqueta = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    filcodi = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true),
                    hora = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    impresso = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prcons = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    qtde = table.Column<decimal>(type: "numeric(4,0)", nullable: true),
                    trdata = table.Column<DateTime>(type: "date", nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "troco1",
                schema: "public",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    data = table.Column<DateTime>(type: "date", nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    initroco = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    troco_ini = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "troco10",
                schema: "public",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    data = table.Column<DateTime>(type: "date", nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    initroco = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    troco_ini = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "troco11",
                schema: "public",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    data = table.Column<DateTime>(type: "date", nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    initroco = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    troco_ini = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "troco12",
                schema: "public",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    data = table.Column<DateTime>(type: "date", nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    initroco = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    troco_ini = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "troco13",
                schema: "public",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    data = table.Column<DateTime>(type: "date", nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    initroco = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    troco_ini = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "troco14",
                schema: "public",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    data = table.Column<DateTime>(type: "date", nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    initroco = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    troco_ini = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "troco15",
                schema: "public",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    data = table.Column<DateTime>(type: "date", nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    initroco = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    troco_ini = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "troco16",
                schema: "public",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    data = table.Column<DateTime>(type: "date", nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    initroco = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    troco_ini = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "troco17",
                schema: "public",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    data = table.Column<DateTime>(type: "date", nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    initroco = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    troco_ini = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "troco18",
                schema: "public",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    data = table.Column<DateTime>(type: "date", nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    initroco = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    troco_ini = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "troco19",
                schema: "public",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    data = table.Column<DateTime>(type: "date", nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    initroco = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    troco_ini = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "troco2",
                schema: "public",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    data = table.Column<DateTime>(type: "date", nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    initroco = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    troco_ini = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "troco20",
                schema: "public",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    data = table.Column<DateTime>(type: "date", nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    initroco = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    troco_ini = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "troco3",
                schema: "public",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    data = table.Column<DateTime>(type: "date", nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    initroco = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    troco_ini = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "troco4",
                schema: "public",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    data = table.Column<DateTime>(type: "date", nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    initroco = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    troco_ini = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "troco5",
                schema: "public",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    data = table.Column<DateTime>(type: "date", nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    initroco = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    troco_ini = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "troco6",
                schema: "public",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    data = table.Column<DateTime>(type: "date", nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    initroco = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    troco_ini = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "troco7",
                schema: "public",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    data = table.Column<DateTime>(type: "date", nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    initroco = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    troco_ini = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "troco8",
                schema: "public",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    data = table.Column<DateTime>(type: "date", nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    initroco = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    troco_ini = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "troco9",
                schema: "public",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    data = table.Column<DateTime>(type: "date", nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    initroco = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    troco_ini = table.Column<decimal>(type: "numeric(12,2)", nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "urv",
                schema: "public",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    data = table.Column<DateTime>(type: "date", nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UniqueCode = table.Column<string>(type: "text", nullable: true),
                    valor = table.Column<decimal>(type: "numeric(7,2)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "usefarma",
                schema: "public",
                columns: table => new
                {
                    acesso1 = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    acesso10 = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    acesso2 = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    acesso3 = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    acesso4 = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    acesso5 = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    acesso6 = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    acesso7 = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    acesso8 = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    acesso9 = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    nivel = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    nome = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    senha = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "user",
                schema: "public",
                columns: table => new
                {
                    apelido = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    bairro = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: true),
                    cep = table.Column<string>(type: "character varying(9)", maxLength: 9, nullable: true),
                    cgc = table.Column<string>(type: "character varying(18)", maxLength: 18, nullable: true),
                    cidade = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: true),
                    comefia = table.Column<string>(type: "character varying(48)", maxLength: 48, nullable: true),
                    coment1 = table.Column<string>(type: "character varying(48)", maxLength: 48, nullable: true),
                    coment2 = table.Column<string>(type: "character varying(48)", maxLength: 48, nullable: true),
                    coment3 = table.Column<string>(type: "character varying(48)", maxLength: 48, nullable: true),
                    coment4 = table.Column<string>(type: "character varying(48)", maxLength: 48, nullable: true),
                    cpf = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: true),
                    disk1 = table.Column<string>(type: "character varying(48)", maxLength: 48, nullable: true),
                    disk2 = table.Column<string>(type: "character varying(48)", maxLength: 48, nullable: true),
                    disk3 = table.Column<string>(type: "character varying(48)", maxLength: 48, nullable: true),
                    disk4 = table.Column<string>(type: "character varying(48)", maxLength: 48, nullable: true),
                    disk5 = table.Column<string>(type: "character varying(48)", maxLength: 48, nullable: true),
                    empresa = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    endereco = table.Column<string>(type: "character varying(49)", maxLength: 49, nullable: true),
                    fax = table.Column<string>(type: "character varying(9)", maxLength: 9, nullable: true),
                    ibge = table.Column<string>(type: "character varying(7)", maxLength: 7, nullable: true),
                    imposto = table.Column<decimal>(type: "numeric(5,2)", nullable: true),
                    inscrest = table.Column<string>(type: "character varying(18)", maxLength: 18, nullable: true),
                    licenca = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: true),
                    lote = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    mod_nf = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    nfe = table.Column<decimal>(type: "numeric(6,0)", nullable: true),
                    nome = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    numero = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    numseq = table.Column<decimal>(type: "numeric(10,0)", nullable: true),
                    pop = table.Column<decimal>(type: "numeric(12,0)", nullable: true),
                    serie_nf = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    telefone = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "usoint",
                schema: "public",
                columns: table => new
                {
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    data = table.Column<DateTime>(type: "date", nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    qtde = table.Column<decimal>(type: "numeric(4,0)", nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0100",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0101",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0102",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0103",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0104",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0105",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0106",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0107",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0108",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0109",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0110",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0111",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0112",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0113",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0114",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0115",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0116",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0117",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0118",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0119",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0120",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0171",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0194",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0197",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0199",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0200",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0201",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0202",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0203",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0204",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0205",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0206",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0207",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0208",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0209",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0210",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0211",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0212",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0213",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0214",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0215",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0216",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0217",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0218",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0219",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0220",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0271",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0300",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0301",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0302",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0303",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0304",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0305",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0306",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0307",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0308",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0309",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0310",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0311",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0312",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0313",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0314",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0315",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0316",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0317",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0318",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0319",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0394",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0400",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0401",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0402",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0403",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0404",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0405",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0406",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0407",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0408",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0409",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0410",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0411",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0412",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0413",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0414",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0415",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0416",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0417",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0418",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0419",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0494",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0500",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0501",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0502",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0503",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0504",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0505",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0506",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0507",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0508",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0509",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0510",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0511",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0512",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0513",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0514",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0515",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0516",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0517",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0518",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0519",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0594",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0600",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0601",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0602",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0603",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0604",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0605",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0606",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0607",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0608",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0609",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0610",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0611",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0612",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0613",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0614",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0615",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0616",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0617",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0618",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0619",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0694",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0700",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0701",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0702",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0703",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0704",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0705",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0706",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0707",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0708",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0709",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0710",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0711",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0712",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0713",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0714",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0715",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0716",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0717",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0718",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0719",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0720",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0794",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0800",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0801",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0802",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0803",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0804",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0805",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0806",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0807",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0808",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0809",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0810",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0811",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0812",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0813",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0814",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0815",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0816",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0817",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0818",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0819",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0894",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0900",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0901",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0902",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0903",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0904",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0905",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0906",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0907",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0908",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0909",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0910",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0911",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0912",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0913",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0914",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0915",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0916",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0917",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0918",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0919",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend0994",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend1000",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend1001",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend1002",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend1003",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend1004",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend1005",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend1006",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend1007",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend1008",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend1009",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend1010",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend1011",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend1012",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend1013",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend1014",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend1015",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend1016",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend1017",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend1018",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend1019",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend1100",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend1101",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend1102",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend1103",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend1104",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend1105",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend1106",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend1107",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend1108",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend1109",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend1110",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend1111",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend1112",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend1113",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend1114",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend1115",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend1116",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend1117",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend1118",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend1119",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend1170",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend1200",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend1201",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend1202",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend1203",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend1204",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend1205",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend1206",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend1207",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend1208",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend1209",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend1210",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend1211",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend1212",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend1213",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend1214",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend1215",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend1216",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend1217",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend1218",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend1219",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend1270",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vend1293",
                schema: "public",
                columns: table => new
                {
                    prcodi = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    prqtde = table.Column<decimal>(type: "numeric(6,0)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Beneficiaries_Addresses_AddressId",
                table: "Beneficiaries",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Beneficiaries_Addresses_AddressId1",
                table: "Beneficiaries",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Supplier_Addresses_AddressId",
                table: "Supplier",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
