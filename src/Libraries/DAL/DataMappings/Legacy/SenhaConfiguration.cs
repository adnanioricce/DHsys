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
    public class SenhaConfiguration : BaseEntityConfiguration<Senha>
    {
        public override void Configure(EntityTypeBuilder<Senha> entity)
        {
            entity.ToTable("SENHA");

            entity.Property(e => e.Sen).HasColumnName("SEN");

            entity.Property(e => e.Sencheq).HasColumnName("SENCHEQ");

            entity.Property(e => e.Sencit).HasColumnName("SENCIT");

            entity.Property(e => e.Senclich).HasColumnName("SENCLICH");

            entity.Property(e => e.Senclip).HasColumnName("SENCLIP");

            entity.Property(e => e.Sencont).HasColumnName("SENCONT");

            entity.Property(e => e.Sendate)
                .HasColumnName("SENDATE")
                .HasColumnType("datetime");

            entity.Property(e => e.Sendefa).HasColumnName("SENDEFA");

            entity.Property(e => e.Sendesc).HasColumnName("SENDESC");

            entity.Property(e => e.Sendesc1).HasColumnName("SENDESC1");

            entity.Property(e => e.Sendesc2).HasColumnName("SENDESC2");

            entity.Property(e => e.Sendesc3).HasColumnName("SENDESC3");

            entity.Property(e => e.Sendesc4).HasColumnName("SENDESC4");

            entity.Property(e => e.Sendesc5).HasColumnName("SENDESC5");

            entity.Property(e => e.Sendesc6).HasColumnName("SENDESC6");

            entity.Property(e => e.Sendia).HasColumnName("SENDIA");

            entity.Property(e => e.Senestq).HasColumnName("SENESTQ");

            entity.Property(e => e.Senetq).HasColumnName("SENETQ");

            entity.Property(e => e.Senetqb).HasColumnName("SENETQB");

            entity.Property(e => e.Senetqe).HasColumnName("SENETQE");

            entity.Property(e => e.Senetqp).HasColumnName("SENETQP");

            entity.Property(e => e.Senfia).HasColumnName("SENFIA");

            entity.Property(e => e.Senfiacr).HasColumnName("SENFIACR");

            entity.Property(e => e.Senfiatr).HasColumnName("SENFIATR");

            entity.Property(e => e.Senfis).HasColumnName("SENFIS");

            entity.Property(e => e.Senlin).HasColumnName("SENLIN");

            entity.Property(e => e.Senman).HasColumnName("SENMAN");

            entity.Property(e => e.Senmdprint).HasColumnName("SENMDPRINT");

            entity.Property(e => e.Senmulta).HasColumnName("SENMULTA");

            entity.Property(e => e.Senniv).HasColumnName("SENNIV");

            entity.Property(e => e.Senpar).HasColumnName("SENPAR");

            entity.Property(e => e.Senpcli)
                .HasColumnName("SENPCLI")
                .HasColumnType("datetime");

            entity.Property(e => e.Senpme).HasColumnName("SENPME");

            entity.Property(e => e.Senponto).HasColumnName("SENPONTO");

            entity.Property(e => e.Senport).HasColumnName("SENPORT");

            entity.Property(e => e.Senprint).HasColumnName("SENPRINT");

            entity.Property(e => e.Senprot).HasColumnName("SENPROT");

            entity.Property(e => e.Senrec).HasColumnName("SENREC");

            entity.Property(e => e.Senrel).HasColumnName("SENREL");

            entity.Property(e => e.Senrepete).HasColumnName("SENREPETE");

            entity.Property(e => e.Senver).HasColumnName("SENVER");

            entity.Property(e => e.Senvlpon).HasColumnName("SENVLPON");
        }
    }
}
