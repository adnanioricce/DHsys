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
    public class ProdextrConfiguration : BaseEntityConfiguration<Prodextr>
    {
        public override void Configure(EntityTypeBuilder<Prodextr> entity)
        {
            entity.ToTable("PRODEXTR");

            entity.Property(e => e.Concor1).HasColumnName("CONCOR1");

            entity.Property(e => e.Concor2).HasColumnName("CONCOR2");

            entity.Property(e => e.Concor3).HasColumnName("CONCOR3");

            entity.Property(e => e.Concor4).HasColumnName("CONCOR4");

            entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

            entity.Property(e => e.Prcons).HasColumnName("PRCONS");

            entity.Property(e => e.Prdesc).HasColumnName("PRDESC");
        }
    }
}
