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
    public class CartaoConfiguration : BaseEntityConfiguration<Cartao>
    {
        public override void Configure(EntityTypeBuilder<Cartao> entity)
        {
            entity.ToTable("CARTAO");

            entity.Property(e => e.Codigo).HasColumnName("CODIGO");

            entity.Property(e => e.Nome).HasColumnName("NOME");

            entity.Property(e => e.Parcel).HasColumnName("PARCEL");

            entity.Property(e => e.Prazo).HasColumnName("PRAZO");

            entity.Property(e => e.Qtde).HasColumnName("QTDE");

            entity.Property(e => e.Taxa).HasColumnName("TAXA");
        }
    }
}
