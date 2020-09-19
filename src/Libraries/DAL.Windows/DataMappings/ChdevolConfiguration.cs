using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Windows.DataMappings
{
    public partial class ChdevolMap
        : IEntityTypeConfiguration<Legacy.Entities.Chdevol>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Legacy.Entities.Chdevol> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("chdevol", "public");

            // key
            builder.HasNoKey();

            // properties
            builder.Property(t => t.Cheque)
                .HasColumnName("cheque")
                .HasColumnType("character varying(12)")
                .HasMaxLength(12);

            builder.Property(t => t.Agencia)
                .HasColumnName("agencia")
                .HasColumnType("character varying(4)")
                .HasMaxLength(4);

            builder.Property(t => t.Banco)
                .HasColumnName("banco")
                .HasColumnType("character varying(3)")
                .HasMaxLength(3);

            builder.Property(t => t.Conta)
                .HasColumnName("conta")
                .HasColumnType("character varying(12)")
                .HasMaxLength(12);

            builder.Property(t => t.Valor)
                .HasColumnName("valor")
                .HasColumnType("numeric(12,2)");

            builder.Property(t => t.Datae)
                .HasColumnName("datae")
                .HasColumnType("date");

            builder.Property(t => t.Data)
                .HasColumnName("data")
                .HasColumnType("date");

            builder.Property(t => t.Cliente)
                .HasColumnName("cliente")
                .HasColumnType("character varying(6)")
                .HasMaxLength(6);

            // relationships
            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "public";
            public const string Name = "chdevol";
        }

        public struct Columns
        {
            public const string Cheque = "cheque";
            public const string Agencia = "agencia";
            public const string Banco = "banco";
            public const string Conta = "conta";
            public const string Valor = "valor";
            public const string Datae = "datae";
            public const string Data = "data";
            public const string Cliente = "cliente";
        }
        #endregion
    }
}
