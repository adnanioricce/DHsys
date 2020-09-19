using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Windows.DataMappings
{
    public partial class DebcliMap
        : IEntityTypeConfiguration<Legacy.Entities.Debcli>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Legacy.Entities.Debcli> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("debcli", "public");

            // key
            builder.HasNoKey();

            // properties
            builder.Property(t => t.Clcodi)
                .HasColumnName("clcodi")
                .HasColumnType("character varying(4)")
                .HasMaxLength(4);

            builder.Property(t => t.Bacodi)
                .HasColumnName("bacodi")
                .HasColumnType("character varying(3)")
                .HasMaxLength(3);

            builder.Property(t => t.Prcodi)
                .HasColumnName("prcodi")
                .HasColumnType("character varying(6)")
                .HasMaxLength(6);

            builder.Property(t => t.Cldata)
                .HasColumnName("cldata")
                .HasColumnType("date");

            builder.Property(t => t.Clqtde)
                .HasColumnName("clqtde")
                .HasColumnType("numeric(6,0)");

            builder.Property(t => t.Clpago)
                .HasColumnName("clpago")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.Cldesc)
                .HasColumnName("cldesc")
                .HasColumnType("numeric(5,2)");

            builder.Property(t => t.Cltick)
                .HasColumnName("cltick")
                .HasColumnType("character varying(6)")
                .HasMaxLength(6);

            builder.Property(t => t.Clbalc)
                .HasColumnName("clbalc")
                .HasColumnType("character varying(3)")
                .HasMaxLength(3);

            builder.Property(t => t.Clobs)
                .HasColumnName("clobs")
                .HasColumnType("character varying(30)")
                .HasMaxLength(30);

            builder.Property(t => t.Descomp)
                .HasColumnName("descomp")
                .HasColumnType("character varying(100)")
                .HasMaxLength(100);

            builder.Property(t => t.Comissao)
                .HasColumnName("comissao")
                .HasColumnType("numeric(12,2)");

            builder.Property(t => t.VlPago)
                .HasColumnName("vl_pago")
                .HasColumnType("numeric(12,2)");

            builder.Property(t => t.DtPagto)
                .HasColumnName("dt_pagto")
                .HasColumnType("date");

            // relationships
            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "public";
            public const string Name = "debcli";
        }

        public struct Columns
        {
            public const string Clcodi = "clcodi";
            public const string Bacodi = "bacodi";
            public const string Prcodi = "prcodi";
            public const string Cldata = "cldata";
            public const string Clqtde = "clqtde";
            public const string Clpago = "clpago";
            public const string Cldesc = "cldesc";
            public const string Cltick = "cltick";
            public const string Clbalc = "clbalc";
            public const string Clobs = "clobs";
            public const string Descomp = "descomp";
            public const string Comissao = "comissao";
            public const string VlPago = "vl_pago";
            public const string DtPagto = "dt_pagto";
        }
        #endregion
    }
}
