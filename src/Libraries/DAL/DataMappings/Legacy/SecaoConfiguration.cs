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
    public class SecaoConfiguration : BaseEntityConfiguration<Secao>
    {
        public override void Configure(EntityTypeBuilder<Secao> entity)
        {
            entity.ToTable("SECAO");

            entity.Property(e => e.Secodi).HasColumnName("SECODI");

            entity.Property(e => e.Senome).HasColumnName("SENOME");
        }
    }
}
