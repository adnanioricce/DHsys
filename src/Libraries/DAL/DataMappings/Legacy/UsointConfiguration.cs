using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Mappings.Legacy
{
    public partial class UsointMap
        : IEntityTypeConfiguration<global::Core.Entities.Legacy.Usoint>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<global::Core.Entities.Legacy.Usoint> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("usoint", "public");

            // key
            builder.HasNoKey();

            // properties
            builder.Property(t => t.Data)
                .HasColumnName("data")
                .HasColumnType("date");

            builder.Property(t => t.Prcodi)
                .HasColumnName("prcodi")
                .HasColumnType("character varying(6)")
                .HasMaxLength(6);

            builder.Property(t => t.Qtde)
                .HasColumnName("qtde")
                .HasColumnType("numeric(4,0)");

            // relationships
            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "public";
            public const string Name = "usoint";
        }

        public struct Columns
        {
            public const string Data = "data";
            public const string Prcodi = "prcodi";
            public const string Qtde = "qtde";
        }
        #endregion
    }
}
