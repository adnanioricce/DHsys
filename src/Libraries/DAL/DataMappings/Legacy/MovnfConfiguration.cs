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
    public class MovnfConfiguration : BaseEntityConfiguration<Movnf>
    {
        public override void Configure(EntityTypeBuilder<Movnf> entity)
        {
            entity.ToTable("MOVNF");

            entity.Property(e => e.Cancelado).HasColumnName("CANCELADO");

            entity.Property(e => e.Cpf).HasColumnName("CPF");

            entity.Property(e => e.Data)
                .HasColumnName("DATA")
                .HasColumnType("datetime");

            entity.Property(e => e.Descricao).HasColumnName("DESCRICAO");

            entity.Property(e => e.Ecf).HasColumnName("ECF");

            entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

            entity.Property(e => e.Prqtde).HasColumnName("PRQTDE");

            entity.Property(e => e.Ticket).HasColumnName("TICKET");

            entity.Property(e => e.VlTot).HasColumnName("VL_TOT");

            entity.Property(e => e.VlUnit).HasColumnName("VL_UNIT");
        }
    }
}
