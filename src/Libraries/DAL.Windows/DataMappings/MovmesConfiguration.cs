using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Windows.DataMappings
{
    public partial class MovmesMap
        : IEntityTypeConfiguration<Legacy.Entities.Movmes>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Legacy.Entities.Movmes> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("movmes", "public");

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

            builder.Property(t => t.Vlliquid)
                .HasColumnName("vlliquid")
                .HasColumnType("numeric(12,2)");

            builder.Property(t => t.TotDescon)
                .HasColumnName("tot_descon")
                .HasColumnType("numeric(5,2)");

            builder.Property(t => t.Ticket)
                .HasColumnName("ticket")
                .HasColumnType("character varying(6)")
                .HasMaxLength(6);

            builder.Property(t => t.Bacodi)
                .HasColumnName("bacodi")
                .HasColumnType("character varying(3)")
                .HasMaxLength(3);

            builder.Property(t => t.Data)
                .HasColumnName("data")
                .HasColumnType("date");

            builder.Property(t => t.Tipo)
                .HasColumnName("tipo")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.Tpvd)
                .HasColumnName("tpvd")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.Ecf)
                .HasColumnName("ecf")
                .HasColumnType("character varying(8)")
                .HasMaxLength(8);

            builder.Property(t => t.Cancelado)
                .HasColumnName("cancelado")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.VlTot)
                .HasColumnName("vl_tot")
                .HasColumnType("numeric(12,2)");

            builder.Property(t => t.TotComis)
                .HasColumnName("tot_comis")
                .HasColumnType("numeric(12,4)");

            builder.Property(t => t.Pedido)
                .HasColumnName("pedido")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.Codcli)
                .HasColumnName("codcli")
                .HasColumnType("character varying(6)")
                .HasMaxLength(6);

            // relationships
            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "public";
            public const string Name = "movmes";
        }

        public struct Columns
        {
            public const string Prcodi = "prcodi";
            public const string Prqtde = "prqtde";
            public const string VlUnit = "vl_unit";
            public const string Vlliquid = "vlliquid";
            public const string TotDescon = "tot_descon";
            public const string Ticket = "ticket";
            public const string Bacodi = "bacodi";
            public const string Data = "data";
            public const string Tipo = "tipo";
            public const string Tpvd = "tpvd";
            public const string Ecf = "ecf";
            public const string Cancelado = "cancelado";
            public const string VlTot = "vl_tot";
            public const string TotComis = "tot_comis";
            public const string Pedido = "pedido";
            public const string Codcli = "codcli";
        }
        #endregion
    }
}
