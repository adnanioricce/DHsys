using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Mappings.Legacy
{
    public partial class TempoMap
        : IEntityTypeConfiguration<global::Core.Entities.Legacy.Tempo>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<global::Core.Entities.Legacy.Tempo> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("tempo", "public");

            // key
            builder.HasNoKey();

            // properties
            builder.Property(t => t.Prcodi)
                .HasColumnName("prcodi")
                .HasColumnType("character varying(6)")
                .HasMaxLength(6);

            builder.Property(t => t.Descricao)
                .HasColumnName("descricao")
                .HasColumnType("character varying(30)")
                .HasMaxLength(30);

            builder.Property(t => t.Qtde)
                .HasColumnName("qtde")
                .HasColumnType("numeric(6,0)");

            builder.Property(t => t.Prcons)
                .HasColumnName("prcons")
                .HasColumnType("numeric(12,2)");

            builder.Property(t => t.Desconto)
                .HasColumnName("desconto")
                .HasColumnType("numeric(5,2)");

            builder.Property(t => t.Estoque)
                .HasColumnName("estoque")
                .HasColumnType("numeric(4,0)");

            builder.Property(t => t.Pedido)
                .HasColumnName("pedido")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.Prconsd)
                .HasColumnName("prconsd")
                .HasColumnType("numeric(12,4)");

            builder.Property(t => t.VlTotal)
                .HasColumnName("vl_total")
                .HasColumnType("numeric(12,2)");

            // relationships
            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "public";
            public const string Name = "tempo";
        }

        public struct Columns
        {
            public const string Prcodi = "prcodi";
            public const string Descricao = "descricao";
            public const string Qtde = "qtde";
            public const string Prcons = "prcons";
            public const string Desconto = "desconto";
            public const string Estoque = "estoque";
            public const string Pedido = "pedido";
            public const string Prconsd = "prconsd";
            public const string VlTotal = "vl_total";
        }
        #endregion
    }
}
