using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Windows.DataMappings
{
    public partial class NewprecMap
        : IEntityTypeConfiguration<Legacy.Entities.Newprec>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Legacy.Entities.Newprec> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("newprec", "public");

            // key
            builder.HasNoKey();

            // properties
            builder.Property(t => t.Prcodi)
                .HasColumnName("prcodi")
                .HasColumnType("character varying(6)")
                .HasMaxLength(6);

            builder.Property(t => t.Prcons)
                .HasColumnName("prcons")
                .HasColumnType("numeric(12,2)");

            builder.Property(t => t.Prconscv)
                .HasColumnName("prconscv")
                .HasColumnType("numeric(12,2)");

            builder.Property(t => t.Prfabr)
                .HasColumnName("prfabr")
                .HasColumnType("numeric(12,2)");

            builder.Property(t => t.Prcddt)
                .HasColumnName("prcddt")
                .HasColumnType("date");

            builder.Property(t => t.Prcdlucr)
                .HasColumnName("prcdlucr")
                .HasColumnType("numeric(10,6)");

            // relationships
            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "public";
            public const string Name = "newprec";
        }

        public struct Columns
        {
            public const string Prcodi = "prcodi";
            public const string Prcons = "prcons";
            public const string Prconscv = "prconscv";
            public const string Prfabr = "prfabr";
            public const string Prcddt = "prcddt";
            public const string Prcdlucr = "prcdlucr";
        }
        #endregion
    }
}
