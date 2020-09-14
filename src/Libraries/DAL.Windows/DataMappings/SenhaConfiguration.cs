using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Windows.DataMappings
{
    public partial class SenhaMap
        : IEntityTypeConfiguration<global::Core.Entities.Legacy.Senha>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<global::Core.Entities.Legacy.Senha> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("senha", "public");

            // key
            builder.HasNoKey();

            // properties
            builder.Property(t => t.Sen)
                .HasColumnName("sen")
                .HasColumnType("character varying(8)")
                .HasMaxLength(8);

            builder.Property(t => t.Sencheq)
                .HasColumnName("sencheq")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.Sencit)
                .HasColumnName("sencit")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.Senclich)
                .HasColumnName("senclich")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.Senclip)
                .HasColumnName("senclip")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.Sencont)
                .HasColumnName("sencont")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.Sendate)
                .HasColumnName("sendate")
                .HasColumnType("date");

            builder.Property(t => t.Sendefa)
                .HasColumnName("sendefa")
                .HasColumnType("character varying(2)")
                .HasMaxLength(2);

            builder.Property(t => t.Sendesc)
                .HasColumnName("sendesc")
                .HasColumnType("numeric(10,2)");

            builder.Property(t => t.Sendesc1)
                .HasColumnName("sendesc1")
                .HasColumnType("numeric(10,2)");

            builder.Property(t => t.Sendesc2)
                .HasColumnName("sendesc2")
                .HasColumnType("numeric(10,2)");

            builder.Property(t => t.Sendesc3)
                .HasColumnName("sendesc3")
                .HasColumnType("numeric(10,2)");

            builder.Property(t => t.Sendesc4)
                .HasColumnName("sendesc4")
                .HasColumnType("numeric(10,2)");

            builder.Property(t => t.Sendesc5)
                .HasColumnName("sendesc5")
                .HasColumnType("numeric(10,2)");

            builder.Property(t => t.Sendesc6)
                .HasColumnName("sendesc6")
                .HasColumnType("numeric(10,2)");

            builder.Property(t => t.Sendia)
                .HasColumnName("sendia")
                .HasColumnType("numeric(3,0)");

            builder.Property(t => t.Senestq)
                .HasColumnName("senestq")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.Senetq)
                .HasColumnName("senetq")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.Senetqb)
                .HasColumnName("senetqb")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.Senetqe)
                .HasColumnName("senetqe")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.Senetqp)
                .HasColumnName("senetqp")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.Senfia)
                .HasColumnName("senfia")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.Senfiacr)
                .HasColumnName("senfiacr")
                .HasColumnType("numeric(10,2)");

            builder.Property(t => t.Senfiatr)
                .HasColumnName("senfiatr")
                .HasColumnType("numeric(3,0)");

            builder.Property(t => t.Senfis)
                .HasColumnName("senfis")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.Senlin)
                .HasColumnName("senlin")
                .HasColumnType("numeric(3,0)");

            builder.Property(t => t.Senman)
                .HasColumnName("senman")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.Senmdprint)
                .HasColumnName("senmdprint")
                .HasColumnType("numeric(2,0)");

            builder.Property(t => t.Senmulta)
                .HasColumnName("senmulta")
                .HasColumnType("numeric(5,2)");

            builder.Property(t => t.Senniv)
                .HasColumnName("senniv")
                .HasColumnType("character varying(10)")
                .HasMaxLength(10);

            builder.Property(t => t.Senpar)
                .HasColumnName("senpar")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.Senpcli)
                .HasColumnName("senpcli")
                .HasColumnType("date");

            builder.Property(t => t.Senpme)
                .HasColumnName("senpme")
                .HasColumnType("numeric(5,0)");

            builder.Property(t => t.Senponto)
                .HasColumnName("senponto")
                .HasColumnType("numeric(5,0)");

            builder.Property(t => t.Senport)
                .HasColumnName("senport")
                .HasColumnType("character varying(4)")
                .HasMaxLength(4);

            builder.Property(t => t.Senprint)
                .HasColumnName("senprint")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.Senprot)
                .HasColumnName("senprot")
                .HasColumnType("character varying(12)")
                .HasMaxLength(12);

            builder.Property(t => t.Senrec)
                .HasColumnName("senrec")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.Senrel)
                .HasColumnName("senrel")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.Senrepete)
                .HasColumnName("senrepete")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.Senver)
                .HasColumnName("senver")
                .HasColumnType("character varying(5)")
                .HasMaxLength(5);

            builder.Property(t => t.Senvlpon)
                .HasColumnName("senvlpon")
                .HasColumnType("numeric(10,2)");

            // relationships
            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "public";
            public const string Name = "senha";
        }

        public struct Columns
        {
            public const string Sen = "sen";
            public const string Sencheq = "sencheq";
            public const string Sencit = "sencit";
            public const string Senclich = "senclich";
            public const string Senclip = "senclip";
            public const string Sencont = "sencont";
            public const string Sendate = "sendate";
            public const string Sendefa = "sendefa";
            public const string Sendesc = "sendesc";
            public const string Sendesc1 = "sendesc1";
            public const string Sendesc2 = "sendesc2";
            public const string Sendesc3 = "sendesc3";
            public const string Sendesc4 = "sendesc4";
            public const string Sendesc5 = "sendesc5";
            public const string Sendesc6 = "sendesc6";
            public const string Sendia = "sendia";
            public const string Senestq = "senestq";
            public const string Senetq = "senetq";
            public const string Senetqb = "senetqb";
            public const string Senetqe = "senetqe";
            public const string Senetqp = "senetqp";
            public const string Senfia = "senfia";
            public const string Senfiacr = "senfiacr";
            public const string Senfiatr = "senfiatr";
            public const string Senfis = "senfis";
            public const string Senlin = "senlin";
            public const string Senman = "senman";
            public const string Senmdprint = "senmdprint";
            public const string Senmulta = "senmulta";
            public const string Senniv = "senniv";
            public const string Senpar = "senpar";
            public const string Senpcli = "senpcli";
            public const string Senpme = "senpme";
            public const string Senponto = "senponto";
            public const string Senport = "senport";
            public const string Senprint = "senprint";
            public const string Senprot = "senprot";
            public const string Senrec = "senrec";
            public const string Senrel = "senrel";
            public const string Senrepete = "senrepete";
            public const string Senver = "senver";
            public const string Senvlpon = "senvlpon";
        }
        #endregion
    }
}
