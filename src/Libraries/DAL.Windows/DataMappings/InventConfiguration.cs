using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Windows.DataMappings
{
    public partial class InventMap
        : IEntityTypeConfiguration<global::Core.Entities.Legacy.Invent>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<global::Core.Entities.Legacy.Invent> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("invent", "public");

            // key
            builder.HasNoKey();

            // properties
            builder.Property(t => t.Prcodi)
                .HasColumnName("prcodi")
                .HasColumnType("character varying(6)")
                .HasMaxLength(6);

            builder.Property(t => t.Prreg)
                .HasColumnName("prreg")
                .HasColumnType("character varying(13)")
                .HasMaxLength(13);

            builder.Property(t => t.Prdesc)
                .HasColumnName("prdesc")
                .HasColumnType("character varying(30)")
                .HasMaxLength(30);

            builder.Property(t => t.Lote)
                .HasColumnName("lote")
                .HasColumnType("character varying(10)")
                .HasMaxLength(10);

            builder.Property(t => t.Qtde)
                .HasColumnName("qtde")
                .HasColumnType("numeric(6,0)");

            builder.Property(t => t.Tpmed)
                .HasColumnName("tpmed")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            // relationships
            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "public";
            public const string Name = "invent";
        }

        public struct Columns
        {
            public const string Prcodi = "prcodi";
            public const string Prreg = "prreg";
            public const string Prdesc = "prdesc";
            public const string Lote = "lote";
            public const string Qtde = "qtde";
            public const string Tpmed = "tpmed";
        }
        #endregion
    }
}
