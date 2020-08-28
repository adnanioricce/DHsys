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
    public class CadlabConfiguration : BaseEntityConfiguration<Cadlab>
    {
        public override void Configure(EntityTypeBuilder<Cadlab> entity)
        {
            entity.ToTable("CADLAB");

            entity.Property(e => e.DtAlter)
                .HasColumnName("DT_ALTER")
                .HasColumnType("datetime");

            entity.Property(e => e.Foapel).HasColumnName("FOAPEL");

            entity.Property(e => e.Fobair).HasColumnName("FOBAIR");

            entity.Property(e => e.Focepe).HasColumnName("FOCEPE");

            entity.Property(e => e.Focida).HasColumnName("FOCIDA");

            entity.Property(e => e.Focont).HasColumnName("FOCONT");

            entity.Property(e => e.Foende).HasColumnName("FOENDE");

            entity.Property(e => e.Foesta).HasColumnName("FOESTA");

            entity.Property(e => e.Fofaxe).HasColumnName("FOFAXE");

            entity.Property(e => e.Foibge).HasColumnName("FOIBGE");

            entity.Property(e => e.Fonome).HasColumnName("FONOME");

            entity.Property(e => e.Fonume).HasColumnName("FONUME");

            entity.Property(e => e.Fotel2).HasColumnName("FOTEL2");

            entity.Property(e => e.Fotele).HasColumnName("FOTELE");

            entity.Property(e => e.Labrev).HasColumnName("LABREV");

            entity.Property(e => e.Lacgce).HasColumnName("LACGCE");

            entity.Property(e => e.Lacodi).HasColumnName("LACODI");

            entity.Property(e => e.Lacond).HasColumnName("LACOND");

            entity.Property(e => e.Laiest).HasColumnName("LAIEST");

            entity.Property(e => e.Laperc).HasColumnName("LAPERC");

            entity.Property(e => e.Latipo).HasColumnName("LATIPO");

            entity.Property(e => e.Laulno).HasColumnName("LAULNO");

            entity.Property(e => e.Laultc).HasColumnName("LAULTC");

            entity.Property(e => e.Nomarq).HasColumnName("NOMARQ");
        }
    }
}
