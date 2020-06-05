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
    public class InventConfiguration : BaseEntityConfiguration<Invent>
    {
        public override void Configure(EntityTypeBuilder<Invent> entity)
        {
            entity.ToTable("INVENT");

            entity.Property(e => e.Lote).HasColumnName("LOTE");

            entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

            entity.Property(e => e.Prdesc).HasColumnName("PRDESC");

            entity.Property(e => e.Prreg).HasColumnName("PRREG");

            entity.Property(e => e.Qtde).HasColumnName("QTDE");

            entity.Property(e => e.Tpmed).HasColumnName("TPMED");
        }
    }
}
