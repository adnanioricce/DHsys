using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Windows.DataMappings
{
    public partial class CdespMap
        : IEntityTypeConfiguration<global::Core.Entities.Legacy.Cdesp>
    {
        public void Configure(EntityTypeBuilder<global::Core.Entities.Legacy.Cdesp> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("cdesp", "public");

            // key
            builder.HasNoKey();

            // properties
            builder.Property(t => t.Cont)
                .HasColumnName("cont")
                .HasColumnType("character varying(4)")
                .HasMaxLength(4);

            builder.Property(t => t.Valor)
                .HasColumnName("valor")
                .HasColumnType("numeric(9,2)");

            builder.Property(t => t.Dtvenc)
                .HasColumnName("dtvenc")
                .HasColumnType("date");

            builder.Property(t => t.Dtpag)
                .HasColumnName("dtpag")
                .HasColumnType("date");

            builder.Property(t => t.Vlpag)
                .HasColumnName("vlpag")
                .HasColumnType("numeric(9,2)");

            builder.Property(t => t.Doc)
                .HasColumnName("doc")
                .HasColumnType("character varying(6)")
                .HasMaxLength(6);

            builder.Property(t => t.Jurper)
                .HasColumnName("jurper")
                .HasColumnType("numeric(5,2)");

            builder.Property(t => t.Jurdin)
                .HasColumnName("jurdin")
                .HasColumnType("numeric(10,2)");

            builder.Property(t => t.Multa)
                .HasColumnName("multa")
                .HasColumnType("numeric(10,2)");

            builder.Property(t => t.Desc)
                .HasColumnName("desc")
                .HasColumnType("numeric(10,2)");

            builder.Property(t => t.Dtdesc)
                .HasColumnName("dtdesc")
                .HasColumnType("date");

            builder.Property(t => t.Chpag)
                .HasColumnName("chpag")
                .HasColumnType("character varying(12)")
                .HasMaxLength(12);

            builder.Property(t => t.Banco)
                .HasColumnName("banco")
                .HasColumnType("character varying(3)")
                .HasMaxLength(3);

            // relationships
            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "public";
            public const string Name = "cdesp";
        }

        public struct Columns
        {
            public const string Cont = "cont";
            public const string Valor = "valor";
            public const string Dtvenc = "dtvenc";
            public const string Dtpag = "dtpag";
            public const string Vlpag = "vlpag";
            public const string Doc = "doc";
            public const string Jurper = "jurper";
            public const string Jurdin = "jurdin";
            public const string Multa = "multa";
            public const string Desc = "desc";
            public const string Dtdesc = "dtdesc";
            public const string Chpag = "chpag";
            public const string Banco = "banco";
        }
        #endregion
    }
}
