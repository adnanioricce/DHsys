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
    public class RetiradaConfiguration : BaseEntityConfiguration<Retirada>
    {
        public override void Configure(EntityTypeBuilder<Retirada> entity)
        {
            entity.ToTable("RETIRADA");

            entity.Property(e => e.Caixa).HasColumnName("CAIXA");

            entity.Property(e => e.Data)
                .HasColumnName("DATA")
                .HasColumnType("datetime");

            entity.Property(e => e.Hora).HasColumnName("HORA");

            entity.Property(e => e.Valorch).HasColumnName("VALORCH");

            entity.Property(e => e.Valordh).HasColumnName("VALORDH");
        }
    }
}
