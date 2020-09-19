using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Windows.DataMappings
{
    public partial class TransferMap
        : IEntityTypeConfiguration<Legacy.Entities.Transfer>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Legacy.Entities.Transfer> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("transfer", "public");

            // key
            builder.HasNoKey();

            // properties
            builder.Property(t => t.Trdata)
                .HasColumnName("trdata")
                .HasColumnType("date");

            builder.Property(t => t.Balcon)
                .HasColumnName("balcon")
                .HasColumnType("character varying(3)")
                .HasMaxLength(3);

            builder.Property(t => t.Prcodi)
                .HasColumnName("prcodi")
                .HasColumnType("character varying(6)")
                .HasMaxLength(6);

            builder.Property(t => t.Qtde)
                .HasColumnName("qtde")
                .HasColumnType("numeric(4,0)");

            builder.Property(t => t.Prcons)
                .HasColumnName("prcons")
                .HasColumnType("numeric(10,2)");

            builder.Property(t => t.Etiqueta)
                .HasColumnName("etiqueta")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.Impresso)
                .HasColumnName("impresso")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.Filcodi)
                .HasColumnName("filcodi")
                .HasColumnType("character varying(3)")
                .HasMaxLength(3);

            builder.Property(t => t.Hora)
                .HasColumnName("hora")
                .HasColumnType("character varying(5)")
                .HasMaxLength(5);

            // relationships
            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "public";
            public const string Name = "transfer";
        }

        public struct Columns
        {
            public const string Trdata = "trdata";
            public const string Balcon = "balcon";
            public const string Prcodi = "prcodi";
            public const string Qtde = "qtde";
            public const string Prcons = "prcons";
            public const string Etiqueta = "etiqueta";
            public const string Impresso = "impresso";
            public const string Filcodi = "filcodi";
            public const string Hora = "hora";
        }
        #endregion
    }
}
