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
    public class ClipagoConfiguration : BaseEntityConfiguration<Clipago>
    {
        public override void Configure(EntityTypeBuilder<Clipago> entity)
        {
            entity.ToTable("CLIPAGO");

            entity.Property(e => e.Cliente).HasColumnName("CLIENTE");

            entity.Property(e => e.Credito).HasColumnName("CREDITO");

            entity.Property(e => e.Data)
                .HasColumnName("DATA")
                .HasColumnType("datetime");

            entity.Property(e => e.Valor).HasColumnName("VALOR");
        }
    }
}
