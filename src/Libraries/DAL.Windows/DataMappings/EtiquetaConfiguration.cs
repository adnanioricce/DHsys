using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Windows.DataMappings
{
    public partial class EtiquetaMap
        : IEntityTypeConfiguration<global::Core.Entities.Legacy.Etiqueta>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<global::Core.Entities.Legacy.Etiqueta> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("etiqueta", "public");

            // key
            builder.HasNoKey();

            // properties
            builder.Property(t => t.Prcodi)
                .HasColumnName("prcodi")
                .HasColumnType("character varying(6)")
                .HasMaxLength(6);

            builder.Property(t => t.Prdesc1)
                .HasColumnName("prdesc1")
                .HasColumnType("character varying(15)")
                .HasMaxLength(15);

            builder.Property(t => t.Prdesc2)
                .HasColumnName("prdesc2")
                .HasColumnType("character varying(15)")
                .HasMaxLength(15);

            builder.Property(t => t.Prcons)
                .HasColumnName("prcons")
                .HasColumnType("numeric(10,2)");

            // relationships
            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "public";
            public const string Name = "etiqueta";
        }

        public struct Columns
        {
            public const string Prcodi = "prcodi";
            public const string Prdesc1 = "prdesc1";
            public const string Prdesc2 = "prdesc2";
            public const string Prcons = "prcons";
        }
        #endregion
    }
}
