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
    public class AgendaConfiguration : BaseEntityConfiguration<Agenda>
    {
        public override void Configure(EntityTypeBuilder<Agenda> entity)
        {
            entity.ToTable("AGENDA");

            entity.Property(e => e.Bairro).HasColumnName("BAIRRO");

            entity.Property(e => e.Cep).HasColumnName("CEP");

            entity.Property(e => e.Cidade).HasColumnName("CIDADE");

            entity.Property(e => e.Codigo).HasColumnName("CODIGO");

            entity.Property(e => e.Endereco).HasColumnName("ENDERECO");

            entity.Property(e => e.Fone).HasColumnName("FONE");

            entity.Property(e => e.Nome).HasColumnName("NOME");
        }
    }
}
