using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Windows.DataMappings
{
    public partial class ClipagoMap
        : IEntityTypeConfiguration<Legacy.Entities.Clipago>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Legacy.Entities.Clipago> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("clipago", "public");

            // key
            builder.HasNoKey();

            // properties
            builder.Property(t => t.Cliente)
                .HasColumnName("cliente")
                .HasColumnType("character varying(4)")
                .HasMaxLength(4);

            builder.Property(t => t.Data)
                .HasColumnName("data")
                .HasColumnType("date");

            builder.Property(t => t.Valor)
                .HasColumnName("valor")
                .HasColumnType("numeric(10,2)");

            builder.Property(t => t.Credito)
                .HasColumnName("credito")
                .HasColumnType("numeric(10,2)");

            // relationships
            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "public";
            public const string Name = "clipago";
        }

        public struct Columns
        {
            public const string Cliente = "cliente";
            public const string Data = "data";
            public const string Valor = "valor";
            public const string Credito = "credito";
        }
        #endregion
    }
}
