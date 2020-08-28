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
    public class NotaConfiguration : BaseEntityConfiguration<Nota>
    {
        public override void Configure(EntityTypeBuilder<Nota> entity)
        {
            entity.ToTable("NOTA");

            entity.Property(e => e.Base).HasColumnName("BASE");

            entity.Property(e => e.Basesub).HasColumnName("BASESUB");

            entity.Property(e => e.Cliente).HasColumnName("CLIENTE");

            entity.Property(e => e.Icms).HasColumnName("ICMS");

            entity.Property(e => e.Icmssub).HasColumnName("ICMSSUB");

            entity.Property(e => e.NFiscal).HasColumnName("N_FISCAL");

            entity.Property(e => e.NNatu).HasColumnName("N_NATU");

            entity.Property(e => e.Natureza).HasColumnName("NATUREZA");

            entity.Property(e => e.Nbase12).HasColumnName("NBASE12");

            entity.Property(e => e.Nbase18).HasColumnName("NBASE18");

            entity.Property(e => e.Nbase25).HasColumnName("NBASE25");

            entity.Property(e => e.Nbase7).HasColumnName("NBASE7");

            entity.Property(e => e.Ncancelada).HasColumnName("NCANCELADA");

            entity.Property(e => e.Ndata)
                .HasColumnName("NDATA")
                .HasColumnType("datetime");

            entity.Property(e => e.Nicms12).HasColumnName("NICMS12");

            entity.Property(e => e.Nicms18).HasColumnName("NICMS18");

            entity.Property(e => e.Nicms25).HasColumnName("NICMS25");

            entity.Property(e => e.Nicms7).HasColumnName("NICMS7");

            entity.Property(e => e.Nvalor).HasColumnName("NVALOR");
        }
    }
}
