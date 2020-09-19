using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Windows.DataMappings
{
    public partial class Vend0711Map
        : IEntityTypeConfiguration<Legacy.Entities.Vend0711>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Legacy.Entities.Vend0711> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("vend0711", "public");

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
            public const string Name = "vend0711";
        }

        public struct Columns
        {
            public const string Prcodi = "prcodi";
            public const string Prqtde = "prqtde";
        }
        #endregion
    }
}
