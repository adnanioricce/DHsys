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
    public class UsointConfiguration : BaseEntityConfiguration<Usoint>
    {
        public override void Configure(EntityTypeBuilder<Usoint> entity)
        {
            entity.ToTable("USOINT");

            entity.Property(e => e.Data)
                .HasColumnName("DATA")
                .HasColumnType("datetime");

            entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

            entity.Property(e => e.Qtde).HasColumnName("QTDE");
        }
    }
}
