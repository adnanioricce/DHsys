using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DAL.Migrations
{
    public partial class InitialCreateremote : Migration
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
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 1, 30, 26, 51, DateTimeKind.Unspecified).AddTicks(4238), new TimeSpan(0, 0, 0, 0, 0))),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 1, 30, 26, 51, DateTimeKind.Unspecified).AddTicks(4734), new TimeSpan(0, 0, 0, 0, 0)))
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
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 1, 30, 26, 47, DateTimeKind.Unspecified).AddTicks(9581), new TimeSpan(0, 0, 0, 0, 0))),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 1, 30, 26, 48, DateTimeKind.Unspecified).AddTicks(124), new TimeSpan(0, 0, 0, 0, 0)))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Billings", x => x.Id);
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
                    UniqueCode = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 1, 30, 26, 78, DateTimeKind.Unspecified).AddTicks(9453), new TimeSpan(0, 0, 0, 0, 0))),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 1, 30, 26, 78, DateTimeKind.Unspecified).AddTicks(9920), new TimeSpan(0, 0, 0, 0, 0)))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
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
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 1, 30, 26, 43, DateTimeKind.Unspecified).AddTicks(8191), new TimeSpan(0, 0, 0, 0, 0))),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 1, 30, 26, 43, DateTimeKind.Unspecified).AddTicks(8879), new TimeSpan(0, 0, 0, 0, 0)))
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
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 1, 30, 26, 39, DateTimeKind.Unspecified).AddTicks(312), new TimeSpan(0, 0, 0, 0, 0))),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 1, 30, 26, 39, DateTimeKind.Unspecified).AddTicks(959), new TimeSpan(0, 0, 0, 0, 0)))
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
                    Ncm = table.Column<string>(type: "text", nullable: true),
                    QuantityInStock = table.Column<int>(type: "integer", nullable: true),
                    ReorderLevel = table.Column<int>(type: "integer", nullable: true),
                    ReorderQuantity = table.Column<int>(type: "integer", nullable: true),
                    EndCustomerPrice = table.Column<decimal>(type: "numeric", nullable: true),
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
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    BaseDrugId = table.Column<int>(type: "integer", nullable: true),
                    PrCdse = table.Column<string>(type: "text", nullable: true),
                    ManufacturerId = table.Column<int>(type: "integer", nullable: true),
                    ManufacturerName = table.Column<string>(type: "text", nullable: true),
                    CommercialName = table.Column<string>(type: "text", nullable: true),
                    Classification = table.Column<string>(type: "text", nullable: true),
                    Dosage = table.Column<string>(type: "text", nullable: true),
                    AbsoluteDosageInMg = table.Column<double>(type: "double precision", nullable: true),
                    ActivePrinciple = table.Column<string>(type: "text", nullable: true),
                    LotNumber = table.Column<string>(type: "text", nullable: true),
                    PrescriptionNeeded = table.Column<bool>(type: "boolean", nullable: true),
                    IsPriceFixed = table.Column<bool>(type: "boolean", nullable: true),
                    DigitalBuleLink = table.Column<string>(type: "text", nullable: true),
                    LaboratoryCode = table.Column<string>(type: "text", nullable: true),
                    LaboratoryName = table.Column<string>(type: "text", nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 1, 30, 26, 87, DateTimeKind.Unspecified).AddTicks(40), new TimeSpan(0, 0, 0, 0, 0))),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 1, 30, 26, 87, DateTimeKind.Unspecified).AddTicks(491), new TimeSpan(0, 0, 0, 0, 0)))
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
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 1, 30, 25, 721, DateTimeKind.Unspecified).AddTicks(5224), new TimeSpan(0, 0, 0, 0, 0))),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 1, 30, 25, 733, DateTimeKind.Unspecified).AddTicks(1230), new TimeSpan(0, 0, 0, 0, 0)))
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
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 1, 30, 26, 78, DateTimeKind.Unspecified).AddTicks(3468), new TimeSpan(0, 0, 0, 0, 0))),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 1, 30, 26, 78, DateTimeKind.Unspecified).AddTicks(3988), new TimeSpan(0, 0, 0, 0, 0)))
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
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 1, 30, 25, 975, DateTimeKind.Unspecified).AddTicks(2184), new TimeSpan(0, 0, 0, 0, 0))),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 1, 30, 25, 975, DateTimeKind.Unspecified).AddTicks(2946), new TimeSpan(0, 0, 0, 0, 0)))
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
                    DrugUniqueCode = table.Column<string>(type: "text", nullable: true),
                    DrugId = table.Column<int>(type: "integer", nullable: true),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    CustomerValue = table.Column<decimal>(type: "numeric", nullable: false),
                    CostPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    POSOrderId = table.Column<int>(type: "integer", nullable: false),
                    POSOrderId1 = table.Column<int>(type: "integer", nullable: true),
                    UniqueCode = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 1, 30, 26, 43, DateTimeKind.Unspecified).AddTicks(3503), new TimeSpan(0, 0, 0, 0, 0))),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 1, 30, 26, 43, DateTimeKind.Unspecified).AddTicks(4149), new TimeSpan(0, 0, 0, 0, 0)))
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    UniqueCode = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 1, 30, 26, 80, DateTimeKind.Unspecified).AddTicks(6383), new TimeSpan(0, 0, 0, 0, 0))),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 1, 30, 26, 80, DateTimeKind.Unspecified).AddTicks(6945), new TimeSpan(0, 0, 0, 0, 0)))
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
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 1, 30, 26, 88, DateTimeKind.Unspecified).AddTicks(3648), new TimeSpan(0, 0, 0, 0, 0))),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 1, 30, 26, 88, DateTimeKind.Unspecified).AddTicks(5284), new TimeSpan(0, 0, 0, 0, 0)))
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
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 1, 30, 26, 89, DateTimeKind.Unspecified).AddTicks(9856), new TimeSpan(0, 0, 0, 0, 0))),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 1, 30, 26, 90, DateTimeKind.Unspecified).AddTicks(562), new TimeSpan(0, 0, 0, 0, 0)))
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
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 1, 30, 26, 90, DateTimeKind.Unspecified).AddTicks(9867), new TimeSpan(0, 0, 0, 0, 0))),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 1, 30, 26, 91, DateTimeKind.Unspecified).AddTicks(597), new TimeSpan(0, 0, 0, 0, 0)))
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
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 1, 30, 26, 92, DateTimeKind.Unspecified).AddTicks(6536), new TimeSpan(0, 0, 0, 0, 0))),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 1, 30, 26, 92, DateTimeKind.Unspecified).AddTicks(7268), new TimeSpan(0, 0, 0, 0, 0)))
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
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 1, 30, 25, 968, DateTimeKind.Unspecified).AddTicks(5320), new TimeSpan(0, 0, 0, 0, 0))),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 1, 30, 25, 968, DateTimeKind.Unspecified).AddTicks(5857), new TimeSpan(0, 0, 0, 0, 0)))
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
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 1, 30, 26, 91, DateTimeKind.Unspecified).AddTicks(6715), new TimeSpan(0, 0, 0, 0, 0))),
                    LastUpdatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2020, 12, 9, 1, 30, 26, 91, DateTimeKind.Unspecified).AddTicks(7289), new TimeSpan(0, 0, 0, 0, 0)))
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
