using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Windows.DataMappings
{
    public partial class IbptMap
        : IEntityTypeConfiguration<Legacy.Entities.Ibpt>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Legacy.Entities.Ibpt> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("ibpt", "public");

            // key
            builder.HasNoKey();

            // properties
            builder.Property(t => t.Codigo)
                .HasColumnName("codigo")
                .HasColumnType("character varying(9)")
                .HasMaxLength(9);

            builder.Property(t => t.Imp1)
                .HasColumnName("imp1")
                .HasColumnType("character varying(5)")
                .HasMaxLength(5);

            builder.Property(t => t.Imp2)
                .HasColumnName("imp2")
                .HasColumnType("character varying(5)")
                .HasMaxLength(5);

            // relationships
            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "public";
            public const string Name = "ibpt";
        }

        public struct Columns
        {
            public const string Codigo = "codigo";
            public const string Imp1 = "imp1";
            public const string Imp2 = "imp2";
        }
        #endregion
    }
}
