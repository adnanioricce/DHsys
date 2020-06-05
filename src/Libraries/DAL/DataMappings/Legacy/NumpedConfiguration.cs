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
    public class NumpedConfiguration : BaseEntityConfiguration<Numped>
    {
        public override void Configure(EntityTypeBuilder<Numped> entity)
        {
            entity.ToTable("NUMPED");

            entity.Property(e => e.Desconto).HasColumnName("DESCONTO");

            entity.Property(e => e.Fornec).HasColumnName("FORNEC");

            entity.Property(e => e.Numero).HasColumnName("NUMERO");

            entity.Property(e => e.Przentrega).HasColumnName("PRZENTREGA");

            entity.Property(e => e.Przpagto).HasColumnName("PRZPAGTO");
        }
    }
}
