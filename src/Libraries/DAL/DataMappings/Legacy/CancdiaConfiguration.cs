using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Mappings.Legacy
{
    public partial class CancdiaMap
        : IEntityTypeConfiguration<global::Core.Entities.Legacy.Cancdia>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<global::Core.Entities.Legacy.Cancdia> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("cancdia", "public");

            // key
            builder.HasNoKey();

            // properties
            builder.Property(t => t.Filial)
                .HasColumnName("filial")
                .HasColumnType("character varying(4)")
                .HasMaxLength(4);

            builder.Property(t => t.Ticket)
                .HasColumnName("ticket")
                .HasColumnType("character varying(6)")
                .HasMaxLength(6);

            builder.Property(t => t.Codemp)
                .HasColumnName("codemp")
                .HasColumnType("character varying(3)")
                .HasMaxLength(3);

            builder.Property(t => t.Codfun)
                .HasColumnName("codfun")
                .HasColumnType("character varying(15)")
                .HasMaxLength(15);

            builder.Property(t => t.Data)
                .HasColumnName("data")
                .HasColumnType("date");

            builder.Property(t => t.Datac)
                .HasColumnName("datac")
                .HasColumnType("date");

            // relationships
            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "public";
            public const string Name = "cancdia";
        }

        public struct Columns
        {
            public const string Filial = "filial";
            public const string Ticket = "ticket";
            public const string Codemp = "codemp";
            public const string Codfun = "codfun";
            public const string Data = "data";
            public const string Datac = "datac";
        }
        #endregion
    }
}
