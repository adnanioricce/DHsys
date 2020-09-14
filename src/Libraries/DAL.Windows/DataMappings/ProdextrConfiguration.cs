using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Windows.DataMappings
{
    public partial class ProdextrMap
        : IEntityTypeConfiguration<global::Core.Entities.Legacy.Prodextr>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<global::Core.Entities.Legacy.Prodextr> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("prodextr", "public");

            // key
            builder.HasNoKey();

            // properties
            builder.Property(t => t.Prcodi)
                .HasColumnName("prcodi")
                .HasColumnType("character varying(6)")
                .HasMaxLength(6);

            builder.Property(t => t.Prdesc)
                .HasColumnName("prdesc")
                .HasColumnType("character varying(30)")
                .HasMaxLength(30);

            builder.Property(t => t.Prcons)
                .HasColumnName("prcons")
                .HasColumnType("numeric(12,2)");

            builder.Property(t => t.Concor1)
                .HasColumnName("concor1")
                .HasColumnType("numeric(12,2)");

            builder.Property(t => t.Concor2)
                .HasColumnName("concor2")
                .HasColumnType("numeric(12,2)");

            builder.Property(t => t.Concor3)
                .HasColumnName("concor3")
                .HasColumnType("numeric(12,2)");

            builder.Property(t => t.Concor4)
                .HasColumnName("concor4")
                .HasColumnType("numeric(12,2)");

            // relationships
            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "public";
            public const string Name = "prodextr";
        }

        public struct Columns
        {
            public const string Prcodi = "prcodi";
            public const string Prdesc = "prdesc";
            public const string Prcons = "prcons";
            public const string Concor1 = "concor1";
            public const string Concor2 = "concor2";
            public const string Concor3 = "concor3";
            public const string Concor4 = "concor4";
        }
        #endregion
    }
}
