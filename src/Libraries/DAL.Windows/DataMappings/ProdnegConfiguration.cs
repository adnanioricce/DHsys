using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Windows.DataMappings
{
    public partial class ProdnegMap
        : IEntityTypeConfiguration<global::Core.Entities.Legacy.Prodneg>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<global::Core.Entities.Legacy.Prodneg> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("prodneg", "public");

            // key
            builder.HasNoKey();

            // properties
            builder.Property(t => t.Prcodi)
                .HasColumnName("prcodi")
                .HasColumnType("character varying(6)")
                .HasMaxLength(6);

            builder.Property(t => t.Prqtde)
                .HasColumnName("prqtde")
                .HasColumnType("numeric(4,0)");

            builder.Property(t => t.Prdata)
                .HasColumnName("prdata")
                .HasColumnType("date");

            builder.Property(t => t.Prhora)
                .HasColumnName("prhora")
                .HasColumnType("character varying(5)")
                .HasMaxLength(5);

            builder.Property(t => t.Prtipo)
                .HasColumnName("prtipo")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.Prestq)
                .HasColumnName("prestq")
                .HasColumnType("numeric(4,0)");

            // relationships
            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "public";
            public const string Name = "prodneg";
        }

        public struct Columns
        {
            public const string Prcodi = "prcodi";
            public const string Prqtde = "prqtde";
            public const string Prdata = "prdata";
            public const string Prhora = "prhora";
            public const string Prtipo = "prtipo";
            public const string Prestq = "prestq";
        }
        #endregion
    }
}
