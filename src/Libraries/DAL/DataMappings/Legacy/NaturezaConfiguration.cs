using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Mappings.Legacy
{
    public partial class NaturezaMap
        : IEntityTypeConfiguration<global::Core.Entities.Legacy.Natureza>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<global::Core.Entities.Legacy.Natureza> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("natureza", "public");

            // key
            builder.HasNoKey();

            // properties
            builder.Property(t => t.Codigo)
                .HasColumnName("codigo")
                .HasColumnType("character varying(4)")
                .HasMaxLength(4);

            builder.Property(t => t.Nome)
                .HasColumnName("nome")
                .HasColumnType("character varying(25)")
                .HasMaxLength(25);

            // relationships
            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "public";
            public const string Name = "natureza";
        }

        public struct Columns
        {
            public const string Codigo = "codigo";
            public const string Nome = "nome";
        }
        #endregion
    }
}
