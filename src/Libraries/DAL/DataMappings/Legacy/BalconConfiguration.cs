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
    public class BalconConfiguration : BaseEntityConfiguration<Balcon>
    {
        public override void Configure(EntityTypeBuilder<Balcon> entity)
        {
            entity.ToTable("BALCON");

            entity.Property(e => e.Bacodi).HasColumnName("BACODI");

            entity.Property(e => e.Bacomi).HasColumnName("BACOMI");

            entity.Property(e => e.Badevol).HasColumnName("BADEVOL");

            entity.Property(e => e.Banome).HasColumnName("BANOME");

            entity.Property(e => e.ComisAce).HasColumnName("COMIS_ACE");

            entity.Property(e => e.ComisBo).HasColumnName("COMIS_BO");

            entity.Property(e => e.ComisEti).HasColumnName("COMIS_ETI");

            entity.Property(e => e.ComisOut).HasColumnName("COMIS_OUT");

            entity.Property(e => e.ComisPer).HasColumnName("COMIS_PER");

            entity.Property(e => e.ComisPerc).HasColumnName("COMIS_PERC");

            entity.Property(e => e.ComisVar).HasColumnName("COMIS_VAR");

            entity.Property(e => e.Cpf).HasColumnName("CPF");

            entity.Property(e => e.Senha).HasColumnName("SENHA");
        }
    }
}
