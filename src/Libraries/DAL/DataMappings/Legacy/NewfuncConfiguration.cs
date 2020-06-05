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
    public class NewfuncConfiguration : BaseEntityConfiguration<Newfunc>
    {
        public override void Configure(EntityTypeBuilder<Newfunc> entity)
        {
            entity.ToTable("NEWFUNC");

            entity.Property(e => e.Codgolden).HasColumnName("CODGOLDEN");

            entity.Property(e => e.Datademi)
                .HasColumnName("DATADEMI")
                .HasColumnType("datetime");

            entity.Property(e => e.Demitido).HasColumnName("DEMITIDO");

            entity.Property(e => e.Fubai).HasColumnName("FUBAI");

            entity.Property(e => e.Fubloq).HasColumnName("FUBLOQ");

            entity.Property(e => e.Fucdem).HasColumnName("FUCDEM");

            entity.Property(e => e.Fucep).HasColumnName("FUCEP");

            entity.Property(e => e.Fucid).HasColumnName("FUCID");

            entity.Property(e => e.Fucodi).HasColumnName("FUCODI");

            entity.Property(e => e.Fudata)
                .HasColumnName("FUDATA")
                .HasColumnType("datetime");

            entity.Property(e => e.Fudepto).HasColumnName("FUDEPTO");

            entity.Property(e => e.Fuend).HasColumnName("FUEND");

            entity.Property(e => e.Fuest).HasColumnName("FUEST");

            entity.Property(e => e.Fufone).HasColumnName("FUFONE");

            entity.Property(e => e.Fulimite).HasColumnName("FULIMITE");

            entity.Property(e => e.Funome).HasColumnName("FUNOME");

            entity.Property(e => e.Fuobs1).HasColumnName("FUOBS1");

            entity.Property(e => e.Fuobs2).HasColumnName("FUOBS2");

            entity.Property(e => e.Fuobs3).HasColumnName("FUOBS3");

            entity.Property(e => e.Fusit).HasColumnName("FUSIT");

            entity.Property(e => e.Impresso).HasColumnName("IMPRESSO");

            entity.Property(e => e.Totdebcr).HasColumnName("TOTDEBCR");

            entity.Property(e => e.Totdebsr).HasColumnName("TOTDEBSR");
        }
    }
}
