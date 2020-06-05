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
    public class NewcliConfiguration : BaseEntityConfiguration<Newcli>
    {
        public override void Configure(EntityTypeBuilder<Newcli> entity)
        {
            entity.ToTable("NEWCLI");

            entity.Property(e => e.Bairro).HasColumnName("BAIRRO");

            entity.Property(e => e.Cep).HasColumnName("CEP");

            entity.Property(e => e.Cidade).HasColumnName("CIDADE");

            entity.Property(e => e.Clclassi).HasColumnName("CLCLASSI");

            entity.Property(e => e.Codigo).HasColumnName("CODIGO");

            entity.Property(e => e.Datanasc)
                .HasColumnName("DATANASC")
                .HasColumnType("datetime");

            entity.Property(e => e.Desconto).HasColumnName("DESCONTO");

            entity.Property(e => e.Endereco).HasColumnName("ENDERECO");

            entity.Property(e => e.Fone).HasColumnName("FONE");

            entity.Property(e => e.Impresso).HasColumnName("IMPRESSO");

            entity.Property(e => e.Nome).HasColumnName("NOME");

            entity.Property(e => e.Rg).HasColumnName("RG");

            entity.Property(e => e.Tipo).HasColumnName("TIPO");

            entity.Property(e => e.UltCompra)
                .HasColumnName("ULT_COMPRA")
                .HasColumnType("datetime");
        }
    }
}
