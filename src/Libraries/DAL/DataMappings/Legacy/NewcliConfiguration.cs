using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Mappings.Legacy
{
    public partial class NewcliMap
        : IEntityTypeConfiguration<global::Core.Entities.Legacy.Newcli>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<global::Core.Entities.Legacy.Newcli> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("newcli", "public");

            // key
            builder.HasNoKey();

            // properties
            builder.Property(t => t.Codigo)
                .HasColumnName("codigo")
                .HasColumnType("character varying(5)")
                .HasMaxLength(5);

            builder.Property(t => t.Nome)
                .HasColumnName("nome")
                .HasColumnType("character varying(50)")
                .HasMaxLength(50);

            builder.Property(t => t.Endereco)
                .HasColumnName("endereco")
                .HasColumnType("character varying(50)")
                .HasMaxLength(50);

            builder.Property(t => t.Cidade)
                .HasColumnName("cidade")
                .HasColumnType("character varying(20)")
                .HasMaxLength(20);

            builder.Property(t => t.Bairro)
                .HasColumnName("bairro")
                .HasColumnType("character varying(20)")
                .HasMaxLength(20);

            builder.Property(t => t.Cep)
                .HasColumnName("cep")
                .HasColumnType("character varying(9)")
                .HasMaxLength(9);

            builder.Property(t => t.Fone)
                .HasColumnName("fone")
                .HasColumnType("character varying(15)")
                .HasMaxLength(15);

            builder.Property(t => t.Rg)
                .HasColumnName("rg")
                .HasColumnType("character varying(19)")
                .HasMaxLength(19);

            builder.Property(t => t.Datanasc)
                .HasColumnName("datanasc")
                .HasColumnType("date");

            builder.Property(t => t.Tipo)
                .HasColumnName("tipo")
                .HasColumnType("character varying(5)")
                .HasMaxLength(5);

            builder.Property(t => t.Impresso)
                .HasColumnName("impresso")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.Desconto)
                .HasColumnName("desconto")
                .HasColumnType("numeric(2,0)");

            builder.Property(t => t.Clclassi)
                .HasColumnName("clclassi")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.UltCompra)
                .HasColumnName("ult_compra")
                .HasColumnType("date");

            // relationships
            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "public";
            public const string Name = "newcli";
        }

        public struct Columns
        {
            public const string Codigo = "codigo";
            public const string Nome = "nome";
            public const string Endereco = "endereco";
            public const string Cidade = "cidade";
            public const string Bairro = "bairro";
            public const string Cep = "cep";
            public const string Fone = "fone";
            public const string Rg = "rg";
            public const string Datanasc = "datanasc";
            public const string Tipo = "tipo";
            public const string Impresso = "impresso";
            public const string Desconto = "desconto";
            public const string Clclassi = "clclassi";
            public const string UltCompra = "ult_compra";
        }
        #endregion
    }
}
