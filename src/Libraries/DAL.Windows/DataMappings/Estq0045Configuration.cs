using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Windows.DataMappings
{
    public partial class Estq0045Map
        : IEntityTypeConfiguration<Legacy.Entities.Estq0045>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Legacy.Entities.Estq0045> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("estq0045", "public");

            // key
            builder.HasNoKey();

            // properties
            builder.Property(t => t.Prcodi)
                .HasColumnName("prcodi")
                .HasColumnType("character varying(6)")
                .HasMaxLength(6);

            builder.Property(t => t.Prbarra)
                .HasColumnName("prbarra")
                .HasColumnType("character varying(13)")
                .HasMaxLength(13);

            builder.Property(t => t.Prdesc)
                .HasColumnName("prdesc")
                .HasColumnType("character varying(30)")
                .HasMaxLength(30);

            builder.Property(t => t.Prestq)
                .HasColumnName("prestq")
                .HasColumnType("numeric(6,0)");

            builder.Property(t => t.EstMinimo)
                .HasColumnName("est_minimo")
                .HasColumnType("numeric(6,0)");

            builder.Property(t => t.Secao)
                .HasColumnName("secao")
                .HasColumnType("character varying(2)")
                .HasMaxLength(2);

            builder.Property(t => t.Prcdse)
                .HasColumnName("prcdse")
                .HasColumnType("character varying(4)")
                .HasMaxLength(4);

            // relationships
            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "public";
            public const string Name = "estq0045";
        }

        public struct Columns
        {
            public const string Prcodi = "prcodi";
            public const string Prbarra = "prbarra";
            public const string Prdesc = "prdesc";
            public const string Prestq = "prestq";
            public const string EstMinimo = "est_minimo";
            public const string Secao = "secao";
            public const string Prcdse = "prcdse";
        }
        #endregion
    }
}
