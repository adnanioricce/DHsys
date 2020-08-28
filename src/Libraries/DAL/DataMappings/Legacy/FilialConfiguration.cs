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
    public class FilialConfiguration : BaseEntityConfiguration<Filial>
    {
        public override void Configure(EntityTypeBuilder<Filial> entity)
        {
            entity.ToTable("FILIAL");

            entity.Property(e => e.Aplica1).HasColumnName("APLICA1");

            entity.Property(e => e.Aplica10).HasColumnName("APLICA10");

            entity.Property(e => e.Aplica2).HasColumnName("APLICA2");

            entity.Property(e => e.Aplica3).HasColumnName("APLICA3");

            entity.Property(e => e.Aplica4).HasColumnName("APLICA4");

            entity.Property(e => e.Aplica5).HasColumnName("APLICA5");

            entity.Property(e => e.Aplica6).HasColumnName("APLICA6");

            entity.Property(e => e.Aplica7).HasColumnName("APLICA7");

            entity.Property(e => e.Aplica8).HasColumnName("APLICA8");

            entity.Property(e => e.Aplica9).HasColumnName("APLICA9");

            entity.Property(e => e.Desc1).HasColumnName("DESC1");

            entity.Property(e => e.Desc10).HasColumnName("DESC10");

            entity.Property(e => e.Desc2).HasColumnName("DESC2");

            entity.Property(e => e.Desc3).HasColumnName("DESC3");

            entity.Property(e => e.Desc4).HasColumnName("DESC4");

            entity.Property(e => e.Desc5).HasColumnName("DESC5");

            entity.Property(e => e.Desc6).HasColumnName("DESC6");

            entity.Property(e => e.Desc7).HasColumnName("DESC7");

            entity.Property(e => e.Desc8).HasColumnName("DESC8");

            entity.Property(e => e.Desc9).HasColumnName("DESC9");

            entity.Property(e => e.Filcep).HasColumnName("FILCEP");

            entity.Property(e => e.Filcgce).HasColumnName("FILCGCE");

            entity.Property(e => e.Filcida).HasColumnName("FILCIDA");

            entity.Property(e => e.Filcodi).HasColumnName("FILCODI");

            entity.Property(e => e.Filcont).HasColumnName("FILCONT");

            entity.Property(e => e.Filende).HasColumnName("FILENDE");

            entity.Property(e => e.Filesta).HasColumnName("FILESTA");

            entity.Property(e => e.Filfax).HasColumnName("FILFAX");

            entity.Property(e => e.Filinsc).HasColumnName("FILINSC");

            entity.Property(e => e.Filnome).HasColumnName("FILNOME");

            entity.Property(e => e.Filtele).HasColumnName("FILTELE");

            entity.Property(e => e.Subsec1).HasColumnName("SUBSEC1");

            entity.Property(e => e.Subsec10).HasColumnName("SUBSEC10");

            entity.Property(e => e.Subsec2).HasColumnName("SUBSEC2");

            entity.Property(e => e.Subsec3).HasColumnName("SUBSEC3");

            entity.Property(e => e.Subsec4).HasColumnName("SUBSEC4");

            entity.Property(e => e.Subsec5).HasColumnName("SUBSEC5");

            entity.Property(e => e.Subsec6).HasColumnName("SUBSEC6");

            entity.Property(e => e.Subsec7).HasColumnName("SUBSEC7");

            entity.Property(e => e.Subsec8).HasColumnName("SUBSEC8");

            entity.Property(e => e.Subsec9).HasColumnName("SUBSEC9");
        }
    }
}
