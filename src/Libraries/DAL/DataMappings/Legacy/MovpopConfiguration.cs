using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Mappings.Legacy
{
    public partial class MovpopMap
        : IEntityTypeConfiguration<global::Core.Entities.Legacy.Movpop>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<global::Core.Entities.Legacy.Movpop> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("movpop", "public");

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

            builder.Property(t => t.Data)
                .HasColumnName("data")
                .HasColumnType("date");

            builder.Property(t => t.Datarec)
                .HasColumnName("datarec")
                .HasColumnType("date");

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

            builder.Property(t => t.Compdia)
                .HasColumnName("compdia")
                .HasColumnType("numeric(5,0)");

            builder.Property(t => t.Compmes)
                .HasColumnName("compmes")
                .HasColumnType("numeric(5,0)");

            builder.Property(t => t.BalcCpf)
                .HasColumnName("balc_cpf")
                .HasColumnType("character varying(11)")
                .HasMaxLength(11);

            builder.Property(t => t.Cpfcli)
                .HasColumnName("cpfcli")
                .HasColumnType("character varying(11)")
                .HasMaxLength(11);

            builder.Property(t => t.Senha)
                .HasColumnName("senha")
                .HasColumnType("character varying(8)")
                .HasMaxLength(8);

            builder.Property(t => t.Crm)
                .HasColumnName("crm")
                .HasColumnType("character varying(20)")
                .HasMaxLength(20);

            // relationships
            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "public";
            public const string Name = "movpop";
        }

        public struct Columns
        {
            public const string Prcodi = "prcodi";
            public const string Prqtde = "prqtde";
            public const string VlUnit = "vl_unit";
            public const string Vlliquid = "vlliquid";
            public const string TotDescon = "tot_descon";
            public const string Ticket = "ticket";
            public const string Data = "data";
            public const string Datarec = "datarec";
            public const string Ecf = "ecf";
            public const string Cancelado = "cancelado";
            public const string VlTot = "vl_tot";
            public const string Compdia = "compdia";
            public const string Compmes = "compmes";
            public const string BalcCpf = "balc_cpf";
            public const string Cpfcli = "cpfcli";
            public const string Senha = "senha";
            public const string Crm = "crm";
        }
        #endregion
    }
}
