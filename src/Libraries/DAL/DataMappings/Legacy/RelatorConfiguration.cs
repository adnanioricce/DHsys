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
    public class RelatorConfiguration : BaseEntityConfiguration<Relator>
    {
        public override void Configure(EntityTypeBuilder<Relator> entity)
        {
            entity.ToTable("relator");

            entity.Property(e => e.Nivel).HasColumnName("NIVEL");

            entity.Property(e => e.Relatorio).HasColumnName("RELATORIO");
        }
    }
}
