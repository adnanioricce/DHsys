using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Windows.DataMappings
{
    public partial class CaixaMap
        : IEntityTypeConfiguration<global::Core.Entities.Legacy.Caixa>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<global::Core.Entities.Legacy.Caixa> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("caixa", "public");

            // key
            builder.HasNoKey();

            // properties
            builder.Property(t => t.CxAtend)
                .HasColumnName("cx_atend")
                .HasColumnType("character varying(2)")
                .HasMaxLength(2);

            builder.Property(t => t.CxData)
                .HasColumnName("cx_data")
                .HasColumnType("date");

            builder.Property(t => t.CxValor)
                .HasColumnName("cx_valor")
                .HasColumnType("numeric(12,2)");

            builder.Property(t => t.CxRec)
                .HasColumnName("cx_rec")
                .HasColumnType("date");

            builder.Property(t => t.CxAdm)
                .HasColumnName("cx_adm")
                .HasColumnType("character varying(2)")
                .HasMaxLength(2);

            builder.Property(t => t.CxCart)
                .HasColumnName("cx_cart")
                .HasColumnType("numeric(12,2)");

            builder.Property(t => t.CxTipo)
                .HasColumnName("cx_tipo")
                .HasColumnType("character varying(2)")
                .HasMaxLength(2);

            // relationships
            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "public";
            public const string Name = "caixa";
        }

        public struct Columns
        {
            public const string CxAtend = "cx_atend";
            public const string CxData = "cx_data";
            public const string CxValor = "cx_valor";
            public const string CxRec = "cx_rec";
            public const string CxAdm = "cx_adm";
            public const string CxCart = "cx_cart";
            public const string CxTipo = "cx_tipo";
        }
        #endregion
    }
}
