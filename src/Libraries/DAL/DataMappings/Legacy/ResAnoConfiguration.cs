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
    public class ResAnoConfiguration : BaseEntityConfiguration<ResAno>
    {
        public override void Configure(EntityTypeBuilder<ResAno> entity)
        {
            //    entity.ToTable("RES_ANO");

            entity.Property(e => e.CliAtds).HasColumnName("CLI_ATDS");

            entity.Property(e => e.Descrec).HasColumnName("DESCREC");

            entity.Property(e => e.Diastrab).HasColumnName("DIASTRAB");

            entity.Property(e => e.Entradas).HasColumnName("ENTRADAS");

            entity.Property(e => e.MesRef).HasColumnName("MES_REF");

            entity.Property(e => e.RecFiado).HasColumnName("REC_FIADO");

            entity.Property(e => e.TotEstoq).HasColumnName("TOT_ESTOQ");

            entity.Property(e => e.VdaConv).HasColumnName("VDA_CONV");

            entity.Property(e => e.VdaVista).HasColumnName("VDA_VISTA");

            entity.Property(e => e.VenFiado).HasColumnName("VEN_FIADO");

            entity.Property(e => e.VenMes).HasColumnName("VEN_MES");
        }
    }
}
