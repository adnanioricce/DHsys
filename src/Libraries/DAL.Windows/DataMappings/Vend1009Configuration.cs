using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Windows.DataMappings
{
    public partial class Vend1009Map
        : IEntityTypeConfiguration<global::Core.Entities.Legacy.Vend1009>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<global::Core.Entities.Legacy.Vend1009> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("vend1009", "public");

            // key
            builder.HasNoKey();

            // properties
            builder.Property(t => t.Prcodi)
                .HasColumnName("prcodi")
                .HasColumnType("character varying(6)")
                .HasMaxLength(6);

            builder.Property(t => t.Prqtde)
                .HasColumnName("prqtde")
                .HasColumnType("numeric(6,0)");

            // relationships
            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "public";
            public const string Name = "vend1009";
        }

        public struct Columns
        {
            public const string Prcodi = "prcodi";
            public const string Prqtde = "prqtde";
        }
        #endregion
    }
}