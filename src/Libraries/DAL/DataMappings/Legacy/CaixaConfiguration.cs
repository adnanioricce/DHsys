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
    public class CaixaConfiguration : BaseEntityConfiguration<Caixa>
    {
        public override void Configure(EntityTypeBuilder<Caixa> entity)
        {
            entity.ToTable("CAIXA");

            entity.Property(e => e.CxAdm).HasColumnName("CX_ADM");

            entity.Property(e => e.CxAtend).HasColumnName("CX_ATEND");

            entity.Property(e => e.CxCart).HasColumnName("CX_CART");

            entity.Property(e => e.CxData)
                .HasColumnName("CX_DATA")
                .HasColumnType("datetime");

            entity.Property(e => e.CxRec)
                .HasColumnName("CX_REC")
                .HasColumnType("datetime");

            entity.Property(e => e.CxTipo).HasColumnName("CX_TIPO");

            entity.Property(e => e.CxValor).HasColumnName("CX_VALOR");
        }
    }
}
