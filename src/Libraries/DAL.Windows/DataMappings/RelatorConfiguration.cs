using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Windows.DataMappings
{
    public partial class RelatorMap
        : IEntityTypeConfiguration<global::Core.Entities.Legacy.Relator>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<global::Core.Entities.Legacy.Relator> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("relator", "public");

            // key
            builder.HasNoKey();

            // properties
            builder.Property(t => t.Relatorio)
                .HasColumnName("relatorio")
                .HasColumnType("character varying(40)")
                .HasMaxLength(40);

            builder.Property(t => t.Nivel)
                .HasColumnName("nivel")
                .HasColumnType("character varying(2)")
                .HasMaxLength(2);

            // relationships
            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "public";
            public const string Name = "relator";
        }

        public struct Columns
        {
            public const string Relatorio = "relatorio";
            public const string Nivel = "nivel";
        }
        #endregion
    }
}
