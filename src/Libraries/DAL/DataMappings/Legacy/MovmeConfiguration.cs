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
    public class MovmeConfiguration : BaseEntityConfiguration<Movme>
    {
        public override void Configure(EntityTypeBuilder<Movme> entity)
        {
            entity.ToTable("MOVME");

            entity.Property(e => e.Bacodi).HasColumnName("BACODI");

            entity.Property(e => e.Cancelado).HasColumnName("CANCELADO");

            entity.Property(e => e.Codcli).HasColumnName("CODCLI");

            entity.Property(e => e.Data)
                .HasColumnName("DATA")
                .HasColumnType("datetime");

            entity.Property(e => e.Pedido).HasColumnName("PEDIDO");

            entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

            entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");

            entity.Property(e => e.Ticket).HasColumnName("TICKET");

            entity.Property(e => e.Tipo).HasColumnName("TIPO");

            entity.Property(e => e.TotComis).HasColumnName("TOT_COMIS");

            entity.Property(e => e.TotDescon).HasColumnName("TOT_DESCON");

            entity.Property(e => e.Tpvd).HasColumnName("TPVD");

            entity.Property(e => e.VlTot).HasColumnName("VL_TOT");

            entity.Property(e => e.VlUnit).HasColumnName("VL_UNIT");

            entity.Property(e => e.VlliqCored).HasColumnName("VLLIQCoreD");
        }
    }
}
