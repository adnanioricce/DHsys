using Core.Entities;
using Core.Entities.Legacy;
using Core.Entities.Sync;
using DAL.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DAL.DbContexts;

namespace DAL.DataMappings.Legacy
{
    public class MovpopConfiguration : BaseEntityConfiguration<Movpop>
    {
        public override void Configure(EntityTypeBuilder<Movpop> entity)
        {
            entity.ToTable("MOVPOP");

            entity.Property(e => e.BalcCpf).HasColumnName("BALC_CPF");

            entity.Property(e => e.Cancelado).HasColumnName("CANCELADO");

            entity.Property(e => e.Compdia).HasColumnName("COMPDIA");

            entity.Property(e => e.Compmes).HasColumnName("COMPMES");

            entity.Property(e => e.Cpfcli).HasColumnName("CPFCLI");

            entity.Property(e => e.Crm).HasColumnName("CRM");

            entity.Property(e => e.Data)
                .HasColumnName("DATA")
                .HasColumnType("datetime");

            entity.Property(e => e.Datarec)
                .HasColumnName("DATAREC")
                .HasColumnType("datetime");

            entity.Property(e => e.Ecf).HasColumnName("ECF");

            entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

            entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");

            entity.Property(e => e.Senha).HasColumnName("SENHA");

            entity.Property(e => e.Ticket).HasColumnName("TICKET");

            entity.Property(e => e.TotDescon).HasColumnName("TOT_DESCON");

            entity.Property(e => e.VlTot).HasColumnName("VL_TOT");

            entity.Property(e => e.VlUnit).HasColumnName("VL_UNIT");

            entity.Property(e => e.VlliqCored).HasColumnName("VLLIQCoreD");
        }
    }
}
