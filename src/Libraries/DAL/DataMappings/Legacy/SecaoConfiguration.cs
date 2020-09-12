using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Mappings.Legacy
{
    public partial class SecaoMap
        : IEntityTypeConfiguration<global::Core.Entities.Legacy.Secao>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<global::Core.Entities.Legacy.Secao> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("secao", "public");

            // key
            builder.HasNoKey();

            // properties
            builder.Property(t => t.Secodi)
                .HasColumnName("secodi")
                .HasColumnType("character varying(2)")
                .HasMaxLength(2);

            builder.Property(t => t.Senome)
                .HasColumnName("senome")
                .HasColumnType("character varying(15)")
                .HasMaxLength(15);

            // relationships
            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "public";
            public const string Name = "secao";
        }

        public struct Columns
        {
            public const string Secodi = "secodi";
            public const string Senome = "senome";
        }
        #endregion
    }
}
