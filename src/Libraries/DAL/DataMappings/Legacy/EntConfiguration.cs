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
    public class EntConfiguration : BaseEntityConfiguration<Ent>
    {
        public override void Configure(EntityTypeBuilder<Ent> entity)
        {
            entity.ToTable("ENT");

            entity.Property(e => e.Descfin).HasColumnName("DESCFIN");

            entity.Property(e => e.Desconto).HasColumnName("DESCONTO");

            entity.Property(e => e.Descrep).HasColumnName("DESCREP");

            entity.Property(e => e.Endata)
                .HasColumnName("ENDATA")
                .HasColumnType("datetime");

            entity.Property(e => e.Enqtde).HasColumnName("ENQTDE");

            entity.Property(e => e.Envalo).HasColumnName("ENVALO");

            entity.Property(e => e.Envalodes).HasColumnName("ENVALODES");

            entity.Property(e => e.Estant).HasColumnName("ESTANT");

            entity.Property(e => e.Etiqueta).HasColumnName("ETIQUETA");

            entity.Property(e => e.Fornec).HasColumnName("FORNEC");

            entity.Property(e => e.Impresso).HasColumnName("IMPRESSO");

            entity.Property(e => e.Impretq).HasColumnName("IMPRETQ");

            entity.Property(e => e.Notafis).HasColumnName("NOTAFIS");

            entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

            entity.Property(e => e.Prfabr).HasColumnName("PRFABR");

            entity.Property(e => e.Soetiq).HasColumnName("SOETIQ");

            entity.Property(e => e.Usuario).HasColumnName("USUARIO");
        }
    }
}
