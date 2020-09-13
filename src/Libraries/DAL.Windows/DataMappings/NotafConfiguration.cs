using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Windows.DataMappings
{
    public partial class NotafMap
        : IEntityTypeConfiguration<global::Core.Entities.Legacy.Notaf>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<global::Core.Entities.Legacy.Notaf> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("notaf", "public");

            // key
            builder.HasNoKey();

            // properties
            builder.Property(t => t.NumNota)
                .HasColumnName("num_nota")
                .HasColumnType("character varying(6)")
                .HasMaxLength(6);

            // relationships
            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "public";
            public const string Name = "notaf";
        }

        public struct Columns
        {
            public const string NumNota = "num_nota";
        }
        #endregion
    }
}
