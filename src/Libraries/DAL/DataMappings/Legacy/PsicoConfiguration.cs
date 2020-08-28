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
    public class PsicoConfiguration : BaseEntityConfiguration<Psico>
    {
        public override void Configure(EntityTypeBuilder<Psico> entity)
        {
            entity.ToTable("PSICO");

            entity.Property(e => e.Barras).HasColumnName("BARRAS");

            entity.Property(e => e.Cid).HasColumnName("CID");

            entity.Property(e => e.Cnpj).HasColumnName("CNPJ");

            entity.Property(e => e.Crm).HasColumnName("CRM");

            entity.Property(e => e.Data)
                .HasColumnName("DATA")
                .HasColumnType("datetime");

            entity.Property(e => e.Emissao)
                .HasColumnName("EMISSAO")
                .HasColumnType("datetime");

            entity.Property(e => e.Fone).HasColumnName("FONE");

            entity.Property(e => e.Fornec).HasColumnName("FORNEC");

            entity.Property(e => e.Idade).HasColumnName("IDADE");

            entity.Property(e => e.Lote).HasColumnName("LOTE");

            entity.Property(e => e.Motivo).HasColumnName("MOTIVO");

            entity.Property(e => e.Nasc)
                .HasColumnName("NASC")
                .HasColumnType("datetime");

            entity.Property(e => e.Nf).HasColumnName("NF");

            entity.Property(e => e.Nome).HasColumnName("NOME");

            entity.Property(e => e.Nomemed).HasColumnName("NOMEMED");

            entity.Property(e => e.Orgao).HasColumnName("ORGAO");

            entity.Property(e => e.Paciente).HasColumnName("PACIENTE");

            entity.Property(e => e.Porta).HasColumnName("PORTA");

            entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

            entity.Property(e => e.Prdesc).HasColumnName("PRDESC");

            entity.Property(e => e.Prolong).HasColumnName("PROLONG");

            entity.Property(e => e.Prreg).HasColumnName("PRREG");

            entity.Property(e => e.Qtde).HasColumnName("QTDE");

            entity.Property(e => e.Receita).HasColumnName("RECEITA");

            entity.Property(e => e.Rg).HasColumnName("RG");

            entity.Property(e => e.Sexo).HasColumnName("SEXO");

            entity.Property(e => e.Ticket).HasColumnName("TICKET");

            entity.Property(e => e.Tipo).HasColumnName("TIPO");

            entity.Property(e => e.Tpcons).HasColumnName("TPCONS");

            entity.Property(e => e.Tpidade).HasColumnName("TPIDADE");

            entity.Property(e => e.Tpmed).HasColumnName("TPMED");

            entity.Property(e => e.Tpreceita).HasColumnName("TPRECEITA");

            entity.Property(e => e.Uf).HasColumnName("UF");

            entity.Property(e => e.Ufcons).HasColumnName("UFCONS");

            entity.Property(e => e.Unidade).HasColumnName("UNIDADE");

            entity.Property(e => e.Usomed).HasColumnName("USOMED");
        }
    }
}
