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
    public class NfeConfiguration : BaseEntityConfiguration<Nfe>
    {
        public override void Configure(EntityTypeBuilder<Nfe> entity)
        {
            entity.ToTable("NFE");

            entity.Property(e => e.Campo).HasColumnName("CAMPO");

            entity.Property(e => e.Codigo).HasColumnName("CODIGO");

            entity.Property(e => e.Descricao).HasColumnName("DESCRICAO");

            entity.Property(e => e.Icms).HasColumnName("ICMS");

            entity.Property(e => e.Imp).HasColumnName("IMP");

            entity.Property(e => e.Ncm).HasColumnName("NCM");

            entity.Property(e => e.Prcdimp).HasColumnName("PRCDIMP");

            entity.Property(e => e.Qtde).HasColumnName("QTDE");

            entity.Property(e => e.Valor).HasColumnName("VALOR");

            entity.Property(e => e.Vltot).HasColumnName("VLTOT");
        }
    }
}
