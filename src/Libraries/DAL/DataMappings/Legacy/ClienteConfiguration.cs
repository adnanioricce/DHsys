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
    public class ClienteConfiguration : BaseEntityConfiguration<Cliente>
    {
        public override void Configure(EntityTypeBuilder<Cliente> entity)
        {
            entity.ToTable("CLIENTE");

            entity.Property(e => e.Clbairro).HasColumnName("CLBAIRRO");

            entity.Property(e => e.Clcep).HasColumnName("CLCEP");

            entity.Property(e => e.Clcida).HasColumnName("CLCIDA");

            entity.Property(e => e.Clcodi).HasColumnName("CLCODI");

            entity.Property(e => e.Clcompra)
                .HasColumnName("CLCOMPRA")
                .HasColumnType("datetime");

            entity.Property(e => e.Clcpf).HasColumnName("CLCPF");

            entity.Property(e => e.Clcred).HasColumnName("CLCRED");

            entity.Property(e => e.Cldebi).HasColumnName("CLDEBI");

            entity.Property(e => e.Cldesc).HasColumnName("CLDESC");

            entity.Property(e => e.Cldesmed).HasColumnName("CLDESMED");

            entity.Property(e => e.Cldesper).HasColumnName("CLDESPER");

            entity.Property(e => e.Clende).HasColumnName("CLENDE");

            entity.Property(e => e.Clestado).HasColumnName("CLESTADO");

            entity.Property(e => e.Cllime).HasColumnName("CLLIME");

            entity.Property(e => e.Clnasc)
                .HasColumnName("CLNASC")
                .HasColumnType("datetime");

            entity.Property(e => e.Clnome).HasColumnName("CLNOME");

            entity.Property(e => e.Clobs).HasColumnName("CLOBS");

            entity.Property(e => e.Clpagto).HasColumnName("CLPAGTO");

            entity.Property(e => e.Clrg).HasColumnName("CLRG");

            entity.Property(e => e.Cltele).HasColumnName("CLTELE");

            entity.Property(e => e.Clupagto)
                .HasColumnName("CLUPAGTO")
                .HasColumnType("datetime");
        }
    }
}
