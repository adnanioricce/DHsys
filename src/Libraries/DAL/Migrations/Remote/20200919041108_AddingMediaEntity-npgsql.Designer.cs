﻿// <auto-generated />
using System;
using DAL.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DAL.Migrations.Remote
{
    [DbContext(typeof(RemoteContext))]
    [Migration("20200919041108_AddingMediaEntity-npgsql")]
    partial class AddingMediaEntitynpgsql
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Core.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("AddressState")
                        .HasColumnType("text");

                    b.Property<string>("Addressnumber")
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTimeOffset(new DateTime(2020, 9, 19, 4, 11, 8, 374, DateTimeKind.Unspecified).AddTicks(8884), new TimeSpan(0, 0, 0, 0, 0)));

                    b.Property<string>("District")
                        .HasColumnType("text");

                    b.Property<string>("FirstAddressLine")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset>("LastUpdatedOn")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTimeOffset(new DateTime(2020, 9, 19, 4, 11, 8, 374, DateTimeKind.Unspecified).AddTicks(9231), new TimeSpan(0, 0, 0, 0, 0)));

                    b.Property<string>("SecondAddressLine")
                        .HasColumnType("text");

                    b.Property<string>("UniqueCode")
                        .HasColumnType("text");

                    b.Property<string>("Zipcode")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("addresses");
                });

            modelBuilder.Entity("Core.Entities.Catalog.DrugInformation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CounterIndication")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTimeOffset(new DateTime(2020, 9, 19, 4, 11, 8, 411, DateTimeKind.Unspecified).AddTicks(6906), new TimeSpan(0, 0, 0, 0, 0)));

                    b.Property<int?>("DrugId")
                        .HasColumnType("integer");

                    b.Property<string>("HowToUse")
                        .HasColumnType("text");

                    b.Property<string>("HowWorks")
                        .HasColumnType("text");

                    b.Property<string>("Indication")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset>("LastUpdatedOn")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTimeOffset(new DateTime(2020, 9, 19, 4, 11, 8, 411, DateTimeKind.Unspecified).AddTicks(7611), new TimeSpan(0, 0, 0, 0, 0)));

                    b.Property<int?>("MinimalAgeOfUse")
                        .HasColumnType("integer");

                    b.Property<string>("ProfessionalBule")
                        .HasColumnType("text");

                    b.Property<string>("Substances")
                        .HasColumnType("text");

                    b.Property<string>("TypeOfUse")
                        .HasColumnType("text");

                    b.Property<string>("UniqueCode")
                        .HasColumnType("text");

                    b.Property<string>("UserBule")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("DrugId");

                    b.ToTable("DrugInformation");
                });

            modelBuilder.Entity("Core.Entities.Catalog.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("BarCode")
                        .HasColumnType("text");

                    b.Property<string>("Commission")
                        .HasColumnType("text");

                    b.Property<decimal>("CostPrice")
                        .HasColumnType("numeric");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTimeOffset(new DateTime(2020, 9, 19, 4, 11, 8, 414, DateTimeKind.Unspecified).AddTicks(4659), new TimeSpan(0, 0, 0, 0, 0)));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<decimal>("DiscountValue")
                        .HasColumnType("numeric");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal?>("EndCustomerPrice")
                        .HasColumnType("numeric");

                    b.Property<decimal>("ICMS")
                        .HasColumnType("numeric");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset>("LastUpdatedOn")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTimeOffset(new DateTime(2020, 9, 19, 4, 11, 8, 414, DateTimeKind.Unspecified).AddTicks(5634), new TimeSpan(0, 0, 0, 0, 0)));

                    b.Property<string>("MainSupplierName")
                        .HasColumnType("text");

                    b.Property<decimal>("MaxDiscountPercentage")
                        .HasColumnType("numeric");

                    b.Property<int>("MinimumStock")
                        .HasColumnType("integer");

                    b.Property<string>("Ncm")
                        .HasColumnType("text");

                    b.Property<string>("ProdutoId")
                        .HasColumnType("text");

                    b.Property<int?>("QuantityInStock")
                        .HasColumnType("integer");

                    b.Property<int?>("ReorderLevel")
                        .HasColumnType("integer");

                    b.Property<int?>("ReorderQuantity")
                        .HasColumnType("integer");

                    b.Property<decimal>("SavingPercentage")
                        .HasColumnType("numeric");

                    b.Property<string>("Section")
                        .HasColumnType("text");

                    b.Property<string>("UniqueCode")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Product");
                });

            modelBuilder.Entity("Core.Entities.Catalog.ProductPrice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<decimal>("CostPrice")
                        .HasColumnType("numeric");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTimeOffset(new DateTime(2020, 9, 19, 4, 11, 8, 415, DateTimeKind.Unspecified).AddTicks(3057), new TimeSpan(0, 0, 0, 0, 0)));

                    b.Property<decimal>("EndCustomerDrugPrice")
                        .HasColumnType("numeric");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset>("LastUpdatedOn")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTimeOffset(new DateTime(2020, 9, 19, 4, 11, 8, 415, DateTimeKind.Unspecified).AddTicks(3912), new TimeSpan(0, 0, 0, 0, 0)));

                    b.Property<DateTimeOffset?>("Pricestartdate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.Property<string>("UniqueCode")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductPrice");
                });

            modelBuilder.Entity("Core.Entities.Catalog.ProductShelfLife", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTimeOffset>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTimeOffset(new DateTime(2020, 9, 19, 4, 11, 8, 416, DateTimeKind.Unspecified).AddTicks(1158), new TimeSpan(0, 0, 0, 0, 0)));

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset>("LastUpdatedOn")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTimeOffset(new DateTime(2020, 9, 19, 4, 11, 8, 416, DateTimeKind.Unspecified).AddTicks(1761), new TimeSpan(0, 0, 0, 0, 0)));

                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("StockEntryId")
                        .HasColumnType("integer");

                    b.Property<string>("UniqueCode")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductShelfLife");
                });

            modelBuilder.Entity("Core.Entities.Catalog.ProductStockEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTimeOffset>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTimeOffset(new DateTime(2020, 9, 19, 4, 11, 8, 416, DateTimeKind.Unspecified).AddTicks(9222), new TimeSpan(0, 0, 0, 0, 0)));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset>("LastUpdatedOn")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTimeOffset(new DateTime(2020, 9, 19, 4, 11, 8, 416, DateTimeKind.Unspecified).AddTicks(9873), new TimeSpan(0, 0, 0, 0, 0)));

                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.Property<int>("StockEntryId")
                        .HasColumnType("integer");

                    b.Property<string>("UniqueCode")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("StockEntryId");

                    b.ToTable("ProductStockEntry");
                });

            modelBuilder.Entity("Core.Entities.Catalog.ProductSupplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTimeOffset>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTimeOffset(new DateTime(2020, 9, 19, 4, 11, 8, 417, DateTimeKind.Unspecified).AddTicks(8214), new TimeSpan(0, 0, 0, 0, 0)));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset>("LastUpdatedOn")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTimeOffset(new DateTime(2020, 9, 19, 4, 11, 8, 417, DateTimeKind.Unspecified).AddTicks(8789), new TimeSpan(0, 0, 0, 0, 0)));

                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.Property<int>("SupplierId")
                        .HasColumnType("integer");

                    b.Property<string>("UniqueCode")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("SupplierId");

                    b.ToTable("ProductSupplier");
                });

            modelBuilder.Entity("Core.Entities.Financial.Beneficiary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AddressId")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTimeOffset(new DateTime(2020, 9, 19, 4, 11, 8, 409, DateTimeKind.Unspecified).AddTicks(7622), new TimeSpan(0, 0, 0, 0, 0)));

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset>("LastUpdatedOn")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTimeOffset(new DateTime(2020, 9, 19, 4, 11, 8, 409, DateTimeKind.Unspecified).AddTicks(8324), new TimeSpan(0, 0, 0, 0, 0)));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("UniqueCode")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("beneficiaries");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Beneficiary");
                });

            modelBuilder.Entity("Core.Entities.Financial.Billing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("BeneficiaryId")
                        .HasColumnType("integer");

                    b.Property<string>("BeneficiaryName")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTimeOffset(new DateTime(2020, 9, 19, 4, 11, 8, 371, DateTimeKind.Unspecified).AddTicks(2154), new TimeSpan(0, 0, 0, 0, 0)));

                    b.Property<decimal?>("Discount")
                        .HasColumnType("numeric");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsPaid")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset>("LastUpdatedOn")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTimeOffset(new DateTime(2020, 9, 19, 4, 11, 8, 371, DateTimeKind.Unspecified).AddTicks(2733), new TimeSpan(0, 0, 0, 0, 0)));

                    b.Property<int>("PersonType")
                        .HasColumnType("integer");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<string>("UniqueCode")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Billings");
                });

            modelBuilder.Entity("Core.Entities.Financial.POSOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTimeOffset>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTimeOffset(new DateTime(2020, 9, 19, 4, 11, 8, 348, DateTimeKind.Unspecified).AddTicks(9504), new TimeSpan(0, 0, 0, 0, 0)));

                    b.Property<bool>("HasDealWithStore")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset>("LastUpdatedOn")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTimeOffset(new DateTime(2020, 9, 19, 4, 11, 8, 348, DateTimeKind.Unspecified).AddTicks(9983), new TimeSpan(0, 0, 0, 0, 0)));

                    b.Property<int>("PaymentMethod")
                        .HasColumnType("integer");

                    b.Property<decimal>("OrderTotal")
                        .HasColumnType("numeric");

                    b.Property<string>("UniqueCode")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("POSOrder");
                });

            modelBuilder.Entity("Core.Entities.Financial.POSOrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<decimal>("CostPrice")
                        .HasColumnType("numeric");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTimeOffset(new DateTime(2020, 9, 19, 4, 11, 8, 359, DateTimeKind.Unspecified).AddTicks(9697), new TimeSpan(0, 0, 0, 0, 0)));

                    b.Property<decimal>("CustomerValue")
                        .HasColumnType("numeric");

                    b.Property<int?>("DrugId")
                        .HasColumnType("integer");

                    b.Property<string>("DrugUniqueCode")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset>("LastUpdatedOn")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTimeOffset(new DateTime(2020, 9, 19, 4, 11, 8, 360, DateTimeKind.Unspecified).AddTicks(280), new TimeSpan(0, 0, 0, 0, 0)));

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<int>("POSOrderId")
                        .HasColumnType("integer");

                    b.Property<string>("UniqueCode")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("DrugId");

                    b.HasIndex("POSOrderId");

                    b.ToTable("POSOrderItem");
                });

            modelBuilder.Entity("Core.Entities.Media.MediaResource", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Caption")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTimeOffset(new DateTime(2020, 9, 19, 4, 11, 8, 364, DateTimeKind.Unspecified).AddTicks(9612), new TimeSpan(0, 0, 0, 0, 0)));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset>("LastUpdatedOn")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTimeOffset(new DateTime(2020, 9, 19, 4, 11, 8, 365, DateTimeKind.Unspecified).AddTicks(45), new TimeSpan(0, 0, 0, 0, 0)));

                    b.Property<long>("Size")
                        .HasColumnType("bigint");

                    b.Property<string>("SourceUrl")
                        .HasColumnType("text");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.Property<string>("UniqueCode")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("MediaResource");
                });

            modelBuilder.Entity("Core.Entities.Stock.StockEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTimeOffset>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTimeOffset(new DateTime(2020, 9, 19, 4, 11, 8, 320, DateTimeKind.Unspecified).AddTicks(6790), new TimeSpan(0, 0, 0, 0, 0)));

                    b.Property<DateTime?>("DrugMaturityDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset>("LastUpdatedOn")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTimeOffset(new DateTime(2020, 9, 19, 4, 11, 8, 320, DateTimeKind.Unspecified).AddTicks(7513), new TimeSpan(0, 0, 0, 0, 0)));

                    b.Property<string>("LotCode")
                        .HasColumnType("text");

                    b.Property<DateTime?>("NfEmissionDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("NfNumber")
                        .HasColumnType("text");

                    b.Property<int?>("Quantity")
                        .HasColumnType("integer");

                    b.Property<int?>("SupplierId")
                        .HasColumnType("integer");

                    b.Property<decimal?>("Totalcost")
                        .HasColumnType("numeric");

                    b.Property<string>("UniqueCode")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("SupplierId");

                    b.ToTable("StockEntry");
                });

            modelBuilder.Entity("Core.Entities.Stock.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("AddressId")
                        .HasColumnType("integer");

                    b.Property<string>("Cnpj")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTimeOffset(new DateTime(2020, 9, 19, 4, 11, 8, 321, DateTimeKind.Unspecified).AddTicks(4207), new TimeSpan(0, 0, 0, 0, 0)));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset>("LastUpdatedOn")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTimeOffset(new DateTime(2020, 9, 19, 4, 11, 8, 321, DateTimeKind.Unspecified).AddTicks(4677), new TimeSpan(0, 0, 0, 0, 0)));

                    b.Property<string>("SupplierName")
                        .HasColumnType("text");

                    b.Property<string>("UniqueCode")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Supplier");
                });

            modelBuilder.Entity("Core.Entities.Sync.Syncronization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTimeOffset>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTimeOffset(new DateTime(2020, 9, 19, 4, 11, 8, 23, DateTimeKind.Unspecified).AddTicks(7503), new TimeSpan(0, 0, 0, 0, 0)));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset>("LastSyncronization")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("LastUpdatedOn")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTimeOffset(new DateTime(2020, 9, 19, 4, 11, 8, 30, DateTimeKind.Unspecified).AddTicks(5500), new TimeSpan(0, 0, 0, 0, 0)));

                    b.Property<string>("UniqueCode")
                        .HasColumnType("text");

                    b.Property<string>("UpdatedFrom")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Syncronization");
                });

            modelBuilder.Entity("Core.Entities.Catalog.Drug", b =>
                {
                    b.HasBaseType("Core.Entities.Catalog.Product");

                    b.Property<double?>("AbsoluteDosageInMg")
                        .HasColumnType("double precision");

                    b.Property<string>("ActivePrinciple")
                        .HasColumnType("text");

                    b.Property<int?>("BaseDrugId")
                        .HasColumnType("integer");

                    b.Property<string>("Classification")
                        .HasColumnType("text");

                    b.Property<string>("CommercialName")
                        .HasColumnType("text");

                    b.Property<string>("DigitalBuleLink")
                        .HasColumnType("text");

                    b.Property<string>("Dosage")
                        .HasColumnType("text");

                    b.Property<decimal?>("DrugCost")
                        .HasColumnType("numeric");

                    b.Property<string>("DrugName")
                        .HasColumnType("text");

                    b.Property<bool>("IsPriceFixed")
                        .HasColumnType("boolean");

                    b.Property<string>("LotNumber")
                        .HasColumnType("text");

                    b.Property<int?>("ManufacturerId")
                        .HasColumnType("integer");

                    b.Property<string>("ManufacturerName")
                        .HasColumnType("text");

                    b.Property<string>("PrCdse")
                        .HasColumnType("text");

                    b.Property<bool>("PrescriptionNeeded")
                        .HasColumnType("boolean");

                    b.Property<int?>("StockEntryId")
                        .HasColumnType("integer");

                    b.Property<int?>("SupplierId")
                        .HasColumnType("integer");

                    b.HasIndex("StockEntryId");

                    b.HasDiscriminator().HasValue("Drug");
                });

            modelBuilder.Entity("Core.Entities.Client", b =>
                {
                    b.HasBaseType("Core.Entities.Financial.Beneficiary");

                    b.Property<string>("Cpf")
                        .HasColumnType("character varying(12)")
                        .HasMaxLength(12);

                    b.HasIndex("AddressId");

                    b.HasDiscriminator().HasValue("Client");
                });

            modelBuilder.Entity("Core.Entities.Stock.Manufacturer", b =>
                {
                    b.HasBaseType("Core.Entities.Financial.Beneficiary");

                    b.Property<string>("Cnpj")
                        .HasColumnType("text");

                    b.HasIndex("AddressId")
                        .HasName("IX_beneficiaries_AddressId1");

                    b.HasDiscriminator().HasValue("Manufacturer");
                });

            modelBuilder.Entity("Core.Entities.Catalog.DrugInformation", b =>
                {
                    b.HasOne("Core.Entities.Catalog.Drug", "Drug")
                        .WithMany("Druginformation")
                        .HasForeignKey("DrugId");
                });

            modelBuilder.Entity("Core.Entities.Catalog.ProductPrice", b =>
                {
                    b.HasOne("Core.Entities.Catalog.Product", "Product")
                        .WithMany("ProductPrices")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Entities.Catalog.ProductShelfLife", b =>
                {
                    b.HasOne("Core.Entities.Catalog.Product", null)
                        .WithMany("ShelfLifes")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Entities.Catalog.ProductStockEntry", b =>
                {
                    b.HasOne("Core.Entities.Catalog.Product", "Product")
                        .WithMany("Stockentries")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Stock.StockEntry", "StockEntry")
                        .WithMany()
                        .HasForeignKey("StockEntryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Entities.Catalog.ProductSupplier", b =>
                {
                    b.HasOne("Core.Entities.Catalog.Product", "Product")
                        .WithMany("ProductSuppliers")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Core.Entities.Stock.Supplier", "Supplier")
                        .WithMany("Products")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Entities.Financial.POSOrderItem", b =>
                {
                    b.HasOne("Core.Entities.Catalog.Drug", "Drug")
                        .WithMany()
                        .HasForeignKey("DrugId");

                    b.HasOne("Core.Entities.Financial.POSOrder", null)
                        .WithMany("Items")
                        .HasForeignKey("POSOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Entities.Stock.StockEntry", b =>
                {
                    b.HasOne("Core.Entities.Stock.Supplier", "Supplier")
                        .WithMany("Stockentries")
                        .HasForeignKey("SupplierId");
                });

            modelBuilder.Entity("Core.Entities.Stock.Supplier", b =>
                {
                    b.HasOne("Core.Entities.Address", "Address")
                        .WithMany("Suppliers")
                        .HasForeignKey("AddressId");
                });

            modelBuilder.Entity("Core.Entities.Catalog.Drug", b =>
                {
                    b.HasOne("Core.Entities.Stock.StockEntry", null)
                        .WithMany("Drugs")
                        .HasForeignKey("StockEntryId");
                });

            modelBuilder.Entity("Core.Entities.Client", b =>
                {
                    b.HasOne("Core.Entities.Address", "Address")
                        .WithMany("Clients")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Entities.Stock.Manufacturer", b =>
                {
                    b.HasOne("Core.Entities.Address", "Address")
                        .WithMany("Manufacturer")
                        .HasForeignKey("AddressId")
                        .HasConstraintName("FK_beneficiaries_addresses_AddressId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
