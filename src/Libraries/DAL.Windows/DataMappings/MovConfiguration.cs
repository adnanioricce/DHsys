using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Windows.DataMappings
{
    public partial class MovMap
        : IEntityTypeConfiguration<global::Core.Entities.Legacy.Mov>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<global::Core.Entities.Legacy.Mov> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("mov", "public");

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

            builder.Property(t => t.TotAnt)
                .HasColumnName("tot_ant")
                .HasColumnType("numeric(12,2)");

            builder.Property(t => t.Tipo)
                .HasColumnName("tipo")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.Tpvd)
                .HasColumnName("tpvd")
                .HasColumnType("character varying(6)")
                .HasMaxLength(6);

            builder.Property(t => t.Ecf)
                .HasColumnName("ecf")
                .HasColumnType("character varying(8)")
                .HasMaxLength(8);

            builder.Property(t => t.Cpf)
                .HasColumnName("cpf")
                .HasColumnType("character varying(14)")
                .HasMaxLength(14);

            builder.Property(t => t.Nome)
                .HasColumnName("nome")
                .HasColumnType("character varying(30)")
                .HasMaxLength(30);

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
                .HasColumnType("character varying(2)")
                .HasMaxLength(2);

            builder.Property(t => t.Hora)
                .HasColumnName("hora")
                .HasColumnType("character varying(5)")
                .HasMaxLength(5);

            builder.Property(t => t.Dinheiro)
                .HasColumnName("dinheiro")
                .HasColumnType("numeric(10,2)");

            builder.Property(t => t.Cheque)
                .HasColumnName("cheque")
                .HasColumnType("numeric(10,2)");

            builder.Property(t => t.Chequepre)
                .HasColumnName("chequepre")
                .HasColumnType("numeric(10,2)");

            builder.Property(t => t.Cartaoc)
                .HasColumnName("cartaoc")
                .HasColumnType("numeric(10,2)");

            builder.Property(t => t.Popular)
                .HasColumnName("popular")
                .HasColumnType("numeric(10,2)");

            builder.Property(t => t.Admcart)
                .HasColumnName("admcart")
                .HasColumnType("character varying(2)")
                .HasMaxLength(2);

            builder.Property(t => t.Codcli)
                .HasColumnName("codcli")
                .HasColumnType("character varying(6)")
                .HasMaxLength(6);

            // relationships
            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "public";
            public const string Name = "mov";
        }

        public struct Columns
        {
            public const string nFiscal = "n_fiscal";
            public const string Ticket = "ticket";
            public const string TotVen = "tot_ven";
            public const string TotAnt = "tot_ant";
            public const string Tipo = "tipo";
            public const string Tpvd = "tpvd";
            public const string Ecf = "ecf";
            public const string Cpf = "cpf";
            public const string Nome = "nome";
            public const string Data = "data";
            public const string Bacodi = "bacodi";
            public const string Cancelado = "cancelado";
            public const string Caixa = "caixa";
            public const string Hora = "hora";
            public const string Dinheiro = "dinheiro";
            public const string Cheque = "cheque";
            public const string Chequepre = "chequepre";
            public const string Cartaoc = "cartaoc";
            public const string Popular = "popular";
            public const string Admcart = "admcart";
            public const string Codcli = "codcli";
        }
        #endregion
    }
}