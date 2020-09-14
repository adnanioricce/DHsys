using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Windows.DataMappings
{
    public partial class FaltasMap
        : IEntityTypeConfiguration<global::Core.Entities.Legacy.Faltas>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<global::Core.Entities.Legacy.Faltas> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("faltas", "public");

            // key
            builder.HasNoKey();

            // properties
            builder.Property(t => t.Prcodi)
                .HasColumnName("prcodi")
                .HasColumnType("character varying(6)")
                .HasMaxLength(6);

            builder.Property(t => t.Data)
                .HasColumnName("data")
                .HasColumnType("date");

            builder.Property(t => t.Balcon)
                .HasColumnName("balcon")
                .HasColumnType("character varying(3)")
                .HasMaxLength(3);

            // relationships
            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "public";
            public const string Name = "faltas";
        }

        public struct Columns
        {
            public const string Prcodi = "prcodi";
            public const string Data = "data";
            public const string Balcon = "balcon";
        }
        #endregion
    }
}
