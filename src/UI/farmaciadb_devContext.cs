// using System;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Metadata;

// namespace UI
// {
//     public partial class farmaciadb_devContext : DbContext
//     {
//         public farmaciadb_devContext()
//         {
//         }

//         public farmaciadb_devContext(DbContextOptions<farmaciadb_devContext> options)
//             : base(options)
//         {
//         }

//         public virtual DbSet<Addresses> Addresses { get; set; }
//         public virtual DbSet<Billings> Billings { get; set; }
//         public virtual DbSet<Clients> Clients { get; set; }
//         public virtual DbSet<Druginformation> Druginformation { get; set; }
//         public virtual DbSet<Drugprices> Drugprices { get; set; }
//         public virtual DbSet<Drugs> Drugs { get; set; }
//         public virtual DbSet<Manufacturer> Manufacturer { get; set; }
//         public virtual DbSet<Stockentries> Stockentries { get; set; }
//         public virtual DbSet<Suppliers> Suppliers { get; set; }

//         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//         {
//             if (!optionsBuilder.IsConfigured)
//             {
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                 optionsBuilder.UseNpgsql("User ID=postgres;Password=asdf1234;Host=localhost;Port=5432;Database=farmaciadb_dev;Pooling=true;");
//             }
//         }

//         protected override void OnModelCreating(ModelBuilder modelBuilder)
//         {
//             modelBuilder.Entity<Addresses>(entity =>
//             {
//                 entity.HasKey(e => e.AddressId)
//                     .HasName("addresses_pkey");

//                 entity.ToTable("addresses");

//                 entity.Property(e => e.AddressId).HasColumnName("address_id");

//                 entity.Property(e => e.AddressState)
//                     .HasColumnName("address_state")
//                     .HasMaxLength(32);

//                 entity.Property(e => e.Addressnumber)
//                     .HasColumnName("addressnumber")
//                     .HasMaxLength(16);

//                 entity.Property(e => e.City)
//                     .HasColumnName("city")
//                     .HasMaxLength(64);

//                 entity.Property(e => e.District)
//                     .HasColumnName("district")
//                     .HasMaxLength(64);

//                 entity.Property(e => e.FirstAddressLine)
//                     .HasColumnName("first_address_line")
//                     .HasMaxLength(128);

//                 entity.Property(e => e.SecondAddressLine)
//                     .HasColumnName("second_address_line")
//                     .HasMaxLength(128);

//                 entity.Property(e => e.Zipcode)
//                     .HasColumnName("zipcode")
//                     .HasMaxLength(12);
//             });

//             modelBuilder.Entity<Billings>(entity =>
//             {
//                 entity.HasKey(e => e.BillingId)
//                     .HasName("billings_pkey");

//                 entity.ToTable("billings");

//                 entity.Property(e => e.BillingId)
//                     .HasColumnName("billing_id")
//                     .ValueGeneratedNever();

//                 entity.Property(e => e.Beneficiary)
//                     .HasColumnName("beneficiary")
//                     .HasMaxLength(128);

//                 entity.Property(e => e.EndDate)
//                     .HasColumnName("end_date")
//                     .HasColumnType("date");

//                 entity.Property(e => e.IsPaid).HasColumnName("is_paid");

//                 entity.Property(e => e.Price)
//                     .HasColumnName("price")
//                     .HasColumnType("numeric(10,2)");
//             });

//             modelBuilder.Entity<Clients>(entity =>
//             {
//                 entity.HasKey(e => e.ClientId)
//                     .HasName("clients_pkey");

//                 entity.ToTable("clients");

//                 entity.Property(e => e.ClientId).HasColumnName("client_id");

//                 entity.Property(e => e.Addressid).HasColumnName("addressid");

//                 entity.Property(e => e.ClientName)
//                     .HasColumnName("client_name")
//                     .HasMaxLength(256);

//                 entity.Property(e => e.Cpf)
//                     .HasColumnName("cpf")
//                     .HasMaxLength(11);

//                 entity.HasOne(d => d.Address)
//                     .WithMany(p => p.Clients)
//                     .HasForeignKey(d => d.Addressid)
//                     .HasConstraintName("clients_addressid_fkey");
//             });

//             modelBuilder.Entity<Druginformation>(entity =>
//             {
//                 entity.ToTable("druginformation");

//                 entity.Property(e => e.DrugInformationId).HasColumnName("drug_information_id");

//                 entity.Property(e => e.CounterIndication)
//                     .HasColumnName("counter_indication")
//                     .HasMaxLength(640);

//                 entity.Property(e => e.DrugId).HasColumnName("drug_id");

//                 entity.Property(e => e.HowToUse)
//                     .HasColumnName("how_to_use")
//                     .HasMaxLength(640);

//                 entity.Property(e => e.HowWorks)
//                     .HasColumnName("how_works")
//                     .HasMaxLength(640);

//                 entity.Property(e => e.Indication)
//                     .HasColumnName("indication")
//                     .HasMaxLength(640);

//                 entity.Property(e => e.ProfessionalBule)
//                     .HasColumnName("professional_bule")
//                     .HasMaxLength(256);

//                 entity.Property(e => e.Substances)
//                     .HasColumnName("substances")
//                     .HasMaxLength(640);

//                 entity.Property(e => e.UserBule)
//                     .HasColumnName("user_bule")
//                     .HasMaxLength(256);

//                 entity.HasOne(d => d.Drug)
//                     .WithMany(p => p.Druginformation)
//                     .HasForeignKey(d => d.DrugId)
//                     .HasConstraintName("druginformation_drug_id_fkey");
//             });

//             modelBuilder.Entity<Drugprices>(entity =>
//             {
//                 entity.HasKey(e => new { e.DrugPrice, e.DrugId })
//                     .HasName("drugprices_pkey");

//                 entity.ToTable("drugprices");

//                 entity.Property(e => e.DrugPrice)
//                     .HasColumnName("drug_price")
//                     .HasColumnType("numeric(10,2)");

//                 entity.Property(e => e.DrugId).HasColumnName("drug_id");

//                 entity.Property(e => e.DrugPriceId)
//                     .HasColumnName("drug_price_id")
//                     .ValueGeneratedOnAdd();

//                 entity.Property(e => e.Pricestartdate).HasColumnName("pricestartdate");

//                 entity.HasOne(d => d.Drug)
//                     .WithMany(p => p.Drugprices)
//                     .HasForeignKey(d => d.DrugId)
//                     .OnDelete(DeleteBehavior.ClientSetNull)
//                     .HasConstraintName("drugprices_drug_id_fkey");
//             });

//             modelBuilder.Entity<Drugs>(entity =>
//             {
//                 entity.HasKey(e => e.DrugId)
//                     .HasName("drugs_pkey");

//                 entity.ToTable("drugs");

//                 entity.Property(e => e.DrugId).HasColumnName("drug_id");

//                 entity.Property(e => e.Classification)
//                     .HasColumnName("classification")
//                     .HasMaxLength(128);

//                 entity.Property(e => e.Description)
//                     .HasColumnName("description")
//                     .HasMaxLength(640);

//                 entity.Property(e => e.DosageInMg).HasColumnName("dosage_in_mg");

//                 entity.Property(e => e.DrugCost)
//                     .HasColumnName("drug_cost")
//                     .HasColumnType("numeric(10,2)");

//                 entity.Property(e => e.DrugName)
//                     .IsRequired()
//                     .HasColumnName("drug_name")
//                     .HasMaxLength(256);

//                 entity.Property(e => e.EndCustomerPrice)
//                     .HasColumnName("end_customer_price")
//                     .HasColumnType("numeric(10,2)");

//                 entity.Property(e => e.QuantityInStock).HasColumnName("quantity_in_stock");

//                 entity.Property(e => e.ReorderLevel).HasColumnName("reorder_level");

//                 entity.Property(e => e.ReorderQuantity).HasColumnName("reorder_quantity");

//                 entity.Property(e => e.SupplierId).HasColumnName("supplier_id");

//                 entity.HasOne(d => d.Supplier)
//                     .WithMany(p => p.Drugs)
//                     .HasForeignKey(d => d.SupplierId)
//                     .HasConstraintName("drugs_supplier_id_fkey");
//             });

//             modelBuilder.Entity<Manufacturer>(entity =>
//             {
//                 entity.ToTable("manufacturer");

//                 entity.Property(e => e.ManufacturerId).HasColumnName("manufacturer_id");

//                 entity.Property(e => e.Addressid).HasColumnName("addressid");

//                 entity.Property(e => e.Cnpj)
//                     .HasColumnName("cnpj")
//                     .HasMaxLength(32);

//                 entity.Property(e => e.ManufacturerName)
//                     .HasColumnName("manufacturer_name")
//                     .HasMaxLength(128);

//                 entity.HasOne(d => d.Address)
//                     .WithMany(p => p.Manufacturer)
//                     .HasForeignKey(d => d.Addressid)
//                     .HasConstraintName("manufacturer_addressid_fkey");
//             });

//             modelBuilder.Entity<Stockentries>(entity =>
//             {
//                 entity.HasKey(e => e.StockId)
//                     .HasName("stockentries_pkey");

//                 entity.ToTable("stockentries");

//                 entity.Property(e => e.StockId).HasColumnName("stock_id");

//                 entity.Property(e => e.CreatedAt).HasColumnName("created_at");

//                 entity.Property(e => e.DrugId).HasColumnName("drug_id");

//                 entity.Property(e => e.MaturityDate).HasColumnName("maturity_date");

//                 entity.Property(e => e.NfEmissionDate).HasColumnName("nf_emission_date");

//                 entity.Property(e => e.NfNumber)
//                     .IsRequired()
//                     .HasColumnName("nf_number")
//                     .HasMaxLength(10);

//                 entity.Property(e => e.Quantity).HasColumnName("quantity");

//                 entity.Property(e => e.SupplierId).HasColumnName("supplier_id");

//                 entity.Property(e => e.Totalcost)
//                     .HasColumnName("totalcost")
//                     .HasColumnType("numeric(10,2)");

//                 entity.HasOne(d => d.Drug)
//                     .WithMany(p => p.Stockentries)
//                     .HasForeignKey(d => d.DrugId)
//                     .OnDelete(DeleteBehavior.Cascade)
//                     .HasConstraintName("stockentries_drug_id_fkey");

//                 entity.HasOne(d => d.Supplier)
//                     .WithMany(p => p.Stockentries)
//                     .HasForeignKey(d => d.SupplierId)
//                     .HasConstraintName("stockentries_supplier_id_fkey");
//             });

//             modelBuilder.Entity<Suppliers>(entity =>
//             {
//                 entity.HasKey(e => e.SupplierId)
//                     .HasName("suppliers_pkey");

//                 entity.ToTable("suppliers");

//                 entity.Property(e => e.SupplierId).HasColumnName("supplier_id");

//                 entity.Property(e => e.Addressid).HasColumnName("addressid");

//                 entity.Property(e => e.Cnpj)
//                     .HasColumnName("cnpj")
//                     .HasMaxLength(60);

//                 entity.Property(e => e.SupplierName)
//                     .HasColumnName("supplier_name")
//                     .HasMaxLength(128);

//                 entity.HasOne(d => d.Address)
//                     .WithMany(p => p.Suppliers)
//                     .HasForeignKey(d => d.Addressid)
//                     .HasConstraintName("suppliers_addressid_fkey");
//             });

//             OnModelCreatingPartial(modelBuilder);
//         }

//         partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
//     }
// }
