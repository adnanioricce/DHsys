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
    public class Ped0204Configuration : BaseEntityConfiguration<Ped0204>
    {
        public override void Configure(EntityTypeBuilder<Ped0204> entity)
        {
            entity.ToTable("PED0204");

            entity.Property(e => e.Codint).HasColumnName("CODINT");

            entity.Property(e => e.Eloja1).HasColumnName("ELOJA1");

            entity.Property(e => e.Eloja2).HasColumnName("ELOJA2");

            entity.Property(e => e.Eloja3).HasColumnName("ELOJA3");

            entity.Property(e => e.Eloja4).HasColumnName("ELOJA4");

            entity.Property(e => e.Forn).HasColumnName("FORN");

            entity.Property(e => e.Mloja1).HasColumnName("MLOJA1");

            entity.Property(e => e.Mloja2).HasColumnName("MLOJA2");

            entity.Property(e => e.Mloja3).HasColumnName("MLOJA3");

            entity.Property(e => e.Mloja4).HasColumnName("MLOJA4");

            entity.Property(e => e.Nloja1).HasColumnName("NLOJA1");

            entity.Property(e => e.Nloja2).HasColumnName("NLOJA2");

            entity.Property(e => e.Nloja3).HasColumnName("NLOJA3");

            entity.Property(e => e.Nloja4).HasColumnName("NLOJA4");

            entity.Property(e => e.Prbarra).HasColumnName("PRBARRA");

            entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

            entity.Property(e => e.Prdesc).HasColumnName("PRDESC");

            entity.Property(e => e.Valor).HasColumnName("VALOR");
        }
    }
}
