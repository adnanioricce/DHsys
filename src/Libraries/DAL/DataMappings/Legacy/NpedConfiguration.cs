using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Mappings.Legacy
{
    public partial class NpedMap
        : IEntityTypeConfiguration<global::Core.Entities.Legacy.Nped>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<global::Core.Entities.Legacy.Nped> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("nped", "public");

            // key
            builder.HasNoKey();

            // properties
            builder.Property(t => t.Numped)
                .HasColumnName("numped")
                .HasColumnType("character varying(5)")
                .HasMaxLength(5);

            // relationships
            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "public";
            public const string Name = "nped";
        }

        public struct Columns
        {
            public const string Numped = "numped";
        }
        #endregion
    }
}
