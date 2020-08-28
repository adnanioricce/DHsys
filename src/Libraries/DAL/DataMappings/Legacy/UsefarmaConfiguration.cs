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
    public class UsefarmaConfiguration : BaseEntityConfiguration<Usefarma>
    {
        public override void Configure(EntityTypeBuilder<Usefarma> entity)
        {
            entity.ToTable("USEFARMA");

            entity.Property(e => e.Acesso1).HasColumnName("ACESSO1");

            entity.Property(e => e.Acesso10).HasColumnName("ACESSO10");

            entity.Property(e => e.Acesso2).HasColumnName("ACESSO2");

            entity.Property(e => e.Acesso3).HasColumnName("ACESSO3");

            entity.Property(e => e.Acesso4).HasColumnName("ACESSO4");

            entity.Property(e => e.Acesso5).HasColumnName("ACESSO5");

            entity.Property(e => e.Acesso6).HasColumnName("ACESSO6");

            entity.Property(e => e.Acesso7).HasColumnName("ACESSO7");

            entity.Property(e => e.Acesso8).HasColumnName("ACESSO8");

            entity.Property(e => e.Acesso9).HasColumnName("ACESSO9");

            entity.Property(e => e.Nivel).HasColumnName("NIVEL");

            entity.Property(e => e.Nome).HasColumnName("NOME");

            entity.Property(e => e.Senha).HasColumnName("SENHA");
        }
    }
}
