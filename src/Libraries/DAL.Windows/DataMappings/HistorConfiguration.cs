using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Windows.DataMappings
{
    public partial class HistorMap
        : IEntityTypeConfiguration<global::Core.Entities.Legacy.Histor>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<global::Core.Entities.Legacy.Histor> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("histor", "public");

            // key
            builder.HasNoKey();

            // properties
            builder.Property(t => t.Distrib)
                .HasColumnName("distrib")
                .HasColumnType("character varying(3)")
                .HasMaxLength(3);

            builder.Property(t => t.Notafis)
                .HasColumnName("notafis")
                .HasColumnType("character varying(6)")
                .HasMaxLength(6);

            builder.Property(t => t.Vencto)
                .HasColumnName("vencto")
                .HasColumnType("date");

            builder.Property(t => t.Recebto)
                .HasColumnName("recebto")
                .HasColumnType("date");

            builder.Property(t => t.Pedido)
                .HasColumnName("pedido")
                .HasColumnType("character varying(8)")
                .HasMaxLength(8);

            builder.Property(t => t.Total)
                .HasColumnName("total")
                .HasColumnType("numeric(12,2)");

            builder.Property(t => t.Desconto)
                .HasColumnName("desconto")
                .HasColumnType("numeric(12,2)");

            // relationships
            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "public";
            public const string Name = "histor";
        }

        public struct Columns
        {
            public const string Distrib = "distrib";
            public const string Notafis = "notafis";
            public const string Vencto = "vencto";
            public const string Recebto = "recebto";
            public const string Pedido = "pedido";
            public const string Total = "total";
            public const string Desconto = "desconto";
        }
        #endregion
    }
}
