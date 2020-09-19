using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Windows.DataMappings
{
    public partial class MalclienMap
        : IEntityTypeConfiguration<Legacy.Entities.Malclien>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Legacy.Entities.Malclien> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("malclien", "public");

            // key
            builder.HasNoKey();

            // properties
            builder.Property(t => t.Codigo)
                .HasColumnName("codigo")
                .HasColumnType("character varying(6)")
                .HasMaxLength(6);

            builder.Property(t => t.Nome)
                .HasColumnName("nome")
                .HasColumnType("character varying(45)")
                .HasMaxLength(45);

            builder.Property(t => t.Endereco)
                .HasColumnName("endereco")
                .HasColumnType("character varying(50)")
                .HasMaxLength(50);

            builder.Property(t => t.Datanasc)
                .HasColumnName("datanasc")
                .HasColumnType("date");

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

            builder.Property(t => t.Balcon)
                .HasColumnName("balcon")
                .HasColumnType("character varying(3)")
                .HasMaxLength(3);

            builder.Property(t => t.Dtcad)
                .HasColumnName("dtcad")
                .HasColumnType("date");

            builder.Property(t => t.Rg)
                .HasColumnName("rg")
                .HasColumnType("character varying(19)")
                .HasMaxLength(19);

            builder.Property(t => t.Cpf)
                .HasColumnName("cpf")
                .HasColumnType("character varying(15)")
                .HasMaxLength(15);

            builder.Property(t => t.Impresso)
                .HasColumnName("impresso")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.Acumulado)
                .HasColumnName("acumulado")
                .HasColumnType("numeric(12,2)");

            builder.Property(t => t.Aposentado)
                .HasColumnName("aposentado")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.Descmed)
                .HasColumnName("descmed")
                .HasColumnType("numeric(5,2)");

            builder.Property(t => t.Descout)
                .HasColumnName("descout")
                .HasColumnType("numeric(5,2)");

            builder.Property(t => t.Clclassi)
                .HasColumnName("clclassi")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.Clobs1)
                .HasColumnName("clobs1")
                .HasColumnType("character varying(50)")
                .HasMaxLength(50);

            builder.Property(t => t.Clobs2)
                .HasColumnName("clobs2")
                .HasColumnType("character varying(50)")
                .HasMaxLength(50);

            builder.Property(t => t.Filial)
                .HasColumnName("filial")
                .HasColumnType("character varying(4)")
                .HasMaxLength(4);

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
            public const string Name = "malclien";
        }

        public struct Columns
        {
            public const string Codigo = "codigo";
            public const string Nome = "nome";
            public const string Endereco = "endereco";
            public const string Datanasc = "datanasc";
            public const string Cidade = "cidade";
            public const string Bairro = "bairro";
            public const string Cep = "cep";
            public const string Fone = "fone";
            public const string Balcon = "balcon";
            public const string Dtcad = "dtcad";
            public const string Rg = "rg";
            public const string Cpf = "cpf";
            public const string Impresso = "impresso";
            public const string Acumulado = "acumulado";
            public const string Aposentado = "aposentado";
            public const string Descmed = "descmed";
            public const string Descout = "descout";
            public const string Clclassi = "clclassi";
            public const string Clobs1 = "clobs1";
            public const string Clobs2 = "clobs2";
            public const string Filial = "filial";
            public const string UltCompra = "ult_compra";
        }
        #endregion
    }
}
