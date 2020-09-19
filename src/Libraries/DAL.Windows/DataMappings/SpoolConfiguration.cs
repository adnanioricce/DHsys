using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Windows.DataMappings
{
    public partial class SpoolMap
        : IEntityTypeConfiguration<Legacy.Entities.Spool>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Legacy.Entities.Spool> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("spool", "public");

            // key
            builder.HasNoKey();

            // properties
            builder.Property(t => t.Arquivo)
                .HasColumnName("arquivo")
                .HasColumnType("character varying(8)")
                .HasMaxLength(8);

            builder.Property(t => t.Descr)
                .HasColumnName("descr")
                .HasColumnType("character varying(40)")
                .HasMaxLength(40);

            builder.Property(t => t.Data)
                .HasColumnName("data")
                .HasColumnType("date");

            builder.Property(t => t.Nivel)
                .HasColumnName("nivel")
                .HasColumnType("character varying(2)")
                .HasMaxLength(2);

            builder.Property(t => t.Hora)
                .HasColumnName("hora")
                .HasColumnType("character varying(5)")
                .HasMaxLength(5);

            // relationships
            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "public";
            public const string Name = "spool";
        }

        public struct Columns
        {
            public const string Arquivo = "arquivo";
            public const string Descr = "descr";
            public const string Data = "data";
            public const string Nivel = "nivel";
            public const string Hora = "hora";
        }
        #endregion
    }
}
