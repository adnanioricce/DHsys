using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Windows.DataMappings
{
    public partial class Troco3Map
        : IEntityTypeConfiguration<global::Core.Entities.Legacy.Troco3>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<global::Core.Entities.Legacy.Troco3> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("troco3", "public");

            // key
            builder.HasNoKey();

            // properties
            builder.Property(t => t.TrocoIni)
                .HasColumnName("troco_ini")
                .HasColumnType("numeric(12,2)");

            builder.Property(t => t.Initroco)
                .HasColumnName("initroco")
                .HasColumnType("boolean");

            builder.Property(t => t.Data)
                .HasColumnName("data")
                .HasColumnType("date");

            // relationships
            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "public";
            public const string Name = "troco3";
        }

        public struct Columns
        {
            public const string TrocoIni = "troco_ini";
            public const string Initroco = "initroco";
            public const string Data = "data";
        }
        #endregion
    }
}
