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
    public class DespesasConfiguration : BaseEntityConfiguration<Despesas>
    {
        public override void Configure(EntityTypeBuilder<Despesas> entity)
        {
            entity.ToTable("DESPESAS");

            entity.Property(e => e.Caixa).HasColumnName("CAIXA");

            entity.Property(e => e.Data)
                .HasColumnName("DATA")
                .HasColumnType("datetime");

            entity.Property(e => e.Historico).HasColumnName("HISTORICO");

            entity.Property(e => e.Valor).HasColumnName("VALOR");
        }
    }
}
