using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Windows.DataMappings
{
    public partial class ClicheqMap
        : IEntityTypeConfiguration<Legacy.Entities.Clicheq>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Legacy.Entities.Clicheq> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("clicheq", "public");

            // key
            builder.HasNoKey();

            // properties
            builder.Property(t => t.Codigo)
                .HasColumnName("codigo")
                .HasColumnType("character varying(6)")
                .HasMaxLength(6);

            builder.Property(t => t.Nome)
                .HasColumnName("nome")
                .HasColumnType("character varying(50)")
                .HasMaxLength(50);

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
                .HasColumnType("character varying(30)")
                .HasMaxLength(30);

            builder.Property(t => t.Rg)
                .HasColumnName("rg")
                .HasColumnType("character varying(25)")
                .HasMaxLength(25);

            builder.Property(t => t.Cpf)
                .HasColumnName("cpf")
                .HasColumnType("character varying(15)")
                .HasMaxLength(15);

            // relationships
            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "public";
            public const string Name = "clicheq";
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
            public const string Rg = "rg";
            public const string Cpf = "cpf";
        }
        #endregion
    }
}
