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
    public class EncomenConfiguration : BaseEntityConfiguration<Encomen>
    {
        public override void Configure(EntityTypeBuilder<Encomen> entity)
        {
            entity.ToTable("ENCOMEN");

            entity.Property(e => e.Endata)
                .HasColumnName("ENDATA")
                .HasColumnType("datetime");

            entity.Property(e => e.Enqtde).HasColumnName("ENQTDE");

            entity.Property(e => e.Prcodi).HasColumnName("PRCODI");
        }
    }
}
