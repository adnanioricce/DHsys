using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Windows.DataMappings
{
    public partial class ResAnoMap
        : IEntityTypeConfiguration<global::Core.Entities.Legacy.ResAno>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<global::Core.Entities.Legacy.ResAno> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("res_ano", "public");

            // key
            builder.HasNoKey();

            // properties
            builder.Property(t => t.MesRef)
                .HasColumnName("mes_ref")
                .HasColumnType("character varying(5)")
                .HasMaxLength(5);

            builder.Property(t => t.CliAtds)
                .HasColumnName("cli_atds")
                .HasColumnType("numeric(6,0)");

            builder.Property(t => t.VenMes)
                .HasColumnName("ven_mes")
                .HasColumnType("numeric(15,2)");

            builder.Property(t => t.TotEstoq)
                .HasColumnName("tot_estoq")
                .HasColumnType("numeric(15,2)");

            builder.Property(t => t.Diastrab)
                .HasColumnName("diastrab")
                .HasColumnType("numeric(2,0)");

            builder.Property(t => t.Entradas)
                .HasColumnName("entradas")
                .HasColumnType("numeric(12,2)");

            builder.Property(t => t.Descrec)
                .HasColumnName("descrec")
                .HasColumnType("numeric(12,2)");

            builder.Property(t => t.VenFiado)
                .HasColumnName("ven_fiado")
                .HasColumnType("numeric(12,2)");

            builder.Property(t => t.RecFiado)
                .HasColumnName("rec_fiado")
                .HasColumnType("numeric(12,2)");

            builder.Property(t => t.VdaVista)
                .HasColumnName("vda_vista")
                .HasColumnType("numeric(12,2)");

            builder.Property(t => t.VdaConv)
                .HasColumnName("vda_conv")
                .HasColumnType("numeric(12,2)");

            // relationships
            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "public";
            public const string Name = "res_ano";
        }

        public struct Columns
        {
            public const string MesRef = "mes_ref";
            public const string CliAtds = "cli_atds";
            public const string VenMes = "ven_mes";
            public const string TotEstoq = "tot_estoq";
            public const string Diastrab = "diastrab";
            public const string Entradas = "entradas";
            public const string Descrec = "descrec";
            public const string VenFiado = "ven_fiado";
            public const string RecFiado = "rec_fiado";
            public const string VdaVista = "vda_vista";
            public const string VdaConv = "vda_conv";
        }
        #endregion
    }
}
