using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Mappings.Legacy
{
    public partial class SalMap
        : IEntityTypeConfiguration<global::Core.Entities.Legacy.Sal>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<global::Core.Entities.Legacy.Sal> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("sal", "public");

            // key
            builder.HasNoKey();

            // properties
            builder.Property(t => t.Salcod)
                .HasColumnName("salcod")
                .HasColumnType("character varying(4)")
                .HasMaxLength(4);

            builder.Property(t => t.Salnome)
                .HasColumnName("salnome")
                .HasColumnType("character varying(50)")
                .HasMaxLength(50);

            // relationships
            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "public";
            public const string Name = "sal";
        }

        public struct Columns
        {
            public const string Salcod = "salcod";
            public const string Salnome = "salnome";
        }
        #endregion
    }
}
