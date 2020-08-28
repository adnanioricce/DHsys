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
    public class CliMedConfiguration : BaseEntityConfiguration<CliMed>
    {
        public override void Configure(EntityTypeBuilder<CliMed> entity)
        {
            //    entity.ToTable("CLI_MED");

            entity.Property(e => e.CpfCrm).HasColumnName("CPF_CRM");

            entity.Property(e => e.Endereco).HasColumnName("ENDERECO");

            entity.Property(e => e.Fone).HasColumnName("FONE");

            entity.Property(e => e.Nome).HasColumnName("NOME");

            entity.Property(e => e.Sexo).HasColumnName("SEXO");
        }
    }
}
