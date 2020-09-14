using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Windows.DataMappings
{
    public partial class NumTmpMap
        : IEntityTypeConfiguration<global::Core.Entities.Legacy.NumTmp>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<global::Core.Entities.Legacy.NumTmp> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("num_tmp", "public");

            // key
            builder.HasNoKey();

            // properties
            builder.Property(t => t.Numero)
                .HasColumnName("numero")
                .HasColumnType("character varying(5)")
                .HasMaxLength(5);

            // relationships
            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "public";
            public const string Name = "num_tmp";
        }

        public struct Columns
        {
            public const string Numero = "numero";
        }
        #endregion
    }
}
