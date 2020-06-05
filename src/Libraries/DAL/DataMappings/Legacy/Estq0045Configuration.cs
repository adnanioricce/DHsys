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
    public class Estq0045Configuration : BaseEntityConfiguration<Estq0045>
    {
        public override void Configure(EntityTypeBuilder<Estq0045> entity)
        {
            entity.ToTable("ESTQ0045");

            entity.Property(e => e.EstMinimo).HasColumnName("EST_MINIMO");

            entity.Property(e => e.Prbarra).HasColumnName("PRBARRA");

            entity.Property(e => e.Prcdse).HasColumnName("PRCDSE");

            entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

            entity.Property(e => e.Prdesc).HasColumnName("PRDESC");

            entity.Property(e => e.Prestq).HasColumnName("PRESTQ");

            entity.Property(e => e.Secao).HasColumnName("SECAO");
        }
    }
}
