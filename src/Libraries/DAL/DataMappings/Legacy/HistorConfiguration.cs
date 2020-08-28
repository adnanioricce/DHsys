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
    public class HistorConfiguration : BaseEntityConfiguration<Histor>
    {
        public override void Configure(EntityTypeBuilder<Histor> entity)
        {
            entity.ToTable("HISTOR");

            entity.Property(e => e.Desconto).HasColumnName("DESCONTO");

            entity.Property(e => e.Distrib).HasColumnName("DISTRIB");

            entity.Property(e => e.Notafis).HasColumnName("NOTAFIS");

            entity.Property(e => e.Pedido).HasColumnName("PEDIDO");

            entity.Property(e => e.Recebto)
                .HasColumnName("RECEBTO")
                .HasColumnType("datetime");

            entity.Property(e => e.Total).HasColumnName("TOTAL");

            entity.Property(e => e.Vencto)
                .HasColumnName("VENCTO")
                .HasColumnType("datetime");
        }
    }
}
