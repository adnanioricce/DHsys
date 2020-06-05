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
    public class SistemaConfiguration : BaseEntityConfiguration<Sistema>
    {
        public override void Configure(EntityTypeBuilder<Sistema> entity)
        {
            entity.ToTable("SISTEMA");

            entity.Property(e => e.Ticket).HasColumnName("TICKET");

            entity.Property(e => e.Usuario).HasColumnName("USUARIO");
        }
    }
}
