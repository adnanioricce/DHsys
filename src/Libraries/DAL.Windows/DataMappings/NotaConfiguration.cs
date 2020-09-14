using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Windows.DataMappings
{
    public partial class NotaMap
        : IEntityTypeConfiguration<global::Core.Entities.Legacy.Nota>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<global::Core.Entities.Legacy.Nota> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("nota", "public");

            // key
            builder.HasNoKey();

            // properties
            builder.Property(t => t.NFiscal)
                .HasColumnName("n_fiscal")
                .HasColumnType("character varying(8)")
                .HasMaxLength(8);

            builder.Property(t => t.Cliente)
                .HasColumnName("cliente")
                .HasColumnType("character varying(4)")
                .HasMaxLength(4);

            builder.Property(t => t.Nvalor)
                .HasColumnName("nvalor")
                .HasColumnType("numeric(12,2)");

            builder.Property(t => t.Base)
                .HasColumnName("base")
                .HasColumnType("numeric(12,2)");

            builder.Property(t => t.Icms)
                .HasColumnName("icms")
                .HasColumnType("numeric(12,2)");

            builder.Property(t => t.Basesub)
                .HasColumnName("basesub")
                .HasColumnType("numeric(12,2)");

            builder.Property(t => t.Icmssub)
                .HasColumnName("icmssub")
                .HasColumnType("numeric(12,2)");

            builder.Property(t => t.Nbase7)
                .HasColumnName("nbase7")
                .HasColumnType("numeric(12,2)");

            builder.Property(t => t.Nicms7)
                .HasColumnName("nicms7")
                .HasColumnType("numeric(12,2)");

            builder.Property(t => t.Nbase12)
                .HasColumnName("nbase12")
                .HasColumnType("numeric(12,2)");

            builder.Property(t => t.Nicms12)
                .HasColumnName("nicms12")
                .HasColumnType("numeric(12,2)");

            builder.Property(t => t.Nbase18)
                .HasColumnName("nbase18")
                .HasColumnType("numeric(12,2)");

            builder.Property(t => t.Nicms18)
                .HasColumnName("nicms18")
                .HasColumnType("numeric(12,2)");

            builder.Property(t => t.Nbase25)
                .HasColumnName("nbase25")
                .HasColumnType("numeric(12,2)");

            builder.Property(t => t.Nicms25)
                .HasColumnName("nicms25")
                .HasColumnType("numeric(12,2)");

            builder.Property(t => t.Natureza)
                .HasColumnName("natureza")
                .HasColumnType("character varying(4)")
                .HasMaxLength(4);

            builder.Property(t => t.NNatu)
                .HasColumnName("n_natu")
                .HasColumnType("character varying(25)")
                .HasMaxLength(25);

            builder.Property(t => t.Ndata)
                .HasColumnName("ndata")
                .HasColumnType("date");

            builder.Property(t => t.Ncancelada)
                .HasColumnName("ncancelada")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            // relationships
            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "public";
            public const string Name = "nota";
        }

        public struct Columns
        {
            public const string nFiscal = "n_fiscal";
            public const string Cliente = "cliente";
            public const string Nvalor = "nvalor";
            public const string Base = "base";
            public const string Icms = "icms";
            public const string Basesub = "basesub";
            public const string Icmssub = "icmssub";
            public const string Nbase7 = "nbase7";
            public const string Nicms7 = "nicms7";
            public const string Nbase12 = "nbase12";
            public const string Nicms12 = "nicms12";
            public const string Nbase18 = "nbase18";
            public const string Nicms18 = "nicms18";
            public const string Nbase25 = "nbase25";
            public const string Nicms25 = "nicms25";
            public const string Natureza = "natureza";
            public const string nNatu = "n_natu";
            public const string Ndata = "ndata";
            public const string Ncancelada = "ncancelada";
        }
        #endregion
    }
}
