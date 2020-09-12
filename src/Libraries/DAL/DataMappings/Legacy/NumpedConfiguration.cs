using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Mappings.Legacy
{
    public partial class NumpedMap
        : IEntityTypeConfiguration<global::Core.Entities.Legacy.Numped>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<global::Core.Entities.Legacy.Numped> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("numped", "public");

            // key
            builder.HasNoKey();

            // properties
            builder.Property(t => t.Fornec)
                .HasColumnName("fornec")
                .HasColumnType("character varying(4)")
                .HasMaxLength(4);

            builder.Property(t => t.Przpagto)
                .HasColumnName("przpagto")
                .HasColumnType("character varying(10)")
                .HasMaxLength(10);

            builder.Property(t => t.Desconto)
                .HasColumnName("desconto")
                .HasColumnType("numeric(5,2)");

            builder.Property(t => t.Numero)
                .HasColumnName("numero")
                .HasColumnType("character varying(5)")
                .HasMaxLength(5);

            builder.Property(t => t.Przentrega)
                .HasColumnName("przentrega")
                .HasColumnType("character varying(15)")
                .HasMaxLength(15);

            // relationships
            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "public";
            public const string Name = "numped";
        }

        public struct Columns
        {
            public const string Fornec = "fornec";
            public const string Przpagto = "przpagto";
            public const string Desconto = "desconto";
            public const string Numero = "numero";
            public const string Przentrega = "przentrega";
        }
        #endregion
    }
}
