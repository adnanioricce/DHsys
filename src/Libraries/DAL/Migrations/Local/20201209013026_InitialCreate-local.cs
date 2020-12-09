using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class InitialCreatelocal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstAddressLine = table.Column<string>(type: "TEXT", nullable: true),
                    SecondAddressLine = table.Column<string>(type: "TEXT", nullable: true),
                    Zipcode = table.Column<string>(type: "TEXT", nullable: true),
                    Addressnumber = table.Column<string>(type: "TEXT", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: true),
                    AddressState = table.Column<string>(type: "TEXT", nullable: true),
                    District = table.Column<string>(type: "TEXT", nullable: true),
                    UniqueCode = table.Column<string>(type: "TEXT", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TEXT", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 1, 30, 26, 809, DateTimeKind.Unspecified).AddTicks(7624), new TimeSpan(0, 0, 0, 0, 0))),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "TEXT", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 1, 30, 26, 809, DateTimeKind.Unspecified).AddTicks(7946), new TimeSpan(0, 0, 0, 0, 0)))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Billings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BeneficiaryId = table.Column<int>(type: "INTEGER", nullable: false),
                    BeneficiaryName = table.Column<string>(type: "TEXT", nullable: true),
                    PersonType = table.Column<int>(type: "INTEGER", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    Discount = table.Column<decimal>(type: "TEXT", nullable: true),
                    IsPaid = table.Column<bool>(type: "INTEGER", nullable: false),
                    UniqueCode = table.Column<string>(type: "TEXT", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TEXT", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 1, 30, 26, 809, DateTimeKind.Unspecified).AddTicks(5195), new TimeSpan(0, 0, 0, 0, 0))),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "TEXT", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 1, 30, 26, 809, DateTimeKind.Unspecified).AddTicks(5617), new TimeSpan(0, 0, 0, 0, 0)))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Billings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    ShowOnHomepage = table.Column<bool>(type: "INTEGER", nullable: false),
                    UniqueCode = table.Column<string>(type: "TEXT", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TEXT", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 1, 30, 26, 815, DateTimeKind.Unspecified).AddTicks(4432), new TimeSpan(0, 0, 0, 0, 0))),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "TEXT", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 1, 30, 26, 815, DateTimeKind.Unspecified).AddTicks(4825), new TimeSpan(0, 0, 0, 0, 0)))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MediaResource",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Size = table.Column<long>(type: "INTEGER", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    SourceUrl = table.Column<string>(type: "TEXT", nullable: true),
                    Caption = table.Column<string>(type: "TEXT", nullable: true),
                    UniqueCode = table.Column<string>(type: "TEXT", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TEXT", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 1, 30, 26, 807, DateTimeKind.Unspecified).AddTicks(7411), new TimeSpan(0, 0, 0, 0, 0))),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "TEXT", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 1, 30, 26, 807, DateTimeKind.Unspecified).AddTicks(7789), new TimeSpan(0, 0, 0, 0, 0)))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaResource", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "POSOrder",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DiscountTotal = table.Column<decimal>(type: "TEXT", nullable: false),
                    PaymentMethod = table.Column<int>(type: "INTEGER", nullable: false),
                    HasDealWithStore = table.Column<bool>(type: "INTEGER", nullable: false),
                    ConsumerCode = table.Column<string>(type: "TEXT", nullable: true),
                    UniqueCode = table.Column<string>(type: "TEXT", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TEXT", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 1, 30, 26, 806, DateTimeKind.Unspecified).AddTicks(2495), new TimeSpan(0, 0, 0, 0, 0))),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "TEXT", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 1, 30, 26, 806, DateTimeKind.Unspecified).AddTicks(2968), new TimeSpan(0, 0, 0, 0, 0)))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_POSOrder", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Ncm = table.Column<string>(type: "TEXT", nullable: true),
                    QuantityInStock = table.Column<int>(type: "INTEGER", nullable: true),
                    ReorderLevel = table.Column<int>(type: "INTEGER", nullable: true),
                    ReorderQuantity = table.Column<int>(type: "INTEGER", nullable: true),
                    EndCustomerPrice = table.Column<decimal>(type: "TEXT", nullable: true),
                    CostPrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    SavingPercentage = table.Column<decimal>(type: "TEXT", nullable: false),
                    BarCode = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Section = table.Column<string>(type: "TEXT", nullable: true),
                    MaxDiscountPercentage = table.Column<decimal>(type: "TEXT", nullable: false),
                    DiscountValue = table.Column<decimal>(type: "TEXT", nullable: false),
                    Commission = table.Column<string>(type: "TEXT", nullable: true),
                    ICMS = table.Column<decimal>(type: "TEXT", nullable: false),
                    MinimumStock = table.Column<int>(type: "INTEGER", nullable: false),
                    MainSupplierName = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    RegistryCode = table.Column<string>(type: "TEXT", nullable: true),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false),
                    BaseDrugId = table.Column<int>(type: "INTEGER", nullable: true),
                    PrCdse = table.Column<string>(type: "TEXT", nullable: true),
                    ManufacturerId = table.Column<int>(type: "INTEGER", nullable: true),
                    ManufacturerName = table.Column<string>(type: "TEXT", nullable: true),
                    CommercialName = table.Column<string>(type: "TEXT", nullable: true),
                    Classification = table.Column<string>(type: "TEXT", nullable: true),
                    Dosage = table.Column<string>(type: "TEXT", nullable: true),
                    AbsoluteDosageInMg = table.Column<double>(type: "REAL", nullable: true),
                    ActivePrinciple = table.Column<string>(type: "TEXT", nullable: true),
                    LotNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PrescriptionNeeded = table.Column<bool>(type: "INTEGER", nullable: true),
                    IsPriceFixed = table.Column<bool>(type: "INTEGER", nullable: true),
                    DigitalBuleLink = table.Column<string>(type: "TEXT", nullable: true),
                    LaboratoryCode = table.Column<string>(type: "TEXT", nullable: true),
                    LaboratoryName = table.Column<string>(type: "TEXT", nullable: true),
                    UniqueCode = table.Column<string>(type: "TEXT", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TEXT", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 1, 30, 26, 817, DateTimeKind.Unspecified).AddTicks(1215), new TimeSpan(0, 0, 0, 0, 0))),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "TEXT", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 1, 30, 26, 817, DateTimeKind.Unspecified).AddTicks(1541), new TimeSpan(0, 0, 0, 0, 0)))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Syncronization",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UpdatedFrom = table.Column<string>(type: "TEXT", nullable: true),
                    LastSyncronization = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    UniqueCode = table.Column<string>(type: "TEXT", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TEXT", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 1, 30, 26, 745, DateTimeKind.Unspecified).AddTicks(3479), new TimeSpan(0, 0, 0, 0, 0))),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "TEXT", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 1, 30, 26, 745, DateTimeKind.Unspecified).AddTicks(4095), new TimeSpan(0, 0, 0, 0, 0)))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Syncronization", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "beneficiaries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    AddressId = table.Column<int>(type: "INTEGER", nullable: false),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false),
                    Cpf = table.Column<string>(type: "TEXT", maxLength: 12, nullable: true),
                    Cnpj = table.Column<string>(type: "TEXT", nullable: true),
                    UniqueCode = table.Column<string>(type: "TEXT", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TEXT", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 1, 30, 26, 815, DateTimeKind.Unspecified).AddTicks(1554), new TimeSpan(0, 0, 0, 0, 0))),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "TEXT", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 1, 30, 26, 815, DateTimeKind.Unspecified).AddTicks(1985), new TimeSpan(0, 0, 0, 0, 0)))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_beneficiaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_beneficiaries_addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AddressId = table.Column<int>(type: "INTEGER", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Cnpj = table.Column<string>(type: "TEXT", nullable: true),
                    UniqueCode = table.Column<string>(type: "TEXT", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TEXT", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 1, 30, 26, 793, DateTimeKind.Unspecified).AddTicks(588), new TimeSpan(0, 0, 0, 0, 0))),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "TEXT", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 1, 30, 26, 793, DateTimeKind.Unspecified).AddTicks(984), new TimeSpan(0, 0, 0, 0, 0)))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Supplier_addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "POSOrderItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DrugUniqueCode = table.Column<string>(type: "TEXT", nullable: true),
                    DrugId = table.Column<int>(type: "INTEGER", nullable: true),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    CustomerValue = table.Column<decimal>(type: "TEXT", nullable: false),
                    CostPrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    POSOrderId = table.Column<int>(type: "INTEGER", nullable: false),
                    POSOrderId1 = table.Column<int>(type: "INTEGER", nullable: true),
                    UniqueCode = table.Column<string>(type: "TEXT", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TEXT", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 1, 30, 26, 807, DateTimeKind.Unspecified).AddTicks(5318), new TimeSpan(0, 0, 0, 0, 0))),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "TEXT", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 1, 30, 26, 807, DateTimeKind.Unspecified).AddTicks(5779), new TimeSpan(0, 0, 0, 0, 0)))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_POSOrderItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_POSOrderItem_POSOrder_POSOrderId",
                        column: x => x.POSOrderId,
                        principalTable: "POSOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_POSOrderItem_POSOrder_POSOrderId1",
                        column: x => x.POSOrderId1,
                        principalTable: "POSOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_POSOrderItem_Products_DrugId",
                        column: x => x.DrugId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    UniqueCode = table.Column<string>(type: "TEXT", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TEXT", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 1, 30, 26, 815, DateTimeKind.Unspecified).AddTicks(8182), new TimeSpan(0, 0, 0, 0, 0))),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "TEXT", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 1, 30, 26, 815, DateTimeKind.Unspecified).AddTicks(8603), new TimeSpan(0, 0, 0, 0, 0)))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductCategory_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductCategory_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductMedia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MediaResourceId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    IsThumbnail = table.Column<bool>(type: "INTEGER", nullable: false),
                    UniqueCode = table.Column<string>(type: "TEXT", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TEXT", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 1, 30, 26, 817, DateTimeKind.Unspecified).AddTicks(2992), new TimeSpan(0, 0, 0, 0, 0))),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "TEXT", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 1, 30, 26, 817, DateTimeKind.Unspecified).AddTicks(3395), new TimeSpan(0, 0, 0, 0, 0)))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductMedia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductMedia_MediaResource_MediaResourceId",
                        column: x => x.MediaResourceId,
                        principalTable: "MediaResource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductMedia_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductPrice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Pricestartdate = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    EndCustomerDrugPrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    CostPrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    UniqueCode = table.Column<string>(type: "TEXT", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TEXT", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 1, 30, 26, 817, DateTimeKind.Unspecified).AddTicks(6469), new TimeSpan(0, 0, 0, 0, 0))),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "TEXT", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 1, 30, 26, 817, DateTimeKind.Unspecified).AddTicks(6874), new TimeSpan(0, 0, 0, 0, 0)))
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
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    StockEntryId = table.Column<int>(type: "INTEGER", nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    UniqueCode = table.Column<string>(type: "TEXT", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TEXT", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 1, 30, 26, 817, DateTimeKind.Unspecified).AddTicks(9372), new TimeSpan(0, 0, 0, 0, 0))),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "TEXT", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 1, 30, 26, 818, DateTimeKind.Unspecified).AddTicks(205), new TimeSpan(0, 0, 0, 0, 0)))
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
                name: "ProductSupplier",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    SupplierId = table.Column<int>(type: "INTEGER", nullable: false),
                    UniqueCode = table.Column<string>(type: "TEXT", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TEXT", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 1, 30, 26, 818, DateTimeKind.Unspecified).AddTicks(3431), new TimeSpan(0, 0, 0, 0, 0))),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "TEXT", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 1, 30, 26, 818, DateTimeKind.Unspecified).AddTicks(4051), new TimeSpan(0, 0, 0, 0, 0)))
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StockEntry",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NfNumber = table.Column<string>(type: "TEXT", nullable: true),
                    NfEmissionDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Totalcost = table.Column<decimal>(type: "TEXT", nullable: true),
                    SupplierId = table.Column<int>(type: "INTEGER", nullable: true),
                    UniqueCode = table.Column<string>(type: "TEXT", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TEXT", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 1, 30, 26, 792, DateTimeKind.Unspecified).AddTicks(6427), new TimeSpan(0, 0, 0, 0, 0))),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "TEXT", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 1, 30, 26, 792, DateTimeKind.Unspecified).AddTicks(6833), new TimeSpan(0, 0, 0, 0, 0)))
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
                name: "ProductStockEntry",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    StockEntryId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductMaturityDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    LotCode = table.Column<string>(type: "TEXT", nullable: true),
                    UniqueCode = table.Column<string>(type: "TEXT", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TEXT", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 1, 30, 26, 818, DateTimeKind.Unspecified).AddTicks(1555), new TimeSpan(0, 0, 0, 0, 0))),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "TEXT", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 1, 30, 26, 818, DateTimeKind.Unspecified).AddTicks(2153), new TimeSpan(0, 0, 0, 0, 0)))
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

            migrationBuilder.CreateIndex(
                name: "IX_beneficiaries_AddressId",
                table: "beneficiaries",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_POSOrderItem_DrugId",
                table: "POSOrderItem",
                column: "DrugId");

            migrationBuilder.CreateIndex(
                name: "IX_POSOrderItem_POSOrderId",
                table: "POSOrderItem",
                column: "POSOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_POSOrderItem_POSOrderId1",
                table: "POSOrderItem",
                column: "POSOrderId1");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategory_CategoryId",
                table: "ProductCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategory_ProductId",
                table: "ProductCategory",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductMedia_MediaResourceId",
                table: "ProductMedia",
                column: "MediaResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductMedia_ProductId",
                table: "ProductMedia",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPrice_ProductId",
                table: "ProductPrice",
                column: "ProductId");

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
                name: "beneficiaries");

            migrationBuilder.DropTable(
                name: "Billings");

            migrationBuilder.DropTable(
                name: "POSOrderItem");

            migrationBuilder.DropTable(
                name: "ProductCategory");

            migrationBuilder.DropTable(
                name: "ProductMedia");

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
                name: "POSOrder");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "MediaResource");

            migrationBuilder.DropTable(
                name: "StockEntry");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Supplier");

            migrationBuilder.DropTable(
                name: "addresses");
        }
    }
}
