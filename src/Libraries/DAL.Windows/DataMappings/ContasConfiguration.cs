using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Windows.DataMappings
{
    public partial class ContasMap
        : IEntityTypeConfiguration<Legacy.Entities.Contas>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Legacy.Entities.Contas> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("contas", "public");

            // key
            builder.HasNoKey();

            // properties
            builder.Property(t => t.Cod)
                .HasColumnName("cod")
                .HasColumnType("character varying(4)")
                .HasMaxLength(4);

            builder.Property(t => t.Hist)
                .HasColumnName("hist")
                .HasColumnType("character varying(25)")
                .HasMaxLength(25);

            // relationships
            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "public";
            public const string Name = "contas";
        }

        public struct Columns
        {
            public const string Cod = "cod";
            public const string Hist = "hist";
        }
        #endregion
    }
}
