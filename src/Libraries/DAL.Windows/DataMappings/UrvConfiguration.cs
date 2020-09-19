using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Windows.DataMappings
{
    public partial class UrvMap
        : IEntityTypeConfiguration<Legacy.Entities.Urv>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Legacy.Entities.Urv> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("urv", "public");

            // key
            builder.HasNoKey();

            // properties
            builder.Property(t => t.Data)
                .HasColumnName("data")
                .HasColumnType("date");

            builder.Property(t => t.Valor)
                .HasColumnName("valor")
                .HasColumnType("numeric(7,2)");

            // relationships
            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "public";
            public const string Name = "urv";
        }

        public struct Columns
        {
            public const string Data = "data";
            public const string Valor = "valor";
        }
        #endregion
    }
}
