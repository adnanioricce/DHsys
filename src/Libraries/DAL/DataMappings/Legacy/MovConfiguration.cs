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
    public class MovConfiguration : BaseEntityConfiguration<Mov>
    {
        public override void Configure(EntityTypeBuilder<Mov> entity)
        {
            entity.ToTable("MOV");

            entity.Property(e => e.Admcart).HasColumnName("ADMCART");

            entity.Property(e => e.Bacodi).HasColumnName("BACODI");

            entity.Property(e => e.Caixa).HasColumnName("CAIXA");

            entity.Property(e => e.Cancelado).HasColumnName("CANCELADO");

            entity.Property(e => e.Cartaoc).HasColumnName("CARTAOC");

            entity.Property(e => e.Cheque).HasColumnName("CHEQUE");

            entity.Property(e => e.Chequepre).HasColumnName("CHEQUEPRE");

            entity.Property(e => e.Codcli).HasColumnName("CODCLI");

            entity.Property(e => e.Cpf).HasColumnName("CPF");

            entity.Property(e => e.Data)
                .HasColumnName("DATA")
                .HasColumnType("datetime");

            entity.Property(e => e.Dinheiro).HasColumnName("DINHEIRO");

            entity.Property(e => e.Ecf).HasColumnName("ECF");

            entity.Property(e => e.Hora).HasColumnName("HORA");

            entity.Property(e => e.NFiscal).HasColumnName("N_FISCAL");

            entity.Property(e => e.Nome).HasColumnName("NOME");

            entity.Property(e => e.Popular).HasColumnName("POPULAR");

            entity.Property(e => e.Ticket).HasColumnName("TICKET");

            entity.Property(e => e.Tipo).HasColumnName("TIPO");

            entity.Property(e => e.TotAnt).HasColumnName("TOT_ANT");

            entity.Property(e => e.TotVen).HasColumnName("TOT_VEN");

            entity.Property(e => e.Tpvd).HasColumnName("TPVD");
        }
    }
}
