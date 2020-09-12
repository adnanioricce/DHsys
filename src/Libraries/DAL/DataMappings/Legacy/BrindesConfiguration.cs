using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Mappings.Legacy
{
    public partial class BrindesMap
        : IEntityTypeConfiguration<global::Core.Entities.Legacy.Brindes>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<global::Core.Entities.Legacy.Brindes> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("brindes", "public");

            // key
            builder.HasNoKey();

            // properties
            builder.Property(t => t.Codigo)
                .HasColumnName("codigo")
                .HasColumnType("character varying(4)")
                .HasMaxLength(4);

            builder.Property(t => t.Nome)
                .HasColumnName("nome")
                .HasColumnType("character varying(30)")
                .HasMaxLength(30);

            builder.Property(t => t.Pontos)
                .HasColumnName("pontos")
                .HasColumnType("numeric(4,0)");

            builder.Property(t => t.Qtde)
                .HasColumnName("qtde")
                .HasColumnType("numeric(4,0)");

            // relationships
            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "public";
            public const string Name = "brindes";
        }

        public struct Columns
        {
            public const string Codigo = "codigo";
            public const string Nome = "nome";
            public const string Pontos = "pontos";
            public const string Qtde = "qtde";
        }
        #endregion
    }
}
