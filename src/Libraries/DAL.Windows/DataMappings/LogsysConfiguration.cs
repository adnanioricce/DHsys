using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Windows.DataMappings
{
    public partial class LogsysMap
        : IEntityTypeConfiguration<Legacy.Entities.Logsys>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Legacy.Entities.Logsys> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("logsys", "public");

            // key
            builder.HasNoKey();

            // properties
            builder.Property(t => t.Data)
                .HasColumnName("data")
                .HasColumnType("date");

            builder.Property(t => t.Usuario)
                .HasColumnName("usuario")
                .HasColumnType("character varying(10)")
                .HasMaxLength(10);

            builder.Property(t => t.Time)
                .HasColumnName("time")
                .HasColumnType("character varying(5)")
                .HasMaxLength(5);

            builder.Property(t => t.Nivel)
                .HasColumnName("nivel")
                .HasColumnType("character varying(3)")
                .HasMaxLength(3);

            builder.Property(t => t.Opcao)
                .HasColumnName("opcao")
                .HasColumnType("character varying(25)")
                .HasMaxLength(25);

            // relationships
            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "public";
            public const string Name = "logsys";
        }

        public struct Columns
        {
            public const string Data = "data";
            public const string Usuario = "usuario";
            public const string Time = "time";
            public const string Nivel = "nivel";
            public const string Opcao = "opcao";
        }
        #endregion
    }
}
