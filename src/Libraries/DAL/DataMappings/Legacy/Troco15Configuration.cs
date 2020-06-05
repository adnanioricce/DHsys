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
    public class Troco15Configuration : BaseEntityConfiguration<Troco15>
    {
        public override void Configure(EntityTypeBuilder<Troco15> entity)
        {
            entity.ToTable("TROCO15");

            entity.Property(e => e.Data)
                .HasColumnName("DATA")
                .HasColumnType("datetime");

            entity.Property(e => e.Initroco).HasColumnName("INITROCO");

            entity.Property(e => e.TrocoIni).HasColumnName("TROCO_INI");
        }
    }
}
