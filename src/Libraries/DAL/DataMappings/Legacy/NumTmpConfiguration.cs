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
    public class NumTmpConfiguration : BaseEntityConfiguration<NumTmp>
    {
        public override void Configure(EntityTypeBuilder<NumTmp> entity)
        {
            //    entity.ToTable("NUM_TMP");

            entity.Property(e => e.Numero).HasColumnName("NUMERO");
        }
    }
}
