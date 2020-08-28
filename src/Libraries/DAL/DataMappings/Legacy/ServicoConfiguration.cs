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
    public class ServicoConfiguration : BaseEntityConfiguration<Servico>
    {
        public override void Configure(EntityTypeBuilder<Servico> entity)
        {
            entity.ToTable("SERVICO");

            entity.Property(e => e.Svcodi).HasColumnName("SVCODI");

            entity.Property(e => e.Svcomb).HasColumnName("SVCOMB");

            entity.Property(e => e.Svdesc).HasColumnName("SVDESC");

            entity.Property(e => e.Svpr01).HasColumnName("SVPR01");

            entity.Property(e => e.Svpr02).HasColumnName("SVPR02");

            entity.Property(e => e.Svpr03).HasColumnName("SVPR03");

            entity.Property(e => e.Svpr04).HasColumnName("SVPR04");

            entity.Property(e => e.Svpr05).HasColumnName("SVPR05");

            entity.Property(e => e.Svprec).HasColumnName("SVPREC");

            entity.Property(e => e.Svven1).HasColumnName("SVVEN1");

            entity.Property(e => e.Svven2).HasColumnName("SVVEN2");
        }
    }
}
