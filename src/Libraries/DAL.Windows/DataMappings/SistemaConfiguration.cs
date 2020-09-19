using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Windows.DataMappings
{
    public partial class SistemaMap
        : IEntityTypeConfiguration<Legacy.Entities.Sistema>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Legacy.Entities.Sistema> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("sistema", "public");

            // key
            builder.HasNoKey();

            // properties
            builder.Property(t => t.Usuario)
                .HasColumnName("usuario")
                .HasColumnType("character varying(2)")
                .HasMaxLength(2);

            builder.Property(t => t.Ticket)
                .HasColumnName("ticket")
                .HasColumnType("character varying(6)")
                .HasMaxLength(6);

            // relationships
            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "public";
            public const string Name = "sistema";
        }

        public struct Columns
        {
            public const string Usuario = "usuario";
            public const string Ticket = "ticket";
        }
        #endregion
    }
}
