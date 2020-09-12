using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Mappings.Legacy
{
    public partial class ChequeMap
        : IEntityTypeConfiguration<global::Core.Entities.Legacy.Cheque>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<global::Core.Entities.Legacy.Cheque> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("cheque", "public");

            // key
            builder.HasNoKey();

            // properties
            builder.Property(t => t.Cheque1)
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

            builder.Property(t => t.Situacao)
                .HasColumnName("situacao")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.Baixa)
                .HasColumnName("baixa")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.Ticket)
                .HasColumnName("ticket")
                .HasColumnType("character varying(15)")
                .HasMaxLength(15);

            builder.Property(t => t.Filial)
                .HasColumnName("filial")
                .HasColumnType("character varying(4)")
                .HasMaxLength(4);

            builder.Property(t => t.Telefone)
                .HasColumnName("telefone")
                .HasColumnType("character varying(17)")
                .HasMaxLength(17);

            builder.Property(t => t.Rg)
                .HasColumnName("rg")
                .HasColumnType("character varying(17)")
                .HasMaxLength(17);

            builder.Property(t => t.Obs)
                .HasColumnName("obs")
                .HasColumnType("character varying(30)")
                .HasMaxLength(30);

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
            public const string Name = "cheque";
        }

        public struct Columns
        {
            public const string ChequeMember = "cheque";
            public const string Agencia = "agencia";
            public const string Banco = "banco";
            public const string Conta = "conta";
            public const string Valor = "valor";
            public const string Datae = "datae";
            public const string Data = "data";
            public const string Situacao = "situacao";
            public const string Baixa = "baixa";
            public const string Ticket = "ticket";
            public const string Filial = "filial";
            public const string Telefone = "telefone";
            public const string Rg = "rg";
            public const string Obs = "obs";
            public const string Cliente = "cliente";
        }
        #endregion
    }
}
