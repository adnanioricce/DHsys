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
    public class PedidosConfiguration : BaseEntityConfiguration<Pedidos>
    {
        public override void Configure(EntityTypeBuilder<Pedidos> entity)
        {
            entity.ToTable("PEDIDOS");

            entity.Property(e => e.Prcdla).HasColumnName("PRCDLA");

            entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

            entity.Property(e => e.Prdata)
                .HasColumnName("PRDATA")
                .HasColumnType("datetime");

            entity.Property(e => e.Prfabr).HasColumnName("PRFABR");

            entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");

            entity.Property(e => e.Status).HasColumnName("STATUS");
        }
    }
}
