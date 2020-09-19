using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Windows.DataMappings
{
    public partial class NewtabMap
        : IEntityTypeConfiguration<Legacy.Entities.Newtab>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Legacy.Entities.Newtab> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("newtab", "public");

            // key
            builder.HasNoKey();

            // properties
            builder.Property(t => t.Newtab1)
                .HasColumnName("newtab")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.Mesano)
                .HasColumnName("mesano")
                .HasColumnType("character varying(5)")
                .HasMaxLength(5);

            // relationships
            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "public";
            public const string Name = "newtab";
        }

        public struct Columns
        {
            public const string NewtabMember = "newtab";
            public const string Mesano = "mesano";
        }
        #endregion
    }
}
