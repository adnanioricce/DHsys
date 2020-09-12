using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Mappings.Legacy
{
    public partial class ReducaoMap
        : IEntityTypeConfiguration<global::Core.Entities.Legacy.Reducao>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<global::Core.Entities.Legacy.Reducao> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("reducao", "public");

            // key
            builder.HasNoKey();

            // properties
            builder.Property(t => t.Rzaut)
                .HasColumnName("rzaut")
                .HasColumnType("character varying(2)")
                .HasMaxLength(2);

            builder.Property(t => t.Gtda)
                .HasColumnName("gtda")
                .HasColumnType("character varying(18)")
                .HasMaxLength(18);

            builder.Property(t => t.Cancela)
                .HasColumnName("cancela")
                .HasColumnType("character varying(14)")
                .HasMaxLength(14);

            builder.Property(t => t.Desconto)
                .HasColumnName("desconto")
                .HasColumnType("character varying(14)")
                .HasMaxLength(14);

            builder.Property(t => t.Tributo)
                .HasColumnName("tributo")
                .HasColumnType("character varying(64)")
                .HasMaxLength(64);

            builder.Property(t => t.Supri)
                .HasColumnName("supri")
                .HasColumnType("character varying(14)")
                .HasMaxLength(14);

            builder.Property(t => t.Nsi)
                .HasColumnName("nsi")
                .HasColumnType("character varying(126)")
                .HasMaxLength(126);

            builder.Property(t => t.Cnsi)
                .HasColumnName("cnsi")
                .HasColumnType("character varying(36)")
                .HasMaxLength(36);

            builder.Property(t => t.Coo)
                .HasColumnName("coo")
                .HasColumnType("character varying(6)")
                .HasMaxLength(6);

            builder.Property(t => t.Cns)
                .HasColumnName("cns")
                .HasColumnType("character varying(6)")
                .HasMaxLength(6);

            builder.Property(t => t.Aliquota)
                .HasColumnName("aliquota")
                .HasColumnType("character varying(2)")
                .HasMaxLength(2);

            builder.Property(t => t.Data)
                .HasColumnName("data")
                .HasColumnType("character varying(6)")
                .HasMaxLength(6);

            builder.Property(t => t.Acresc)
                .HasColumnName("acresc")
                .HasColumnType("character varying(14)")
                .HasMaxLength(14);

            builder.Property(t => t.Acresfin)
                .HasColumnName("acresfin")
                .HasColumnType("character varying(14)")
                .HasMaxLength(14);

            builder.Property(t => t.Sangria)
                .HasColumnName("sangria")
                .HasColumnType("character varying(10)")
                .HasMaxLength(10);

            // relationships
            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "public";
            public const string Name = "reducao";
        }

        public struct Columns
        {
            public const string Rzaut = "rzaut";
            public const string Gtda = "gtda";
            public const string Cancela = "cancela";
            public const string Desconto = "desconto";
            public const string Tributo = "tributo";
            public const string Supri = "supri";
            public const string Nsi = "nsi";
            public const string Cnsi = "cnsi";
            public const string Coo = "coo";
            public const string Cns = "cns";
            public const string Aliquota = "aliquota";
            public const string Data = "data";
            public const string Acresc = "acresc";
            public const string Acresfin = "acresfin";
            public const string Sangria = "sangria";
        }
        #endregion
    }
}
