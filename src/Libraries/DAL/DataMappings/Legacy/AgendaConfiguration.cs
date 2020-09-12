using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Mappings.Legacy
{
    public partial class AgendaMap
        : IEntityTypeConfiguration<global::Core.Entities.Legacy.Agenda>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<global::Core.Entities.Legacy.Agenda> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("agenda", "public");

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
                .HasColumnType("character varying(20)")
                .HasMaxLength(20);

            // relationships
            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "public";
            public const string Name = "agenda";
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
        }
        #endregion
    }
}
