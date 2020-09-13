using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Windows.DataMappings
{
    public partial class ConvMap
        : IEntityTypeConfiguration<global::Core.Entities.Legacy.Conv>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<global::Core.Entities.Legacy.Conv> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("conv", "public");

            // key
            builder.HasNoKey();

            // properties
            builder.Property(t => t.Fucdem)
                .HasColumnName("fucdem")
                .HasColumnType("character varying(3)")
                .HasMaxLength(3);

            builder.Property(t => t.Fucodi)
                .HasColumnName("fucodi")
                .HasColumnType("character varying(18)")
                .HasMaxLength(18);

            builder.Property(t => t.Cvnota)
                .HasColumnName("cvnota")
                .HasColumnType("character varying(6)")
                .HasMaxLength(6);

            builder.Property(t => t.Cvbalc)
                .HasColumnName("cvbalc")
                .HasColumnType("character varying(3)")
                .HasMaxLength(3);

            builder.Property(t => t.Cvdata)
                .HasColumnName("cvdata")
                .HasColumnType("date");

            builder.Property(t => t.Cvvalourv)
                .HasColumnName("cvvalourv")
                .HasColumnType("numeric(12,2)");

            builder.Property(t => t.Cvobsv)
                .HasColumnName("cvobsv")
                .HasColumnType("character varying(10)")
                .HasMaxLength(10);

            builder.Property(t => t.Cvtick)
                .HasColumnName("cvtick")
                .HasColumnType("character varying(6)")
                .HasMaxLength(6);

            builder.Property(t => t.Cvreceita)
                .HasColumnName("cvreceita")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.Cvdtrec)
                .HasColumnName("cvdtrec")
                .HasColumnType("date");

            builder.Property(t => t.Cvpsuso)
                .HasColumnName("cvpsuso")
                .HasColumnType("character varying(2)")
                .HasMaxLength(2);

            builder.Property(t => t.Cventrega)
                .HasColumnName("cventrega")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.Cvvalocrz)
                .HasColumnName("cvvalocrz")
                .HasColumnType("numeric(12,2)");

            builder.Property(t => t.Cvcomissao)
                .HasColumnName("cvcomissao")
                .HasColumnType("numeric(12,2)");

            builder.Property(t => t.Cvlibcom)
                .HasColumnName("cvlibcom")
                .HasColumnType("date");

            builder.Property(t => t.Cvfilial)
                .HasColumnName("cvfilial")
                .HasColumnType("character varying(3)")
                .HasMaxLength(3);

            builder.Property(t => t.Cvtitular)
                .HasColumnName("cvtitular")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            // relationships
            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "public";
            public const string Name = "conv";
        }

        public struct Columns
        {
            public const string Fucdem = "fucdem";
            public const string Fucodi = "fucodi";
            public const string Cvnota = "cvnota";
            public const string Cvbalc = "cvbalc";
            public const string Cvdata = "cvdata";
            public const string Cvvalourv = "cvvalourv";
            public const string Cvobsv = "cvobsv";
            public const string Cvtick = "cvtick";
            public const string Cvreceita = "cvreceita";
            public const string Cvdtrec = "cvdtrec";
            public const string Cvpsuso = "cvpsuso";
            public const string Cventrega = "cventrega";
            public const string Cvvalocrz = "cvvalocrz";
            public const string Cvcomissao = "cvcomissao";
            public const string Cvlibcom = "cvlibcom";
            public const string Cvfilial = "cvfilial";
            public const string Cvtitular = "cvtitular";
        }
        #endregion
    }
}
