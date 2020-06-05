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
    public class CadpromConfiguration : BaseEntityConfiguration<Cadprom>
    {
        public override void Configure(EntityTypeBuilder<Cadprom> entity)
        {
            entity.ToTable("CADPROM");

            entity.Property(e => e.Fonome).HasColumnName("FONOME");

            entity.Property(e => e.Fotele).HasColumnName("FOTELE");

            entity.Property(e => e.Lacodi).HasColumnName("LACODI");

            entity.Property(e => e.Valid)
                .HasColumnName("VALID")
                .HasColumnType("datetime");
        }
    }
}
