using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Windows.DataMappings
{
    public partial class Ped0204Map
        : IEntityTypeConfiguration<global::Core.Entities.Legacy.Ped0204>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<global::Core.Entities.Legacy.Ped0204> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("ped0204", "public");

            // key
            builder.HasNoKey();

            // properties
            builder.Property(t => t.Prcodi)
                .HasColumnName("prcodi")
                .HasColumnType("character varying(6)")
                .HasMaxLength(6);

            builder.Property(t => t.Prbarra)
                .HasColumnName("prbarra")
                .HasColumnType("character varying(13)")
                .HasMaxLength(13);

            builder.Property(t => t.Prdesc)
                .HasColumnName("prdesc")
                .HasColumnType("character varying(30)")
                .HasMaxLength(30);

            builder.Property(t => t.Codint)
                .HasColumnName("codint")
                .HasColumnType("character varying(10)")
                .HasMaxLength(10);

            builder.Property(t => t.Mloja1)
                .HasColumnName("mloja1")
                .HasColumnType("numeric(6,0)");

            builder.Property(t => t.Eloja1)
                .HasColumnName("eloja1")
                .HasColumnType("numeric(6,0)");

            builder.Property(t => t.Nloja1)
                .HasColumnName("nloja1")
                .HasColumnType("numeric(6,0)");

            builder.Property(t => t.Mloja2)
                .HasColumnName("mloja2")
                .HasColumnType("numeric(6,0)");

            builder.Property(t => t.Eloja2)
                .HasColumnName("eloja2")
                .HasColumnType("numeric(6,0)");

            builder.Property(t => t.Nloja2)
                .HasColumnName("nloja2")
                .HasColumnType("numeric(6,0)");

            builder.Property(t => t.Mloja3)
                .HasColumnName("mloja3")
                .HasColumnType("numeric(6,0)");

            builder.Property(t => t.Eloja3)
                .HasColumnName("eloja3")
                .HasColumnType("numeric(6,0)");

            builder.Property(t => t.Nloja3)
                .HasColumnName("nloja3")
                .HasColumnType("numeric(6,0)");

            builder.Property(t => t.Mloja4)
                .HasColumnName("mloja4")
                .HasColumnType("numeric(6,0)");

            builder.Property(t => t.Eloja4)
                .HasColumnName("eloja4")
                .HasColumnType("numeric(6,0)");

            builder.Property(t => t.Nloja4)
                .HasColumnName("nloja4")
                .HasColumnType("numeric(6,0)");

            builder.Property(t => t.Valor)
                .HasColumnName("valor")
                .HasColumnType("numeric(10,2)");

            builder.Property(t => t.Forn)
                .HasColumnName("forn")
                .HasColumnType("character varying(4)")
                .HasMaxLength(4);

            // relationships
            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "public";
            public const string Name = "ped0204";
        }

        public struct Columns
        {
            public const string Prcodi = "prcodi";
            public const string Prbarra = "prbarra";
            public const string Prdesc = "prdesc";
            public const string Codint = "codint";
            public const string Mloja1 = "mloja1";
            public const string Eloja1 = "eloja1";
            public const string Nloja1 = "nloja1";
            public const string Mloja2 = "mloja2";
            public const string Eloja2 = "eloja2";
            public const string Nloja2 = "nloja2";
            public const string Mloja3 = "mloja3";
            public const string Eloja3 = "eloja3";
            public const string Nloja3 = "nloja3";
            public const string Mloja4 = "mloja4";
            public const string Eloja4 = "eloja4";
            public const string Nloja4 = "nloja4";
            public const string Valor = "valor";
            public const string Forn = "forn";
        }
        #endregion
    }
}
