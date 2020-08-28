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
    public class TransferConfiguration : BaseEntityConfiguration<Transfer>
    {
        public override void Configure(EntityTypeBuilder<Transfer> entity)
        {
            entity.ToTable("TRANSFER");

            entity.Property(e => e.Balcon).HasColumnName("BALCON");

            entity.Property(e => e.Etiqueta).HasColumnName("ETIQUETA");

            entity.Property(e => e.Filcodi).HasColumnName("FILCODI");

            entity.Property(e => e.Hora).HasColumnName("HORA");

            entity.Property(e => e.Impresso).HasColumnName("IMPRESSO");

            entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

            entity.Property(e => e.Prcons).HasColumnName("PRCONS");

            entity.Property(e => e.Qtde).HasColumnName("QTDE");

            entity.Property(e => e.Trdata)
                .HasColumnName("TRDATA")
                .HasColumnType("datetime");
        }
    }
}
