using System;
using Core.Entities.Stock;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DAL.Migrations
{
    public partial class BaseCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstAddressLine = table.Column<string>(type: "text", nullable: true),
                    SecondAddressLine = table.Column<string>(type: "text", nullable: true),
                    Zipcode = table.Column<string>(type: "text", nullable: true),
                    Addressnumber = table.Column<string>(type: "text", nullable: true),
                    City = table.Column<string>(type: "text", nullable: true),
                    AddressState = table.Column<string>(type: "text", nullable: true),
                    District = table.Column<string>(type: "text", nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 20, 59, 45, 321, DateTimeKind.Unspecified).AddTicks(361), new TimeSpan(0, 0, 0, 0, 0))),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 20, 59, 45, 321, DateTimeKind.Unspecified).AddTicks(1222), new TimeSpan(0, 0, 0, 0, 0)))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Billings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BeneficiaryId = table.Column<int>(type: "integer", nullable: false),
                    BeneficiaryName = table.Column<string>(type: "text", nullable: true),
                    PersonType = table.Column<int>(type: "integer", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Discount = table.Column<decimal>(type: "numeric", nullable: true),
                    IsPaid = table.Column<bool>(type: "boolean", nullable: false),
                    UniqueCode = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 20, 59, 45, 316, DateTimeKind.Unspecified).AddTicks(9215), new TimeSpan(0, 0, 0, 0, 0))),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 20, 59, 45, 316, DateTimeKind.Unspecified).AddTicks(9773), new TimeSpan(0, 0, 0, 0, 0)))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Billings", x => x.Id);
                });

            
            
            migrationBuilder.CreateTable(
                name: "MediaResource",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Size = table.Column<long>(type: "bigint", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    SourceUrl = table.Column<string>(type: "text", nullable: true),
                    Caption = table.Column<string>(type: "text", nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 20, 59, 45, 312, DateTimeKind.Unspecified).AddTicks(7304), new TimeSpan(0, 0, 0, 0, 0))),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 20, 59, 45, 312, DateTimeKind.Unspecified).AddTicks(7744), new TimeSpan(0, 0, 0, 0, 0)))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaResource", x => x.Id);
                });
            
            migrationBuilder.CreateTable(
                name: "POSOrder",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DiscountTotal = table.Column<decimal>(type: "numeric", nullable: false),
                    PaymentMethod = table.Column<int>(type: "integer", nullable: false),
                    HasDealWithStore = table.Column<bool>(type: "boolean", nullable: false),
                    ConsumerCode = table.Column<string>(type: "text", nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 20, 59, 45, 308, DateTimeKind.Unspecified).AddTicks(1849), new TimeSpan(0, 0, 0, 0, 0))),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 20, 59, 45, 308, DateTimeKind.Unspecified).AddTicks(2392), new TimeSpan(0, 0, 0, 0, 0)))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_POSOrder", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BaseProductId = table.Column<int>(type: "integer", nullable: true),
                    PrCdse = table.Column<string>(type: "text", nullable: true),
                    ManufacturerId = table.Column<int>(type: "integer", nullable: true),
                    ManufacturerName = table.Column<string>(type: "text", nullable: true),
                    CommercialName = table.Column<string>(type: "text", nullable: true),
                    Classification = table.Column<string>(type: "text", nullable: true),
                    Dosage = table.Column<string>(type: "text", nullable: true),
                    AbsoluteDosageInMg = table.Column<double>(type: "double precision", nullable: true),
                    ActivePrinciple = table.Column<string>(type: "text", nullable: true),
                    LotNumber = table.Column<string>(type: "text", nullable: true),                    
                    PrescriptionNeeded = table.Column<bool>(type: "boolean", nullable: false),
                    IsPriceFixed = table.Column<bool>(type: "boolean", nullable: false),
                    DigitalBuleLink = table.Column<string>(type: "text", nullable: true),
                    LaboratoryCode = table.Column<string>(type: "text", nullable: true),
                    LaboratoryName = table.Column<string>(type: "text", nullable: true),
                    Ncm = table.Column<string>(type: "text", nullable: true),
                    QuantityInStock = table.Column<int>(type: "integer", nullable: false),
                    LastStockEntry = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable:true),
                    ReorderLevel = table.Column<int>(type: "integer", nullable: false),
                    ReorderQuantity = table.Column<int>(type: "integer", nullable: false),
                    EndCustomerPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    CostPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    SavingPercentage = table.Column<decimal>(type: "numeric", nullable: false),
                    BarCode = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Section = table.Column<string>(type: "text", nullable: true),
                    MaxDiscountPercentage = table.Column<decimal>(type: "numeric", nullable: false),
                    DiscountValue = table.Column<decimal>(type: "numeric", nullable: false),
                    Commission = table.Column<string>(type: "text", nullable: true),
                    ICMS = table.Column<decimal>(type: "numeric", nullable: false),
                    MinimumStock = table.Column<int>(type: "integer", nullable: false),
                    MainSupplierName = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    RegistryCode = table.Column<string>(type: "text", nullable: true),
                    OwnerOfRegistry = table.Column<string>(type: "text", nullable: true),

                    UniqueCode = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 20, 59, 45, 403, DateTimeKind.Unspecified).AddTicks(7721), new TimeSpan(0, 0, 0, 0, 0))),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 20, 59, 45, 403, DateTimeKind.Unspecified).AddTicks(8282), new TimeSpan(0, 0, 0, 0, 0)))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Syncronization",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UpdatedFrom = table.Column<string>(type: "text", nullable: true),
                    LastSyncronization = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UniqueCode = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 20, 59, 45, 34, DateTimeKind.Unspecified).AddTicks(8729), new TimeSpan(0, 0, 0, 0, 0))),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 20, 59, 45, 46, DateTimeKind.Unspecified).AddTicks(7753), new TimeSpan(0, 0, 0, 0, 0)))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Syncronization", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "beneficiaries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    AddressId = table.Column<int>(type: "integer", nullable: false),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    Cpf = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: true),
                    Cnpj = table.Column<string>(type: "text", nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 20, 59, 45, 390, DateTimeKind.Unspecified).AddTicks(6614), new TimeSpan(0, 0, 0, 0, 0))),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 20, 59, 45, 390, DateTimeKind.Unspecified).AddTicks(7265), new TimeSpan(0, 0, 0, 0, 0)))
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AddressId = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Cnpj = table.Column<string>(type: "text", nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 20, 59, 45, 298, DateTimeKind.Unspecified).AddTicks(6886), new TimeSpan(0, 0, 0, 0, 0))),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 20, 59, 45, 298, DateTimeKind.Unspecified).AddTicks(7593), new TimeSpan(0, 0, 0, 0, 0)))
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductUniqueCode = table.Column<string>(type: "text", nullable: true),
                    ProductId = table.Column<int>(type: "integer", nullable: true),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    CustomerValue = table.Column<decimal>(type: "numeric", nullable: false),
                    CostPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    POSOrderId = table.Column<int>(type: "integer", nullable: false),
                    POSOrderId1 = table.Column<int>(type: "integer", nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 20, 59, 45, 312, DateTimeKind.Unspecified).AddTicks(2609), new TimeSpan(0, 0, 0, 0, 0))),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 20, 59, 45, 312, DateTimeKind.Unspecified).AddTicks(3195), new TimeSpan(0, 0, 0, 0, 0)))
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
                        name: "FK_POSOrderItem_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    ShowOnHomepage = table.Column<bool>(type: "boolean", nullable: false),
                    ParentId = table.Column<int>(type: "integer", nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 20, 59, 45, 391, DateTimeKind.Unspecified).AddTicks(2940), new TimeSpan(0, 0, 0, 0, 0))),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 20, 59, 45, 391, DateTimeKind.Unspecified).AddTicks(3417), new TimeSpan(0, 0, 0, 0, 0)))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category_Category_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Category",
                        principalColumn: "Id",                        
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    UniqueCode = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 20, 59, 45, 392, DateTimeKind.Unspecified).AddTicks(4314), new TimeSpan(0, 0, 0, 0, 0))),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 20, 59, 45, 392, DateTimeKind.Unspecified).AddTicks(4846), new TimeSpan(0, 0, 0, 0, 0)))
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MediaResourceId = table.Column<int>(type: "integer", nullable: false),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    IsThumbnail = table.Column<bool>(type: "boolean", nullable: false),
                    UniqueCode = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 20, 59, 45, 405, DateTimeKind.Unspecified).AddTicks(807), new TimeSpan(0, 0, 0, 0, 0))),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 20, 59, 45, 405, DateTimeKind.Unspecified).AddTicks(1384), new TimeSpan(0, 0, 0, 0, 0)))
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Pricestartdate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    EndCustomerDrugPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    CostPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    UniqueCode = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 20, 59, 45, 406, DateTimeKind.Unspecified).AddTicks(106), new TimeSpan(0, 0, 0, 0, 0))),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 20, 59, 45, 406, DateTimeKind.Unspecified).AddTicks(597), new TimeSpan(0, 0, 0, 0, 0)))
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    StockEntryId = table.Column<int>(type: "integer", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    EndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 20, 59, 45, 406, DateTimeKind.Unspecified).AddTicks(5228), new TimeSpan(0, 0, 0, 0, 0))),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 20, 59, 45, 406, DateTimeKind.Unspecified).AddTicks(5724), new TimeSpan(0, 0, 0, 0, 0)))
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    SupplierId = table.Column<int>(type: "integer", nullable: false),
                    UniqueCode = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 20, 59, 45, 407, DateTimeKind.Unspecified).AddTicks(9443), new TimeSpan(0, 0, 0, 0, 0))),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 20, 59, 45, 407, DateTimeKind.Unspecified).AddTicks(9953), new TimeSpan(0, 0, 0, 0, 0)))
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NfNumber = table.Column<string>(type: "text", nullable: true),
                    NfEmissionDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Totalcost = table.Column<decimal>(type: "numeric", nullable: true),
                    SupplierId = table.Column<int>(type: "integer", nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 20, 59, 45, 291, DateTimeKind.Unspecified).AddTicks(6221), new TimeSpan(0, 0, 0, 0, 0))),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 20, 59, 45, 291, DateTimeKind.Unspecified).AddTicks(6910), new TimeSpan(0, 0, 0, 0, 0)))
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    StockEntryId = table.Column<int>(type: "integer", nullable: false),
                    ProductMaturityDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    LotCode = table.Column<string>(type: "text", nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 20, 59, 45, 407, DateTimeKind.Unspecified).AddTicks(645), new TimeSpan(0, 0, 0, 0, 0))),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 20, 59, 45, 407, DateTimeKind.Unspecified).AddTicks(1123), new TimeSpan(0, 0, 0, 0, 0)))
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
            migrationBuilder.CreateTable("StockChange", columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                             .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ImpactingEntityId = table.Column<int>(type: "integer",nullable:false),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Type = table.Column<int>(type: "integer",nullable:false),
                    Note = table.Column<string>(type: "text",nullable:true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 20, 59, 45, 407, DateTimeKind.Unspecified).AddTicks(645), new TimeSpan(0, 0, 0, 0, 0))),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 20, 59, 45, 407, DateTimeKind.Unspecified).AddTicks(1123), new TimeSpan(0, 0, 0, 0, 0)))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockChange", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockChange_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);

                });

            migrationBuilder.CreateIndex(
                name: "IX_beneficiaries_AddressId",
                table: "beneficiaries",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_POSOrderItem_POSOrderId",
                table: "POSOrderItem",
                column: "POSOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_POSOrderItem_POSOrderId1",
                table: "POSOrderItem",
                column: "POSOrderId1");

            migrationBuilder.CreateIndex(
                name: "IX_POSOrderItem_ProductId",
                table: "POSOrderItem",
                column: "ProductId");
            
            migrationBuilder.CreateIndex(
                name: "IX_Category_ParentId",
                table: "Category",
                column: "ParentId");

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
                name: "IX_StockChange_ProductId",
                table: "StockChange",
                column: "ProductId");

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
