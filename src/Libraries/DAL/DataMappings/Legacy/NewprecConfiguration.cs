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
    public class NewprecConfiguration : BaseEntityConfiguration<Newprec>
    {
        public override void Configure(EntityTypeBuilder<Newprec> entity)
        {
            entity.ToTable("NEWPREC");

            entity.Property(e => e.Prcddt)
                .HasColumnName("PRCDDT")
                .HasColumnType("datetime");

            entity.Property(e => e.Prcdlucr).HasColumnName("PRCDLUCR");

            entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

            entity.Property(e => e.Prcons).HasColumnName("PRCONS");

            entity.Property(e => e.Prconscv).HasColumnName("PRCONSCV");

            entity.Property(e => e.Prfabr).HasColumnName("PRFABR");
        }
    }
}
