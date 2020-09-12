using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Mappings.Legacy
{
    public partial class CadpromMap
        : IEntityTypeConfiguration<global::Core.Entities.Legacy.Cadprom>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<global::Core.Entities.Legacy.Cadprom> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("cadprom", "public");

            // key
            builder.HasNoKey();

            // properties
            builder.Property(t => t.Lacodi)
                .HasColumnName("lacodi")
                .HasColumnType("character varying(4)")
                .HasMaxLength(4);

            builder.Property(t => t.Fonome)
                .HasColumnName("fonome")
                .HasColumnType("character varying(30)")
                .HasMaxLength(30);

            builder.Property(t => t.Fotele)
                .HasColumnName("fotele")
                .HasColumnType("character varying(15)")
                .HasMaxLength(15);

            builder.Property(t => t.Valid)
                .HasColumnName("valid")
                .HasColumnType("date");

            // relationships
            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "public";
            public const string Name = "cadprom";
        }

        public struct Columns
        {
            public const string Lacodi = "lacodi";
            public const string Fonome = "fonome";
            public const string Fotele = "fotele";
            public const string Valid = "valid";
        }
        #endregion
    }
}
