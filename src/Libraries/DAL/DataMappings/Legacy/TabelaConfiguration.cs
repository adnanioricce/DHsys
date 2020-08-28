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
    public class TabelaConfiguration : BaseEntityConfiguration<Tabela>
    {
        public override void Configure(EntityTypeBuilder<Tabela> entity)
        {
            entity.ToTable("TABELA");

            entity.Property(e => e.Abc).HasColumnName("ABC");

            entity.Property(e => e.Barra).HasColumnName("BARRA");

            entity.Property(e => e.Ctr).HasColumnName("CTR");

            entity.Property(e => e.Custom).HasColumnName("CUSTOM");

            entity.Property(e => e.Des).HasColumnName("DES");

            entity.Property(e => e.Dtvig)
                .HasColumnName("DTVIG")
                .HasColumnType("datetime");

            entity.Property(e => e.Fra1).HasColumnName("FRA1");

            entity.Property(e => e.Ipi).HasColumnName("IPI");

            entity.Property(e => e.LabNom).HasColumnName("LAB_NOM");

            entity.Property(e => e.MedApr).HasColumnName("MED_APR");

            entity.Property(e => e.MedDes).HasColumnName("MED_DES");

            entity.Property(e => e.MedPrinci).HasColumnName("MED_PRINCI");

            entity.Property(e => e.MedRegims).HasColumnName("MED_REGIMS");

            entity.Property(e => e.Negpos).HasColumnName("NEGPOS");

            entity.Property(e => e.Neutro).HasColumnName("NEUTRO");

            entity.Property(e => e.Nom).HasColumnName("NOM");

            entity.Property(e => e.Pco1).HasColumnName("PCO1");

            entity.Property(e => e.Pla1).HasColumnName("PLA1");

            entity.Property(e => e.Uni).HasColumnName("UNI");
        }
    }
}
