using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Windows.DataMappings
{
    public partial class TempMap
        : IEntityTypeConfiguration<global::Core.Entities.Legacy.Temp>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<global::Core.Entities.Legacy.Temp> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("temp", "public");

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

            builder.Property(t => t.Prcons)
                .HasColumnName("prcons")
                .HasColumnType("numeric(12,2)");

            builder.Property(t => t.Desconto)
                .HasColumnName("desconto")
                .HasColumnType("numeric(5,2)");

            builder.Property(t => t.Prconsd)
                .HasColumnName("prconsd")
                .HasColumnType("numeric(12,2)");

            builder.Property(t => t.VlTotal)
                .HasColumnName("vl_total")
                .HasColumnType("numeric(12,2)");

            builder.Property(t => t.Qtde)
                .HasColumnName("qtde")
                .HasColumnType("numeric(6,0)");

            // relationships
            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "public";
            public const string Name = "temp";
        }

        public struct Columns
        {
            public const string Prcodi = "prcodi";
            public const string Descricao = "descricao";
            public const string Prcons = "prcons";
            public const string Desconto = "desconto";
            public const string Prconsd = "prconsd";
            public const string VlTotal = "vl_total";
            public const string Qtde = "qtde";
        }
        #endregion
    }
}
