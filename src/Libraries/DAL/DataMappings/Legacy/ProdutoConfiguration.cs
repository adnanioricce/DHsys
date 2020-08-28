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
    public class ProdutoConfiguration : BaseEntityConfiguration<Produto>
    {
        public override void Configure(EntityTypeBuilder<Produto> entity)
        {
            entity.ToTable("PRODUTO");

            entity.Property(e => e.Coddcb).HasColumnName("CODDCB");

            entity.Property(e => e.Codesta).HasColumnName("CODESTA");

            entity.Property(e => e.Codfis).HasColumnName("CODFIS");

            entity.Property(e => e.Comissao).HasColumnName("COMISSAO");

            entity.Property(e => e.DescMax).HasColumnName("DESC_MAX");

            entity.Property(e => e.EstMinimo).HasColumnName("EST_MINIMO");

            entity.Property(e => e.Etbarra).HasColumnName("ETBARRA");

            entity.Property(e => e.Etgraf).HasColumnName("ETGRAF");

            entity.Property(e => e.Prbarra).HasColumnName("PRBARRA");

            entity.Property(e => e.Prcddt)
                .HasColumnName("PRCDDT")
                .HasColumnType("datetime");

            entity.Property(e => e.Prcdimp).HasColumnName("PRCDIMP");

            entity.Property(e => e.Prcdimp2).HasColumnName("PRCDIMP2");

            entity.Property(e => e.Prcdla).HasColumnName("PRCDLA");

            entity.Property(e => e.Prcdlucr).HasColumnName("PRCDLUCR");

            entity.Property(e => e.Prcdse).HasColumnName("PRCDSE");

            entity.Property(e => e.Prclas).HasColumnName("PRCLAS");

            entity.Property(e => e.Prcodi).HasColumnName("PRCODI");

            entity.Property(e => e.Prcons).HasColumnName("PRCONS");

            entity.Property(e => e.Prconscv).HasColumnName("PRCONSCV");

            entity.Property(e => e.Prdata)
                .HasColumnName("PRDATA")
                .HasColumnType("datetime");

            entity.Property(e => e.Prdesc).HasColumnName("PRDESC");

            entity.Property(e => e.Prdesconv).HasColumnName("PRDESCONV");

            entity.Property(e => e.Prdtul)
                .HasColumnName("PRDTUL")
                .HasColumnType("datetime");

            entity.Property(e => e.Premb).HasColumnName("PREMB");

            entity.Property(e => e.Prentr).HasColumnName("PRENTR");

            entity.Property(e => e.Prestq).HasColumnName("PRESTQ");

            entity.Property(e => e.Pretiq).HasColumnName("PRETIQ");

            entity.Property(e => e.Prfabr).HasColumnName("PRFABR");

            entity.Property(e => e.Prfinal).HasColumnName("PRFINAL");

            entity.Property(e => e.Prfixa).HasColumnName("PRFIXA");

            entity.Property(e => e.Pricms).HasColumnName("PRICMS");

            entity.Property(e => e.Prinicial).HasColumnName("PRINICIAL");

            entity.Property(e => e.Prloca).HasColumnName("PRLOCA");

            entity.Property(e => e.Prlote).HasColumnName("PRLOTE");

            entity.Property(e => e.Prmesant).HasColumnName("PRMESANT");

            entity.Property(e => e.Prncms).HasColumnName("PRNCMS");

            entity.Property(e => e.Prneutro).HasColumnName("PRNEUTRO");

            entity.Property(e => e.Prnola).HasColumnName("PRNOLA");

            entity.Property(e => e.Prnose).HasColumnName("PRNOSE");

            entity.Property(e => e.Prpis).HasColumnName("PRPIS");

            entity.Property(e => e.Prpopular).HasColumnName("PRPOPULAR");

            entity.Property(e => e.Prporta).HasColumnName("PRPORTA");

            entity.Property(e => e.Prpos).HasColumnName("PRPOS");

            entity.Property(e => e.Prpret).HasColumnName("PRPRET");

            entity.Property(e => e.Prprinci).HasColumnName("PRPRINCI");

            entity.Property(e => e.Prpromo).HasColumnName("PRPROMO");

            entity.Property(e => e.Prreg).HasColumnName("PRREG");

            entity.Property(e => e.Prsal).HasColumnName("PRSAL");

            entity.Property(e => e.Prsitu).HasColumnName("PRSITU");

            entity.Property(e => e.Prtestq).HasColumnName("PRTESTQ");

            entity.Property(e => e.Prulte).HasColumnName("PRULTE");

            entity.Property(e => e.Prun).HasColumnName("PRUN");

            entity.Property(e => e.Prvalid)
                .HasColumnName("PRVALID")
                .HasColumnType("datetime");

            entity.Property(e => e.Secao).HasColumnName("SECAO");

            entity.Property(e => e.Tipo).HasColumnName("TIPO");

            entity.Property(e => e.UlVen)
                .HasColumnName("UL_VEN")
                .HasColumnType("datetime");

            entity.Property(e => e.Ultfor).HasColumnName("ULTFOR");

            entity.Property(e => e.Ultped)
                .HasColumnName("ULTPED")
                .HasColumnType("datetime");

            entity.Property(e => e.Ultpreco).HasColumnName("ULTPRECO");

            entity.Property(e => e.Vendant).HasColumnName("VENDANT");

            entity.Property(e => e.Vendatu).HasColumnName("VENDATU");

            entity.Property(e => e.Vlcomis).HasColumnName("VLCOMIS");
        }
    }
}
