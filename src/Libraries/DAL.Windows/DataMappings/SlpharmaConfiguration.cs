using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Windows.DataMappings
{
    public partial class SlpharmaMap
        : IEntityTypeConfiguration<Legacy.Entities.Slpharma>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Legacy.Entities.Slpharma> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("slpharma", "public");

            // key
            builder.HasNoKey();

            // properties
            builder.Property(t => t.Reconst)
                .HasColumnName("reconst")
                .HasColumnType("character varying(50)")
                .HasMaxLength(50);

            // relationships
            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "public";
            public const string Name = "slpharma";
        }

        public struct Columns
        {
            public const string Reconst = "reconst";
        }
        #endregion
    }
}
