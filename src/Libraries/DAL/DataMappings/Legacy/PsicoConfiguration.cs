using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Mappings.Legacy
{
    public partial class PsicoMap
        : IEntityTypeConfiguration<global::Core.Entities.Legacy.Psico>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<global::Core.Entities.Legacy.Psico> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("psico", "public");

            // key
            builder.HasNoKey();

            // properties
            builder.Property(t => t.Prcodi)
                .HasColumnName("prcodi")
                .HasColumnType("character varying(6)")
                .HasMaxLength(6);

            builder.Property(t => t.Ticket)
                .HasColumnName("ticket")
                .HasColumnType("character varying(6)")
                .HasMaxLength(6);

            builder.Property(t => t.Prreg)
                .HasColumnName("prreg")
                .HasColumnType("character varying(13)")
                .HasMaxLength(13);

            builder.Property(t => t.Barras)
                .HasColumnName("barras")
                .HasColumnType("character varying(13)")
                .HasMaxLength(13);

            builder.Property(t => t.Prdesc)
                .HasColumnName("prdesc")
                .HasColumnType("character varying(30)")
                .HasMaxLength(30);

            builder.Property(t => t.Receita)
                .HasColumnName("receita")
                .HasColumnType("character varying(10)")
                .HasMaxLength(10);

            builder.Property(t => t.Tpreceita)
                .HasColumnName("tpreceita")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.Crm)
                .HasColumnName("crm")
                .HasColumnType("character varying(10)")
                .HasMaxLength(10);

            builder.Property(t => t.Nomemed)
                .HasColumnName("nomemed")
                .HasColumnType("character varying(50)")
                .HasMaxLength(50);

            builder.Property(t => t.Tpcons)
                .HasColumnName("tpcons")
                .HasColumnType("character varying(5)")
                .HasMaxLength(5);

            builder.Property(t => t.Ufcons)
                .HasColumnName("ufcons")
                .HasColumnType("character varying(2)")
                .HasMaxLength(2);

            builder.Property(t => t.Lote)
                .HasColumnName("lote")
                .HasColumnType("character varying(10)")
                .HasMaxLength(10);

            builder.Property(t => t.Qtde)
                .HasColumnName("qtde")
                .HasColumnType("numeric(6,0)");

            builder.Property(t => t.Data)
                .HasColumnName("data")
                .HasColumnType("date");

            builder.Property(t => t.Tipo)
                .HasColumnName("tipo")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.Motivo)
                .HasColumnName("motivo")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.Usomed)
                .HasColumnName("usomed")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.Porta)
                .HasColumnName("porta")
                .HasColumnType("character varying(6)")
                .HasMaxLength(6);

            builder.Property(t => t.Rg)
                .HasColumnName("rg")
                .HasColumnType("character varying(12)")
                .HasMaxLength(12);

            builder.Property(t => t.Orgao)
                .HasColumnName("orgao")
                .HasColumnType("character varying(3)")
                .HasMaxLength(3);

            builder.Property(t => t.Paciente)
                .HasColumnName("paciente")
                .HasColumnType("character varying(50)")
                .HasMaxLength(50);

            builder.Property(t => t.Uf)
                .HasColumnName("uf")
                .HasColumnType("character varying(2)")
                .HasMaxLength(2);

            builder.Property(t => t.Emissao)
                .HasColumnName("emissao")
                .HasColumnType("date");

            builder.Property(t => t.Nf)
                .HasColumnName("nf")
                .HasColumnType("character varying(8)")
                .HasMaxLength(8);

            builder.Property(t => t.Cnpj)
                .HasColumnName("cnpj")
                .HasColumnType("character varying(14)")
                .HasMaxLength(14);

            builder.Property(t => t.Fornec)
                .HasColumnName("fornec")
                .HasColumnType("character varying(4)")
                .HasMaxLength(4);

            builder.Property(t => t.Fone)
                .HasColumnName("fone")
                .HasColumnType("character varying(20)")
                .HasMaxLength(20);

            builder.Property(t => t.Nome)
                .HasColumnName("nome")
                .HasColumnType("character varying(50)")
                .HasMaxLength(50);

            builder.Property(t => t.Tpmed)
                .HasColumnName("tpmed")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.Sexo)
                .HasColumnName("sexo")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.Cid)
                .HasColumnName("cid")
                .HasColumnType("character varying(4)")
                .HasMaxLength(4);

            builder.Property(t => t.Idade)
                .HasColumnName("idade")
                .HasColumnType("character varying(3)")
                .HasMaxLength(3);

            builder.Property(t => t.Tpidade)
                .HasColumnName("tpidade")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.Prolong)
                .HasColumnName("prolong")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.Unidade)
                .HasColumnName("unidade")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.Nasc)
                .HasColumnName("nasc")
                .HasColumnType("date");

            // relationships
            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "public";
            public const string Name = "psico";
        }

        public struct Columns
        {
            public const string Prcodi = "prcodi";
            public const string Ticket = "ticket";
            public const string Prreg = "prreg";
            public const string Barras = "barras";
            public const string Prdesc = "prdesc";
            public const string Receita = "receita";
            public const string Tpreceita = "tpreceita";
            public const string Crm = "crm";
            public const string Nomemed = "nomemed";
            public const string Tpcons = "tpcons";
            public const string Ufcons = "ufcons";
            public const string Lote = "lote";
            public const string Qtde = "qtde";
            public const string Data = "data";
            public const string Tipo = "tipo";
            public const string Motivo = "motivo";
            public const string Usomed = "usomed";
            public const string Porta = "porta";
            public const string Rg = "rg";
            public const string Orgao = "orgao";
            public const string Paciente = "paciente";
            public const string Uf = "uf";
            public const string Emissao = "emissao";
            public const string Nf = "nf";
            public const string Cnpj = "cnpj";
            public const string Fornec = "fornec";
            public const string Fone = "fone";
            public const string Nome = "nome";
            public const string Tpmed = "tpmed";
            public const string Sexo = "sexo";
            public const string Cid = "cid";
            public const string Idade = "idade";
            public const string Tpidade = "tpidade";
            public const string Prolong = "prolong";
            public const string Unidade = "unidade";
            public const string Nasc = "nasc";
        }
        #endregion
    }
}
