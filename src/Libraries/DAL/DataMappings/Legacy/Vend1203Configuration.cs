using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Mappings.Legacy
{
    public partial class Vend1203Map
        : IEntityTypeConfiguration<global::Core.Entities.Legacy.Vend1203>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<global::Core.Entities.Legacy.Vend1203> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("vend1203", "public");

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
            public const string Name = "vend1203";
        }

        public struct Columns
        {
            public const string Prcodi = "prcodi";
            public const string Prqtde = "prqtde";
        }
        #endregion
    }
}
