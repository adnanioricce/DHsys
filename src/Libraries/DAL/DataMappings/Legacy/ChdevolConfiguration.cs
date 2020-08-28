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
    public class ChdevolConfiguration : BaseEntityConfiguration<Chdevol>
    {
        public override void Configure(EntityTypeBuilder<Chdevol> entity)
        {
            entity.ToTable("CHDEVOL");

            entity.Property(e => e.Agencia).HasColumnName("AGENCIA");

            entity.Property(e => e.Banco).HasColumnName("BANCO");

            entity.Property(e => e.Cheque).HasColumnName("CHEQUE");

            entity.Property(e => e.Cliente).HasColumnName("CLIENTE");

            entity.Property(e => e.Conta).HasColumnName("CONTA");

            entity.Property(e => e.Data)
                .HasColumnName("DATA")
                .HasColumnType("datetime");

            entity.Property(e => e.Datae)
                .HasColumnName("DATAE")
                .HasColumnType("datetime");

            entity.Property(e => e.Valor).HasColumnName("VALOR");
        }
    }
}
