using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Windows.DataMappings
{
    public partial class RanclivlMap
        : IEntityTypeConfiguration<Legacy.Entities.Ranclivl>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Legacy.Entities.Ranclivl> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("ranclivl", "public");

            // key
            builder.HasNoKey();

            // properties
            builder.Property(t => t.NFiscal)
                .HasColumnName("n_fiscal")
                .HasColumnType("character varying(6)")
                .HasMaxLength(6);

            builder.Property(t => t.Ticket)
                .HasColumnName("ticket")
                .HasColumnType("character varying(6)")
                .HasMaxLength(6);

            builder.Property(t => t.TotVen)
                .HasColumnName("tot_ven")
                .HasColumnType("numeric(12,2)");

            builder.Property(t => t.Tipo)
                .HasColumnName("tipo")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.Data)
                .HasColumnName("data")
                .HasColumnType("date");

            builder.Property(t => t.Bacodi)
                .HasColumnName("bacodi")
                .HasColumnType("character varying(3)")
                .HasMaxLength(3);

            builder.Property(t => t.Cancelado)
                .HasColumnName("cancelado")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.Caixa)
                .HasColumnName("caixa")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.Hora)
                .HasColumnName("hora")
                .HasColumnType("character varying(5)")
                .HasMaxLength(5);

            builder.Property(t => t.Codcli)
                .HasColumnName("codcli")
                .HasColumnType("character varying(5)")
                .HasMaxLength(5);

            // relationships
            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "public";
            public const string Name = "ranclivl";
        }

        public struct Columns
        {
            public const string nFiscal = "n_fiscal";
            public const string Ticket = "ticket";
            public const string TotVen = "tot_ven";
            public const string Tipo = "tipo";
            public const string Data = "data";
            public const string Bacodi = "bacodi";
            public const string Cancelado = "cancelado";
            public const string Caixa = "caixa";
            public const string Hora = "hora";
            public const string Codcli = "codcli";
        }
        #endregion
    }
}
