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
    public class EmpresaConfiguration : BaseEntityConfiguration<Empresa>
    {
        public override void Configure(EntityTypeBuilder<Empresa> entity)
        {
            entity.ToTable("EMPRESA");

            entity.Property(e => e.Codgolden).HasColumnName("CODGOLDEN");

            entity.Property(e => e.DesAce).HasColumnName("DES_ACE");

            entity.Property(e => e.DesB).HasColumnName("DES_B");

            entity.Property(e => e.DesEtic).HasColumnName("DES_ETIC");

            entity.Property(e => e.DesFech).HasColumnName("DES_FECH");

            entity.Property(e => e.DesNota).HasColumnName("DES_NOTA");

            entity.Property(e => e.DesPerf).HasColumnName("DES_PERF");

            entity.Property(e => e.DesRest).HasColumnName("DES_REST");

            entity.Property(e => e.DesTick).HasColumnName("DES_TICK");

            entity.Property(e => e.DesVar).HasColumnName("DES_VAR");

            entity.Property(e => e.Descplac).HasColumnName("DESCPLAC");

            entity.Property(e => e.Embair).HasColumnName("EMBAIR");

            entity.Property(e => e.Embloq).HasColumnName("EMBLOQ");

            entity.Property(e => e.Emcep).HasColumnName("EMCEP");

            entity.Property(e => e.Emcgce).HasColumnName("EMCGCE");

            entity.Property(e => e.Emcida).HasColumnName("EMCIDA");

            entity.Property(e => e.Emcodi).HasColumnName("EMCODI");

            entity.Property(e => e.Emcont).HasColumnName("EMCONT");

            entity.Property(e => e.Emcontrato).HasColumnName("EMCONTRATO");

            entity.Property(e => e.Emdebito).HasColumnName("EMDEBITO");

            entity.Property(e => e.Emende).HasColumnName("EMENDE");

            entity.Property(e => e.Emesta).HasColumnName("EMESTA");

            entity.Property(e => e.Emetico).HasColumnName("EMETICO");

            entity.Property(e => e.Emfax).HasColumnName("EMFAX");

            entity.Property(e => e.Emfech).HasColumnName("EMFECH");

            entity.Property(e => e.Emfilial).HasColumnName("EMFILIAL");

            entity.Property(e => e.EmgCorea).HasColumnName("EMGCoreA");

            entity.Property(e => e.Eminsc).HasColumnName("EMINSC");

            entity.Property(e => e.Emlimite).HasColumnName("EMLIMITE");

            entity.Property(e => e.Emnume).HasColumnName("EMNUME");

            entity.Property(e => e.Emobs).HasColumnName("EMOBS");

            entity.Property(e => e.Emobs1).HasColumnName("EMOBS1");

            entity.Property(e => e.Emperf).HasColumnName("EMPERF");

            entity.Property(e => e.Emprint).HasColumnName("EMPRINT");

            entity.Property(e => e.Emraso).HasColumnName("EMRASO");

            entity.Property(e => e.Emreceita).HasColumnName("EMRECEITA");

            entity.Property(e => e.Emtele).HasColumnName("EMTELE");

            entity.Property(e => e.Ibgeest).HasColumnName("IBGEEST");

            entity.Property(e => e.Ibgemun).HasColumnName("IBGEMUN");

            entity.Property(e => e.Libperf).HasColumnName("LIBPERF");

            entity.Property(e => e.PercDesc).HasColumnName("PERC_DESC");

            entity.Property(e => e.Vidaav).HasColumnName("VIDAAV");

            entity.Property(e => e.Vidalk).HasColumnName("VIDALK");

            entity.Property(e => e.Vidapc).HasColumnName("VIDAPC");
        }
    }
}
