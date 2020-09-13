using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Windows.DataMappings
{
    public partial class SubsecaoMap
        : IEntityTypeConfiguration<global::Core.Entities.Legacy.Subsecao>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<global::Core.Entities.Legacy.Subsecao> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("subsecao", "public");

            // key
            builder.HasNoKey();

            // properties
            builder.Property(t => t.Subsecodi)
                .HasColumnName("subsecodi")
                .HasColumnType("character varying(2)")
                .HasMaxLength(2);

            builder.Property(t => t.Subsenome)
                .HasColumnName("subsenome")
                .HasColumnType("character varying(15)")
                .HasMaxLength(15);

            builder.Property(t => t.Subseprec)
                .HasColumnName("subseprec")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.Secaopert)
                .HasColumnName("secaopert")
                .HasColumnType("character varying(2)")
                .HasMaxLength(2);

            builder.Property(t => t.Subselucr)
                .HasColumnName("subselucr")
                .HasColumnType("numeric(8,6)");

            builder.Property(t => t.Valrec)
                .HasColumnName("valrec")
                .HasColumnType("numeric(3,0)");

            builder.Property(t => t.Subimpost)
                .HasColumnName("subimpost")
                .HasColumnType("numeric(5,2)");

            builder.Property(t => t.Subncm)
                .HasColumnName("subncm")
                .HasColumnType("character varying(8)")
                .HasMaxLength(8);

            // relationships
            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "public";
            public const string Name = "subsecao";
        }

        public struct Columns
        {
            public const string Subsecodi = "subsecodi";
            public const string Subsenome = "subsenome";
            public const string Subseprec = "subseprec";
            public const string Secaopert = "secaopert";
            public const string Subselucr = "subselucr";
            public const string Valrec = "valrec";
            public const string Subimpost = "subimpost";
            public const string Subncm = "subncm";
        }
        #endregion
    }
}
