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
    public class ConvConfiguration : BaseEntityConfiguration<Conv>
    {
        public override void Configure(EntityTypeBuilder<Conv> entity)
        {
            entity.ToTable("CONV");

            entity.Property(e => e.Cvbalc).HasColumnName("CVBALC");

            entity.Property(e => e.Cvcomissao).HasColumnName("CVCOMISSAO");

            entity.Property(e => e.Cvdata)
                .HasColumnName("CVDATA")
                .HasColumnType("datetime");

            entity.Property(e => e.Cvdtrec)
                .HasColumnName("CVDTREC")
                .HasColumnType("datetime");

            entity.Property(e => e.Cventrega).HasColumnName("CVENTREGA");

            entity.Property(e => e.Cvfilial).HasColumnName("CVFILIAL");

            entity.Property(e => e.Cvlibcom)
                .HasColumnName("CVLIBCOM")
                .HasColumnType("datetime");

            entity.Property(e => e.Cvnota).HasColumnName("CVNOTA");

            entity.Property(e => e.Cvobsv).HasColumnName("CVOBSV");

            entity.Property(e => e.Cvpsuso).HasColumnName("CVPSUSO");

            entity.Property(e => e.Cvreceita).HasColumnName("CVRECEITA");

            entity.Property(e => e.Cvtick).HasColumnName("CVTICK");

            entity.Property(e => e.Cvtitular).HasColumnName("CVTITULAR");

            entity.Property(e => e.Cvvalocrz).HasColumnName("CVVALOCRZ");

            entity.Property(e => e.Cvvalourv).HasColumnName("CVVALOURV");

            entity.Property(e => e.Fucdem).HasColumnName("FUCDEM");

            entity.Property(e => e.Fucodi).HasColumnName("FUCODI");
        }
    }
}
