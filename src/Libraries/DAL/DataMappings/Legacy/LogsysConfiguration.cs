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
    public class LogsysConfiguration : BaseEntityConfiguration<Logsys>
    {
        public override void Configure(EntityTypeBuilder<Logsys> entity)
        {
            entity.ToTable("LOGSYS");

            entity.Property(e => e.Data)
                .HasColumnName("DATA")
                .HasColumnType("datetime");

            entity.Property(e => e.Nivel).HasColumnName("NIVEL");

            entity.Property(e => e.Opcao).HasColumnName("OPCAO");

            entity.Property(e => e.Time).HasColumnName("TIME");

            entity.Property(e => e.Usuario).HasColumnName("USUARIO");
        }
    }
}
