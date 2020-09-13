using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Windows.DataMappings
{
    public partial class PedidosMap
        : IEntityTypeConfiguration<global::Core.Entities.Legacy.Pedidos>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<global::Core.Entities.Legacy.Pedidos> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("pedidos", "public");

            // key
            builder.HasNoKey();

            // properties
            builder.Property(t => t.Prcodi)
                .HasColumnName("prcodi")
                .HasColumnType("character varying(6)")
                .HasMaxLength(6);

            builder.Property(t => t.Prqtde)
                .HasColumnName("prqtde")
                .HasColumnType("numeric(6,0)");

            builder.Property(t => t.Prcdla)
                .HasColumnName("prcdla")
                .HasColumnType("character varying(4)")
                .HasMaxLength(4);

            builder.Property(t => t.Prfabr)
                .HasColumnName("prfabr")
                .HasColumnType("numeric(12,2)");

            builder.Property(t => t.Status)
                .HasColumnName("status")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.Prdata)
                .HasColumnName("prdata")
                .HasColumnType("date");

            // relationships
            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "public";
            public const string Name = "pedidos";
        }

        public struct Columns
        {
            public const string Prcodi = "prcodi";
            public const string Prqtde = "prqtde";
            public const string Prcdla = "prcdla";
            public const string Prfabr = "prfabr";
            public const string Status = "status";
            public const string Prdata = "prdata";
        }
        #endregion
    }
}
