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
    public class SubsecaoConfiguration : BaseEntityConfiguration<Subsecao>
    {
        public override void Configure(EntityTypeBuilder<Subsecao> entity)
        {
            entity.ToTable("SUBSECAO");

            entity.Property(e => e.Secaopert).HasColumnName("SECAOPERT");

            entity.Property(e => e.Subimpost).HasColumnName("SUBIMPOST");

            entity.Property(e => e.Subncm).HasColumnName("SUBNCM");

            entity.Property(e => e.Subsecodi).HasColumnName("SUBSECODI");

            entity.Property(e => e.Subselucr).HasColumnName("SUBSELUCR");

            entity.Property(e => e.Subsenome).HasColumnName("SUBSENOME");

            entity.Property(e => e.Subseprec).HasColumnName("SUBSEPREC");

            entity.Property(e => e.Valrec).HasColumnName("VALREC");
        }
    }
}
