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
    public class ReconstConfiguration : BaseEntityConfiguration<Reconst>
    {
        public override void Configure(EntityTypeBuilder<Reconst> entity)
        {
            entity.ToTable("RECONST");

            entity.Property(e => e.ArqCorevo).HasColumnName("ARQCoreVO");

            entity.Property(e => e.Data)
                .HasColumnName("DATA")
                .HasColumnType("datetime");

            entity.Property(e => e.Necessita).HasColumnName("NECESSITA");

            entity.Property(e => e.Posicao).HasColumnName("POSICAO");
        }
    }
}
