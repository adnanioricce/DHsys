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
    public class ReducaoConfiguration : BaseEntityConfiguration<Reducao>
    {
        public override void Configure(EntityTypeBuilder<Reducao> entity)
        {
            entity.ToTable("REDUCAO");

            entity.Property(e => e.Acresc).HasColumnName("ACRESC");

            entity.Property(e => e.Acresfin).HasColumnName("ACRESFIN");

            entity.Property(e => e.Aliquota).HasColumnName("ALIQUOTA");

            entity.Property(e => e.Cancela).HasColumnName("CANCELA");

            entity.Property(e => e.Cns).HasColumnName("CNS");

            entity.Property(e => e.Cnsi).HasColumnName("CNSI");

            entity.Property(e => e.Coo).HasColumnName("COO");

            entity.Property(e => e.Data).HasColumnName("DATA");

            entity.Property(e => e.Desconto).HasColumnName("DESCONTO");

            entity.Property(e => e.Gtda).HasColumnName("GTDA");

            entity.Property(e => e.Nsi).HasColumnName("NSI");

            entity.Property(e => e.Rzaut).HasColumnName("RZAUT");

            entity.Property(e => e.Sangria).HasColumnName("SANGRIA");

            entity.Property(e => e.Supri).HasColumnName("SUPRI");

            entity.Property(e => e.Tributo).HasColumnName("TRIBUTO");
        }
    }
}
