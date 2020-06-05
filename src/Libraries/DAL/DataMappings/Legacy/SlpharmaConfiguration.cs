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
    public class SlpharmaConfiguration : BaseEntityConfiguration<Slpharma>
    {
        public override void Configure(EntityTypeBuilder<Slpharma> entity)
        {
            entity.ToTable("SLPHARMA");

            entity.Property(e => e.Reconst).HasColumnName("RECONST");
        }
    }
}
