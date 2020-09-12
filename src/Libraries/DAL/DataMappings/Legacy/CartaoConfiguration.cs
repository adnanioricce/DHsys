using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Mappings.Legacy
{
    public partial class CartaoMap
        : IEntityTypeConfiguration<global::Core.Entities.Legacy.Cartao>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<global::Core.Entities.Legacy.Cartao> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("cartao", "public");

            // key
            builder.HasNoKey();

            // properties
            builder.Property(t => t.Codigo)
                .HasColumnName("codigo")
                .HasColumnType("character varying(2)")
                .HasMaxLength(2);

            builder.Property(t => t.Nome)
                .HasColumnName("nome")
                .HasColumnType("character varying(15)")
                .HasMaxLength(15);

            builder.Property(t => t.Prazo)
                .HasColumnName("prazo")
                .HasColumnType("character varying(2)")
                .HasMaxLength(2);

            builder.Property(t => t.Parcel)
                .HasColumnName("parcel")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.Qtde)
                .HasColumnName("qtde")
                .HasColumnType("numeric(1,0)");

            builder.Property(t => t.Taxa)
                .HasColumnName("taxa")
                .HasColumnType("numeric(5,2)");

            // relationships
            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "public";
            public const string Name = "cartao";
        }

        public struct Columns
        {
            public const string Codigo = "codigo";
            public const string Nome = "nome";
            public const string Prazo = "prazo";
            public const string Parcel = "parcel";
            public const string Qtde = "qtde";
            public const string Taxa = "taxa";
        }
        #endregion
    }
}
