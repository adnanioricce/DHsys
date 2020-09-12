using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Mappings.Legacy
{
    public partial class MovnfMap
        : IEntityTypeConfiguration<global::Core.Entities.Legacy.Movnf>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<global::Core.Entities.Legacy.Movnf> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("movnf", "public");

            // key
            builder.HasNoKey();

            // properties
            builder.Property(t => t.Prcodi)
                .HasColumnName("prcodi")
                .HasColumnType("character varying(6)")
                .HasMaxLength(6);

            builder.Property(t => t.Prqtde)
                .HasColumnName("prqtde")
                .HasColumnType("numeric(6,0)");

            builder.Property(t => t.VlUnit)
                .HasColumnName("vl_unit")
                .HasColumnType("numeric(12,4)");

            builder.Property(t => t.Ticket)
                .HasColumnName("ticket")
                .HasColumnType("character varying(6)")
                .HasMaxLength(6);

            builder.Property(t => t.Data)
                .HasColumnName("data")
                .HasColumnType("date");

            builder.Property(t => t.Ecf)
                .HasColumnName("ecf")
                .HasColumnType("character varying(8)")
                .HasMaxLength(8);

            builder.Property(t => t.Descricao)
                .HasColumnName("descricao")
                .HasColumnType("character varying(30)")
                .HasMaxLength(30);

            builder.Property(t => t.Cancelado)
                .HasColumnName("cancelado")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.Cpf)
                .HasColumnName("cpf")
                .HasColumnType("character varying(15)")
                .HasMaxLength(15);

            builder.Property(t => t.VlTot)
                .HasColumnName("vl_tot")
                .HasColumnType("numeric(12,2)");

            // relationships
            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "public";
            public const string Name = "movnf";
        }

        public struct Columns
        {
            public const string Prcodi = "prcodi";
            public const string Prqtde = "prqtde";
            public const string VlUnit = "vl_unit";
            public const string Ticket = "ticket";
            public const string Data = "data";
            public const string Ecf = "ecf";
            public const string Descricao = "descricao";
            public const string Cancelado = "cancelado";
            public const string Cpf = "cpf";
            public const string VlTot = "vl_tot";
        }
        #endregion
    }
}
