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
    public class DebcliConfiguration : BaseEntityConfiguration<Debcli>
    {
        public override void Configure(EntityTypeBuilder<Debcli> entity)
        {
            entity.ToTable("DEBCLI");

            entity.Property(e => e.Bacodi).HasColumnName("BACODI");

            entity.Property(e => e.Clbalc).HasColumnName("CLBALC");

            entity.Property(e => e.Clcodi).HasColumnName("CLCODI");

            entity.Property(e => e.Cldata)
                .HasColumnName("CLDATA")
                .HasColumnType("datetime");

            entity.Property(e => e.Cldesc).HasColumnName("CLDESC");

            entity.Property(e => e.Clobs).HasColumnName("CLOBS");

            entity.Property(e => e.Clpago).HasColumnName("CLPAGO");

            entity.Property(e => e.Clqtde).HasColumnName("CLQTDE");

            entity.Property(e => e.Cltick).HasColumnName("CLTICK");

            entity.Property(e => e.Comissao).HasColumnName("COMISSAO");

            entity.Property(e => e.Descomp).HasColumnName("DESCOMP");

            entity.Property(e => e.DtPagto)
                .HasColumnName("DT_PAGTO")
                .HasColumnType("datetime");

            entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

            entity.Property(e => e.VlPago).HasColumnName("VL_PAGO");
        }
    }
}
