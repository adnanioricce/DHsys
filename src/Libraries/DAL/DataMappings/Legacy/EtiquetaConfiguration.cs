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
    public class EtiquetaConfiguration : BaseEntityConfiguration<Etiqueta>
    {
        public override void Configure(EntityTypeBuilder<Etiqueta> entity)
        {
            entity.ToTable("ETIQUETA");

            entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

            entity.Property(e => e.Prcons).HasColumnName("PRCONS");

            entity.Property(e => e.Prdesc1).HasColumnName("PRDESC1");

            entity.Property(e => e.Prdesc2).HasColumnName("PRDESC2");
        }
    }
}