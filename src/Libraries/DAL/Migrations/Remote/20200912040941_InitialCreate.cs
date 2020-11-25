using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DAL.Migrations.Remote
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UniqueCode = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 9, 12, 4, 9, 41, 38, DateTimeKind.Unspecified).AddTicks(9507), new TimeSpan(0, 0, 0, 0, 0))),
                    LastUpdatedOn = table.Column<DateTimeOffset>(nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 9, 12, 4, 9, 41, 38, DateTimeKind.Unspecified).AddTicks(9839), new TimeSpan(0, 0, 0, 0, 0))),
                    FirstAddressLine = table.Column<string>(nullable: true),
                    SecondAddressLine = table.Column<string>(nullable: true),
                    Zipcode = table.Column<string>(nullable: true),
                    Addressnumber = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    AddressState = table.Column<string>(nullable: true),
                    District = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Billings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UniqueCode = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 9, 12, 4, 9, 41, 37, DateTimeKind.Unspecified).AddTicks(7278), new TimeSpan(0, 0, 0, 0, 0))),
                    LastUpdatedOn = table.Column<DateTimeOffset>(nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 9, 12, 4, 9, 41, 37, DateTimeKind.Unspecified).AddTicks(7832), new TimeSpan(0, 0, 0, 0, 0))),
                    BeneficiaryId = table.Column<int>(nullable: false),
                    BeneficiaryName = table.Column<string>(nullable: true),
                    PersonType = table.Column<int>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Discount = table.Column<decimal>(nullable: true),
                    IsPaid = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Billings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Syncronization",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UniqueCode = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 9, 12, 4, 9, 40, 783, DateTimeKind.Unspecified).AddTicks(848), new TimeSpan(0, 0, 0, 0, 0))),
                    LastUpdatedOn = table.Column<DateTimeOffset>(nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 9, 12, 4, 9, 40, 785, DateTimeKind.Unspecified).AddTicks(5173), new TimeSpan(0, 0, 0, 0, 0))),
                    UpdatedFrom = table.Column<string>(nullable: true),
                    LastSyncronization = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Syncronization", x => x.Id);
                });
            
            migrationBuilder.CreateTable(
                name: "Beneficiaries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UniqueCode = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 9, 12, 4, 9, 41, 67, DateTimeKind.Unspecified).AddTicks(1000), new TimeSpan(0, 0, 0, 0, 0))),
                    LastUpdatedOn = table.Column<DateTimeOffset>(nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 9, 12, 4, 9, 41, 67, DateTimeKind.Unspecified).AddTicks(1459), new TimeSpan(0, 0, 0, 0, 0))),
                    Name = table.Column<string>(nullable: true),
                    AddressId = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    Cpf = table.Column<string>(maxLength: 12, nullable: true),
                    Cnpj = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beneficiaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Beneficiaries_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Beneficiaries_Addresses_AddressId1",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UniqueCode = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 9, 12, 4, 9, 41, 18, DateTimeKind.Unspecified).AddTicks(5539), new TimeSpan(0, 0, 0, 0, 0))),
                    LastUpdatedOn = table.Column<DateTimeOffset>(nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 9, 12, 4, 9, 41, 18, DateTimeKind.Unspecified).AddTicks(6010), new TimeSpan(0, 0, 0, 0, 0))),
                    AddressId = table.Column<int>(nullable: true),
                    SupplierName = table.Column<string>(nullable: true),
                    Cnpj = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Supplier_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StockEntry",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UniqueCode = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 9, 12, 4, 9, 41, 17, DateTimeKind.Unspecified).AddTicks(7238), new TimeSpan(0, 0, 0, 0, 0))),
                    LastUpdatedOn = table.Column<DateTimeOffset>(nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 9, 12, 4, 9, 41, 17, DateTimeKind.Unspecified).AddTicks(7771), new TimeSpan(0, 0, 0, 0, 0))),
                    SupplierId = table.Column<int>(nullable: true),
                    Quantity = table.Column<int>(nullable: true),
                    DrugMaturityDate = table.Column<DateTime>(nullable: true),
                    NfNumber = table.Column<string>(nullable: true),
                    NfEmissionDate = table.Column<DateTime>(nullable: true),
                    Totalcost = table.Column<decimal>(nullable: true),
                    LotCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockEntry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockEntry_Supplier_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Supplier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UniqueCode = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 9, 12, 4, 9, 41, 68, DateTimeKind.Unspecified).AddTicks(408), new TimeSpan(0, 0, 0, 0, 0))),
                    LastUpdatedOn = table.Column<DateTimeOffset>(nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 9, 12, 4, 9, 41, 68, DateTimeKind.Unspecified).AddTicks(838), new TimeSpan(0, 0, 0, 0, 0))),
                    Ncm = table.Column<string>(nullable: true),
                    QuantityInStock = table.Column<int>(nullable: true),
                    ReorderLevel = table.Column<int>(nullable: true),
                    ReorderQuantity = table.Column<int>(nullable: true),
                    EndCustomerPrice = table.Column<decimal>(nullable: true),
                    CostPrice = table.Column<decimal>(nullable: false),
                    SavingPercentage = table.Column<decimal>(nullable: false),
                    BarCode = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Section = table.Column<string>(nullable: true),
                    MaxDiscountPercentage = table.Column<decimal>(nullable: false),
                    DiscountValue = table.Column<decimal>(nullable: false),
                    Commission = table.Column<string>(nullable: true),
                    ICMS = table.Column<decimal>(nullable: false),
                    MinimumStock = table.Column<int>(nullable: false),
                    MainSupplierName = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    BaseDrugId = table.Column<int>(nullable: true),
                    SupplierId = table.Column<int>(nullable: true),
                    PrCdse = table.Column<string>(nullable: true),
                    ManufacturerId = table.Column<int>(nullable: true),
                    ManufacturerName = table.Column<string>(nullable: true),
                    DrugName = table.Column<string>(nullable: true),
                    CommercialName = table.Column<string>(nullable: true),
                    Classification = table.Column<string>(nullable: true),
                    DrugCost = table.Column<decimal>(nullable: true),
                    Dosage = table.Column<string>(nullable: true),
                    AbsoluteDosageInMg = table.Column<double>(nullable: true),
                    ActivePrinciple = table.Column<string>(nullable: true),
                    LotNumber = table.Column<string>(nullable: true),
                    PrescriptionNeeded = table.Column<bool>(nullable: true),
                    IsPriceFixed = table.Column<bool>(nullable: true),
                    DigitalBuleLink = table.Column<string>(nullable: true),
                    StockEntryId = table.Column<int>(nullable: true),
                    LaboratoryCode = table.Column<string>(nullable:true),
                    LaboratoryName = table.Column<string>(nullable:true),
                    RegistryCode = table.Column<string>(nullable:false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_StockEntry_StockEntryId",
                        column: x => x.StockEntryId,
                        principalTable: "StockEntry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DrugInformation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UniqueCode = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 9, 12, 4, 9, 41, 68, DateTimeKind.Unspecified).AddTicks(7749), new TimeSpan(0, 0, 0, 0, 0))),
                    LastUpdatedOn = table.Column<DateTimeOffset>(nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 9, 12, 4, 9, 41, 68, DateTimeKind.Unspecified).AddTicks(8154), new TimeSpan(0, 0, 0, 0, 0))),
                    DrugId = table.Column<int>(nullable: true),
                    Indication = table.Column<string>(nullable: true),
                    CounterIndication = table.Column<string>(nullable: true),
                    HowWorks = table.Column<string>(nullable: true),
                    HowToUse = table.Column<string>(nullable: true),
                    TypeOfUse = table.Column<string>(nullable: true),
                    MinimalAgeOfUse = table.Column<int>(nullable: true),
                    Substances = table.Column<string>(nullable: true),
                    UserBule = table.Column<string>(nullable: true),
                    ProfessionalBule = table.Column<string>(nullable: true)
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

            migrationBuilder.CreateTable(
                name: "ProductPrice",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UniqueCode = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 9, 12, 4, 9, 41, 75, DateTimeKind.Unspecified).AddTicks(1678), new TimeSpan(0, 0, 0, 0, 0))),
                    LastUpdatedOn = table.Column<DateTimeOffset>(nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 9, 12, 4, 9, 41, 75, DateTimeKind.Unspecified).AddTicks(2218), new TimeSpan(0, 0, 0, 0, 0))),
                    ProductId = table.Column<int>(nullable: false),
                    Pricestartdate = table.Column<DateTimeOffset>(nullable: true),
                    EndCustomerDrugPrice = table.Column<decimal>(nullable: false),
                    CostPrice = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPrice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductPrice_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductShelfLife",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UniqueCode = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 9, 12, 4, 9, 41, 75, DateTimeKind.Unspecified).AddTicks(9155), new TimeSpan(0, 0, 0, 0, 0))),
                    LastUpdatedOn = table.Column<DateTimeOffset>(nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 9, 12, 4, 9, 41, 75, DateTimeKind.Unspecified).AddTicks(9616), new TimeSpan(0, 0, 0, 0, 0))),
                    ProductId = table.Column<int>(nullable: false),
                    StockEntryId = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductShelfLife", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductShelfLife_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductStockEntry",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UniqueCode = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 9, 12, 4, 9, 41, 76, DateTimeKind.Unspecified).AddTicks(6605), new TimeSpan(0, 0, 0, 0, 0))),
                    LastUpdatedOn = table.Column<DateTimeOffset>(nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 9, 12, 4, 9, 41, 76, DateTimeKind.Unspecified).AddTicks(7110), new TimeSpan(0, 0, 0, 0, 0))),
                    ProductId = table.Column<int>(nullable: false),
                    StockEntryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductStockEntry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductStockEntry_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductStockEntry_StockEntry_StockEntryId",
                        column: x => x.StockEntryId,
                        principalTable: "StockEntry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductSupplier",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UniqueCode = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 9, 12, 4, 9, 41, 77, DateTimeKind.Unspecified).AddTicks(9607), new TimeSpan(0, 0, 0, 0, 0))),
                    LastUpdatedOn = table.Column<DateTimeOffset>(nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 9, 12, 4, 9, 41, 78, DateTimeKind.Unspecified).AddTicks(570), new TimeSpan(0, 0, 0, 0, 0))),
                    ProductId = table.Column<int>(nullable: false),
                    SupplierId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSupplier", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductSupplier_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductSupplier_Supplier_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Supplier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiaries_AddressId",
                table: "Beneficiaries",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiaries_AddressId1",
                table: "Beneficiaries",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_DrugInformation_DrugId",
                table: "DrugInformation",
                column: "DrugId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPrice_ProductId",
                table: "ProductPrice",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_StockEntryId",
                table: "Products",
                column: "StockEntryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductShelfLife_ProductId",
                table: "ProductShelfLife",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductStockEntry_ProductId",
                table: "ProductStockEntry",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductStockEntry_StockEntryId",
                table: "ProductStockEntry",
                column: "StockEntryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSupplier_ProductId",
                table: "ProductSupplier",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSupplier_SupplierId",
                table: "ProductSupplier",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_StockEntry_SupplierId",
                table: "StockEntry",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_AddressId",
                table: "Supplier",
                column: "AddressId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Beneficiaries");

            migrationBuilder.DropTable(
                name: "Billings");

            migrationBuilder.DropTable(
                name: "DrugInformation");

            migrationBuilder.DropTable(
                name: "ProductPrice");

            migrationBuilder.DropTable(
                name: "ProductShelfLife");

            migrationBuilder.DropTable(
                name: "ProductStockEntry");

            migrationBuilder.DropTable(
                name: "ProductSupplier");

            migrationBuilder.DropTable(
                name: "Syncronization");

            migrationBuilder.DropTable(
                name: "agenda",
                schema: "public");

            migrationBuilder.DropTable(
                name: "agenda (2)",
                schema: "public");

            migrationBuilder.DropTable(
                name: "balcon",
                schema: "public");

            migrationBuilder.DropTable(
                name: "brindes",
                schema: "public");

            migrationBuilder.DropTable(
                name: "cadlab",
                schema: "public");

            migrationBuilder.DropTable(
                name: "cadlabold",
                schema: "public");

            migrationBuilder.DropTable(
                name: "cadprom",
                schema: "public");

            migrationBuilder.DropTable(
                name: "caixa",
                schema: "public");

            migrationBuilder.DropTable(
                name: "cancdia",
                schema: "public");

            migrationBuilder.DropTable(
                name: "cartao",
                schema: "public");

            migrationBuilder.DropTable(
                name: "cdesp",
                schema: "public");

            migrationBuilder.DropTable(
                name: "chdevol",
                schema: "public");

            migrationBuilder.DropTable(
                name: "cheque",
                schema: "public");

            migrationBuilder.DropTable(
                name: "cli_med",
                schema: "public");

            migrationBuilder.DropTable(
                name: "clicheq",
                schema: "public");

            migrationBuilder.DropTable(
                name: "cliente",
                schema: "public");

            migrationBuilder.DropTable(
                name: "clipago",
                schema: "public");

            migrationBuilder.DropTable(
                name: "contas",
                schema: "public");

            migrationBuilder.DropTable(
                name: "conv",
                schema: "public");

            migrationBuilder.DropTable(
                name: "convenio",
                schema: "public");

            migrationBuilder.DropTable(
                name: "cpagar",
                schema: "public");

            migrationBuilder.DropTable(
                name: "debcli",
                schema: "public");

            migrationBuilder.DropTable(
                name: "delivery",
                schema: "public");

            migrationBuilder.DropTable(
                name: "despesas",
                schema: "public");

            migrationBuilder.DropTable(
                name: "empresa",
                schema: "public");

            migrationBuilder.DropTable(
                name: "encomen",
                schema: "public");

            migrationBuilder.DropTable(
                name: "ent",
                schema: "public");

            migrationBuilder.DropTable(
                name: "entpro",
                schema: "public");

            migrationBuilder.DropTable(
                name: "estq0045",
                schema: "public");

            migrationBuilder.DropTable(
                name: "etiqperf",
                schema: "public");

            migrationBuilder.DropTable(
                name: "etiqprom",
                schema: "public");

            migrationBuilder.DropTable(
                name: "etiqueta",
                schema: "public");

            migrationBuilder.DropTable(
                name: "faltas",
                schema: "public");

            migrationBuilder.DropTable(
                name: "fechconv",
                schema: "public");

            migrationBuilder.DropTable(
                name: "filial",
                schema: "public");

            migrationBuilder.DropTable(
                name: "funcio",
                schema: "public");

            migrationBuilder.DropTable(
                name: "histor",
                schema: "public");

            migrationBuilder.DropTable(
                name: "ibpt",
                schema: "public");

            migrationBuilder.DropTable(
                name: "invent",
                schema: "public");

            migrationBuilder.DropTable(
                name: "logsys",
                schema: "public");

            migrationBuilder.DropTable(
                name: "malclien",
                schema: "public");

            migrationBuilder.DropTable(
                name: "merctran",
                schema: "public");

            migrationBuilder.DropTable(
                name: "mov",
                schema: "public");

            migrationBuilder.DropTable(
                name: "movm",
                schema: "public");

            migrationBuilder.DropTable(
                name: "movme",
                schema: "public");

            migrationBuilder.DropTable(
                name: "movmes",
                schema: "public");

            migrationBuilder.DropTable(
                name: "movnf",
                schema: "public");

            migrationBuilder.DropTable(
                name: "movpop",
                schema: "public");

            migrationBuilder.DropTable(
                name: "natureza",
                schema: "public");

            migrationBuilder.DropTable(
                name: "newcli",
                schema: "public");

            migrationBuilder.DropTable(
                name: "newconv",
                schema: "public");

            migrationBuilder.DropTable(
                name: "newfunc",
                schema: "public");

            migrationBuilder.DropTable(
                name: "newprec",
                schema: "public");

            migrationBuilder.DropTable(
                name: "newprod",
                schema: "public");

            migrationBuilder.DropTable(
                name: "newtab",
                schema: "public");

            migrationBuilder.DropTable(
                name: "nfe",
                schema: "public");

            migrationBuilder.DropTable(
                name: "nota",
                schema: "public");

            migrationBuilder.DropTable(
                name: "notaf",
                schema: "public");

            migrationBuilder.DropTable(
                name: "nped",
                schema: "public");

            migrationBuilder.DropTable(
                name: "num_tmp",
                schema: "public");

            migrationBuilder.DropTable(
                name: "numped",
                schema: "public");

            migrationBuilder.DropTable(
                name: "ped0204",
                schema: "public");

            migrationBuilder.DropTable(
                name: "ped0301",
                schema: "public");

            migrationBuilder.DropTable(
                name: "ped0406",
                schema: "public");

            migrationBuilder.DropTable(
                name: "ped1103",
                schema: "public");

            migrationBuilder.DropTable(
                name: "ped1406",
                schema: "public");

            migrationBuilder.DropTable(
                name: "ped1912",
                schema: "public");

            migrationBuilder.DropTable(
                name: "pedidos",
                schema: "public");

            migrationBuilder.DropTable(
                name: "prodextr",
                schema: "public");

            migrationBuilder.DropTable(
                name: "prodneg",
                schema: "public");

            migrationBuilder.DropTable(
                name: "produto",
                schema: "public");

            migrationBuilder.DropTable(
                name: "produtoold",
                schema: "public");

            migrationBuilder.DropTable(
                name: "psico",
                schema: "public");

            migrationBuilder.DropTable(
                name: "rancliqt",
                schema: "public");

            migrationBuilder.DropTable(
                name: "ranclivl",
                schema: "public");

            migrationBuilder.DropTable(
                name: "reconst",
                schema: "public");

            migrationBuilder.DropTable(
                name: "reducao",
                schema: "public");

            migrationBuilder.DropTable(
                name: "relator",
                schema: "public");

            migrationBuilder.DropTable(
                name: "res_ano",
                schema: "public");

            migrationBuilder.DropTable(
                name: "retirada",
                schema: "public");

            migrationBuilder.DropTable(
                name: "sal",
                schema: "public");

            migrationBuilder.DropTable(
                name: "secao",
                schema: "public");

            migrationBuilder.DropTable(
                name: "senha",
                schema: "public");

            migrationBuilder.DropTable(
                name: "servico",
                schema: "public");

            migrationBuilder.DropTable(
                name: "sistema",
                schema: "public");

            migrationBuilder.DropTable(
                name: "slpharma",
                schema: "public");

            migrationBuilder.DropTable(
                name: "spool",
                schema: "public");

            migrationBuilder.DropTable(
                name: "subsecao",
                schema: "public");

            migrationBuilder.DropTable(
                name: "tabela",
                schema: "public");

            migrationBuilder.DropTable(
                name: "temp",
                schema: "public");

            migrationBuilder.DropTable(
                name: "tempo",
                schema: "public");

            migrationBuilder.DropTable(
                name: "ticket",
                schema: "public");

            migrationBuilder.DropTable(
                name: "transfer",
                schema: "public");

            migrationBuilder.DropTable(
                name: "troco1",
                schema: "public");

            migrationBuilder.DropTable(
                name: "troco10",
                schema: "public");

            migrationBuilder.DropTable(
                name: "troco11",
                schema: "public");

            migrationBuilder.DropTable(
                name: "troco12",
                schema: "public");

            migrationBuilder.DropTable(
                name: "troco13",
                schema: "public");

            migrationBuilder.DropTable(
                name: "troco14",
                schema: "public");

            migrationBuilder.DropTable(
                name: "troco15",
                schema: "public");

            migrationBuilder.DropTable(
                name: "troco16",
                schema: "public");

            migrationBuilder.DropTable(
                name: "troco17",
                schema: "public");

            migrationBuilder.DropTable(
                name: "troco18",
                schema: "public");

            migrationBuilder.DropTable(
                name: "troco19",
                schema: "public");

            migrationBuilder.DropTable(
                name: "troco2",
                schema: "public");

            migrationBuilder.DropTable(
                name: "troco20",
                schema: "public");

            migrationBuilder.DropTable(
                name: "troco3",
                schema: "public");

            migrationBuilder.DropTable(
                name: "troco4",
                schema: "public");

            migrationBuilder.DropTable(
                name: "troco5",
                schema: "public");

            migrationBuilder.DropTable(
                name: "troco6",
                schema: "public");

            migrationBuilder.DropTable(
                name: "troco7",
                schema: "public");

            migrationBuilder.DropTable(
                name: "troco8",
                schema: "public");

            migrationBuilder.DropTable(
                name: "troco9",
                schema: "public");

            migrationBuilder.DropTable(
                name: "urv",
                schema: "public");

            migrationBuilder.DropTable(
                name: "usefarma",
                schema: "public");

            migrationBuilder.DropTable(
                name: "user",
                schema: "public");

            migrationBuilder.DropTable(
                name: "usoint",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0100",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0101",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0102",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0103",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0104",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0105",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0106",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0107",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0108",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0109",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0110",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0111",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0112",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0113",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0114",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0115",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0116",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0117",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0118",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0119",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0120",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0171",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0194",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0197",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0199",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0200",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0201",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0202",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0203",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0204",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0205",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0206",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0207",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0208",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0209",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0210",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0211",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0212",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0213",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0214",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0215",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0216",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0217",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0218",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0219",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0220",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0271",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0300",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0301",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0302",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0303",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0304",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0305",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0306",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0307",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0308",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0309",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0310",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0311",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0312",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0313",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0314",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0315",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0316",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0317",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0318",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0319",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0394",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0400",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0401",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0402",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0403",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0404",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0405",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0406",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0407",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0408",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0409",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0410",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0411",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0412",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0413",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0414",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0415",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0416",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0417",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0418",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0419",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0494",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0500",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0501",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0502",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0503",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0504",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0505",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0506",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0507",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0508",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0509",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0510",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0511",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0512",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0513",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0514",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0515",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0516",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0517",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0518",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0519",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0594",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0600",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0601",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0602",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0603",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0604",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0605",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0606",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0607",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0608",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0609",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0610",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0611",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0612",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0613",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0614",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0615",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0616",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0617",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0618",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0619",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0694",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0700",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0701",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0702",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0703",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0704",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0705",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0706",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0707",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0708",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0709",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0710",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0711",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0712",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0713",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0714",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0715",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0716",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0717",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0718",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0719",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0720",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0794",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0800",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0801",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0802",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0803",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0804",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0805",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0806",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0807",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0808",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0809",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0810",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0811",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0812",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0813",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0814",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0815",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0816",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0817",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0818",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0819",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0894",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0900",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0901",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0902",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0903",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0904",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0905",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0906",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0907",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0908",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0909",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0910",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0911",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0912",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0913",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0914",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0915",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0916",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0917",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0918",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0919",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend0994",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend1000",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend1001",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend1002",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend1003",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend1004",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend1005",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend1006",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend1007",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend1008",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend1009",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend1010",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend1011",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend1012",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend1013",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend1014",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend1015",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend1016",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend1017",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend1018",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend1019",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend1100",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend1101",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend1102",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend1103",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend1104",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend1105",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend1106",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend1107",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend1108",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend1109",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend1110",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend1111",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend1112",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend1113",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend1114",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend1115",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend1116",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend1117",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend1118",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend1119",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend1170",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend1200",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend1201",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend1202",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend1203",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend1204",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend1205",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend1206",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend1207",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend1208",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend1209",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend1210",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend1211",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend1212",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend1213",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend1214",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend1215",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend1216",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend1217",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend1218",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend1219",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend1270",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vend1293",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "StockEntry");

            migrationBuilder.DropTable(
                name: "Supplier");

            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
