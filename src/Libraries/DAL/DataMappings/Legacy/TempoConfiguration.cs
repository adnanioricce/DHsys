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
    public class TempoConfiguration : BaseEntityConfiguration<Tempo>
    {
        public override void Configure(EntityTypeBuilder<Tempo> entity)
        {
            entity.ToTable("TEMPO");

            entity.Property(e => e.Desconto).HasColumnName("DESCONTO");

            entity.Property(e => e.Descricao).HasColumnName("DESCRICAO");

            entity.Property(e => e.Estoque).HasColumnName("ESTOQUE");

            entity.Property(e => e.Pedido).HasColumnName("PEDIDO");

            entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

            entity.Property(e => e.Prcons).HasColumnName("PRCONS");

            entity.Property(e => e.Prconsd).HasColumnName("PRCONSD");

            entity.Property(e => e.Qtde).HasColumnName("QTDE");

            entity.Property(e => e.VlTotal).HasColumnName("VL_TOTAL");
        }
    }
}
