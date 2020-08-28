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
    public class BrindesConfiguration : BaseEntityConfiguration<Brindes>
    {
        public override void Configure(EntityTypeBuilder<Brindes> entity)
        {
            entity.ToTable("BRINDES");

            entity.Property(e => e.Codigo).HasColumnName("CODIGO");

            entity.Property(e => e.Nome).HasColumnName("NOME");

            entity.Property(e => e.Pontos).HasColumnName("PONTOS");

            entity.Property(e => e.Qtde).HasColumnName("QTDE");
        }
    }
}
