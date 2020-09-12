using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Mappings.Legacy
{
    public partial class TicketMap
        : IEntityTypeConfiguration<global::Core.Entities.Legacy.Ticket>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<global::Core.Entities.Legacy.Ticket> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("ticket", "public");

            // key
            builder.HasNoKey();

            // properties
            builder.Property(t => t.Ticket1)
                .HasColumnName("ticket")
                .HasColumnType("character varying(6)")
                .HasMaxLength(6);

            builder.Property(t => t.Ecf)
                .HasColumnName("ecf")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            // relationships
            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "public";
            public const string Name = "ticket";
        }

        public struct Columns
        {
            public const string TicketMember = "ticket";
            public const string Ecf = "ecf";
        }
        #endregion
    }
}
