using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Windows.DataMappings
{
    public partial class RetiradaMap
        : IEntityTypeConfiguration<Legacy.Entities.Retirada>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Legacy.Entities.Retirada> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("retirada", "public");

            // key
            builder.HasNoKey();

            // properties
            builder.Property(t => t.Data)
                .HasColumnName("data")
                .HasColumnType("date");

            builder.Property(t => t.Valordh)
                .HasColumnName("valordh")
                .HasColumnType("numeric(12,2)");

            builder.Property(t => t.Valorch)
                .HasColumnName("valorch")
                .HasColumnType("numeric(12,2)");

            builder.Property(t => t.Hora)
                .HasColumnName("hora")
                .HasColumnType("character varying(5)")
                .HasMaxLength(5);

            builder.Property(t => t.Caixa)
                .HasColumnName("caixa")
                .HasColumnType("character varying(2)")
                .HasMaxLength(2);

            // relationships
            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "public";
            public const string Name = "retirada";
        }

        public struct Columns
        {
            public const string Data = "data";
            public const string Valordh = "valordh";
            public const string Valorch = "valorch";
            public const string Hora = "hora";
            public const string Caixa = "caixa";
        }
        #endregion
    }
}
