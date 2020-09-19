using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Windows.DataMappings
{
    public partial class UserMap
        : IEntityTypeConfiguration<Legacy.Entities.User>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Legacy.Entities.User> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("user", "public");

            // key
            builder.HasNoKey();

            // properties
            builder.Property(t => t.Nome)
                .HasColumnName("nome")
                .HasColumnType("character varying(30)")
                .HasMaxLength(30);

            builder.Property(t => t.Endereco)
                .HasColumnName("endereco")
                .HasColumnType("character varying(49)")
                .HasMaxLength(49);

            builder.Property(t => t.Numero)
                .HasColumnName("numero")
                .HasColumnType("character varying(5)")
                .HasMaxLength(5);

            builder.Property(t => t.Bairro)
                .HasColumnName("bairro")
                .HasColumnType("character varying(25)")
                .HasMaxLength(25);

            builder.Property(t => t.Cidade)
                .HasColumnName("cidade")
                .HasColumnType("character varying(25)")
                .HasMaxLength(25);

            builder.Property(t => t.Cep)
                .HasColumnName("cep")
                .HasColumnType("character varying(9)")
                .HasMaxLength(9);

            builder.Property(t => t.Cgc)
                .HasColumnName("cgc")
                .HasColumnType("character varying(18)")
                .HasMaxLength(18);

            builder.Property(t => t.Cpf)
                .HasColumnName("cpf")
                .HasColumnType("character varying(11)")
                .HasMaxLength(11);

            builder.Property(t => t.Inscrest)
                .HasColumnName("inscrest")
                .HasColumnType("character varying(18)")
                .HasMaxLength(18);

            builder.Property(t => t.Telefone)
                .HasColumnName("telefone")
                .HasColumnType("character varying(10)")
                .HasMaxLength(10);

            builder.Property(t => t.Fax)
                .HasColumnName("fax")
                .HasColumnType("character varying(9)")
                .HasMaxLength(9);

            builder.Property(t => t.Apelido)
                .HasColumnName("apelido")
                .HasColumnType("character varying(10)")
                .HasMaxLength(10);

            builder.Property(t => t.Licenca)
                .HasColumnName("licenca")
                .HasColumnType("character varying(25)")
                .HasMaxLength(25);

            builder.Property(t => t.ModNf)
                .HasColumnName("mod_nf")
                .HasColumnType("character varying(2)")
                .HasMaxLength(2);

            builder.Property(t => t.SerieNf)
                .HasColumnName("serie_nf")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.Numseq)
                .HasColumnName("numseq")
                .HasColumnType("numeric(10,0)");

            builder.Property(t => t.Ibge)
                .HasColumnName("ibge")
                .HasColumnType("character varying(7)")
                .HasMaxLength(7);

            builder.Property(t => t.Nfe)
                .HasColumnName("nfe")
                .HasColumnType("numeric(6,0)");

            builder.Property(t => t.Lote)
                .HasColumnName("lote")
                .HasColumnType("numeric(6,0)");

            builder.Property(t => t.Empresa)
                .HasColumnName("empresa")
                .HasColumnType("character varying(4)")
                .HasMaxLength(4);

            builder.Property(t => t.Imposto)
                .HasColumnName("imposto")
                .HasColumnType("numeric(5,2)");

            builder.Property(t => t.Coment1)
                .HasColumnName("coment1")
                .HasColumnType("character varying(48)")
                .HasMaxLength(48);

            builder.Property(t => t.Coment2)
                .HasColumnName("coment2")
                .HasColumnType("character varying(48)")
                .HasMaxLength(48);

            builder.Property(t => t.Coment3)
                .HasColumnName("coment3")
                .HasColumnType("character varying(48)")
                .HasMaxLength(48);

            builder.Property(t => t.Coment4)
                .HasColumnName("coment4")
                .HasColumnType("character varying(48)")
                .HasMaxLength(48);

            builder.Property(t => t.Comefia)
                .HasColumnName("comefia")
                .HasColumnType("character varying(48)")
                .HasMaxLength(48);

            builder.Property(t => t.Disk1)
                .HasColumnName("disk1")
                .HasColumnType("character varying(48)")
                .HasMaxLength(48);

            builder.Property(t => t.Disk2)
                .HasColumnName("disk2")
                .HasColumnType("character varying(48)")
                .HasMaxLength(48);

            builder.Property(t => t.Disk3)
                .HasColumnName("disk3")
                .HasColumnType("character varying(48)")
                .HasMaxLength(48);

            builder.Property(t => t.Disk4)
                .HasColumnName("disk4")
                .HasColumnType("character varying(48)")
                .HasMaxLength(48);

            builder.Property(t => t.Disk5)
                .HasColumnName("disk5")
                .HasColumnType("character varying(48)")
                .HasMaxLength(48);

            builder.Property(t => t.Pop)
                .HasColumnName("pop")
                .HasColumnType("numeric(12,0)");

            // relationships
            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "public";
            public const string Name = "user";
        }

        public struct Columns
        {
            public const string Nome = "nome";
            public const string Endereco = "endereco";
            public const string Numero = "numero";
            public const string Bairro = "bairro";
            public const string Cidade = "cidade";
            public const string Cep = "cep";
            public const string Cgc = "cgc";
            public const string Cpf = "cpf";
            public const string Inscrest = "inscrest";
            public const string Telefone = "telefone";
            public const string Fax = "fax";
            public const string Apelido = "apelido";
            public const string Licenca = "licenca";
            public const string ModNf = "mod_nf";
            public const string SerieNf = "serie_nf";
            public const string Numseq = "numseq";
            public const string Ibge = "ibge";
            public const string Nfe = "nfe";
            public const string Lote = "lote";
            public const string Empresa = "empresa";
            public const string Imposto = "imposto";
            public const string Coment1 = "coment1";
            public const string Coment2 = "coment2";
            public const string Coment3 = "coment3";
            public const string Coment4 = "coment4";
            public const string Comefia = "comefia";
            public const string Disk1 = "disk1";
            public const string Disk2 = "disk2";
            public const string Disk3 = "disk3";
            public const string Disk4 = "disk4";
            public const string Disk5 = "disk5";
            public const string Pop = "pop";
        }
        #endregion
    }
}
