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
    public class CancdiaConfiguration : BaseEntityConfiguration<Cancdia>
    {
        public override void Configure(EntityTypeBuilder<Cancdia> entity)
        {
            entity.ToTable("CANCDIA");

            entity.Property(e => e.Codemp).HasColumnName("CODEMP");

            entity.Property(e => e.Codfun).HasColumnName("CODFUN");

            entity.Property(e => e.Data)
                .HasColumnName("DATA")
                .HasColumnType("datetime");

            entity.Property(e => e.Datac)
                .HasColumnName("DATAC")
                .HasColumnType("datetime");

            entity.Property(e => e.Filial).HasColumnName("FILIAL");

            entity.Property(e => e.Ticket).HasColumnName("TICKET");
        }
    }
}
