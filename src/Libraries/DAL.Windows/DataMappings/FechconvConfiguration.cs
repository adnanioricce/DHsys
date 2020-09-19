using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Windows.DataMappings
{
    public partial class FechconvMap
        : IEntityTypeConfiguration<Legacy.Entities.Fechconv>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Legacy.Entities.Fechconv> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("fechconv", "public");

            // key
            builder.HasNoKey();

            // properties
            builder.Property(t => t.Fucdem)
                .HasColumnName("fucdem")
                .HasColumnType("character varying(3)")
                .HasMaxLength(3);

            builder.Property(t => t.Data)
                .HasColumnName("data")
                .HasColumnType("date");

            builder.Property(t => t.Valor)
                .HasColumnName("valor")
                .HasColumnType("numeric(12,0)");

            // relationships
            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "public";
            public const string Name = "fechconv";
        }

        public struct Columns
        {
            public const string Fucdem = "fucdem";
            public const string Data = "data";
            public const string Valor = "valor";
        }
        #endregion
    }
}
