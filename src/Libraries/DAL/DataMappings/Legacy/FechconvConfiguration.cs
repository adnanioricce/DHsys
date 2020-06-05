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
    public class FechconvConfiguration : BaseEntityConfiguration<Fechconv>
    {
        public override void Configure(EntityTypeBuilder<Fechconv> entity)
        {
            entity.ToTable("FECHCONV");

            entity.Property(e => e.Data)
                .HasColumnName("DATA")
                .HasColumnType("datetime");

            entity.Property(e => e.Fucdem).HasColumnName("FUCDEM");

            entity.Property(e => e.Valor).HasColumnName("VALOR");
        }
    }
}
