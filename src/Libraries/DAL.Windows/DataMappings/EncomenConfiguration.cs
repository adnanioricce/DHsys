using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Windows.DataMappings
{
    public partial class EncomenMap
        : IEntityTypeConfiguration<Legacy.Entities.Encomen>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Legacy.Entities.Encomen> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("encomen", "public");

            // key
            builder.HasNoKey();

            // properties
            builder.Property(t => t.Enqtde)
                .HasColumnName("enqtde")
                .HasColumnType("numeric(6,0)");

            builder.Property(t => t.Endata)
                .HasColumnName("endata")
                .HasColumnType("date");

            builder.Property(t => t.Prcodi)
                .HasColumnName("prcodi")
                .HasColumnType("character varying(6)")
                .HasMaxLength(6);

            // relationships
            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "public";
            public const string Name = "encomen";
        }

        public struct Columns
        {
            public const string Enqtde = "enqtde";
            public const string Endata = "endata";
            public const string Prcodi = "prcodi";
        }
        #endregion
    }
}
