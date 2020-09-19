using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Windows.DataMappings
{
    public partial class FuncioMap
        : IEntityTypeConfiguration<Legacy.Entities.Funcio>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Legacy.Entities.Funcio> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("funcio", "public");

            // key
            builder.HasNoKey();

            // properties
            builder.Property(t => t.Fucdem)
                .HasColumnName("fucdem")
                .HasColumnType("character varying(3)")
                .HasMaxLength(3);

            builder.Property(t => t.Fucodi)
                .HasColumnName("fucodi")
                .HasColumnType("character varying(18)")
                .HasMaxLength(18);

            builder.Property(t => t.Funome)
                .HasColumnName("funome")
                .HasColumnType("character varying(40)")
                .HasMaxLength(40);

            builder.Property(t => t.Fuend)
                .HasColumnName("fuend")
                .HasColumnType("character varying(40)")
                .HasMaxLength(40);

            builder.Property(t => t.Fubai)
                .HasColumnName("fubai")
                .HasColumnType("character varying(20)")
                .HasMaxLength(20);

            builder.Property(t => t.Fucid)
                .HasColumnName("fucid")
                .HasColumnType("character varying(20)")
                .HasMaxLength(20);

            builder.Property(t => t.Fuest)
                .HasColumnName("fuest")
                .HasColumnType("character varying(2)")
                .HasMaxLength(2);

            builder.Property(t => t.Fucep)
                .HasColumnName("fucep")
                .HasColumnType("character varying(9)")
                .HasMaxLength(9);

            builder.Property(t => t.Fufone)
                .HasColumnName("fufone")
                .HasColumnType("character varying(12)")
                .HasMaxLength(12);

            builder.Property(t => t.Fusit)
                .HasColumnName("fusit")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.Fuplano)
                .HasColumnName("fuplano")
                .HasColumnType("character varying(3)")
                .HasMaxLength(3);

            builder.Property(t => t.Fuident)
                .HasColumnName("fuident")
                .HasColumnType("character varying(18)")
                .HasMaxLength(18);

            builder.Property(t => t.Fudepto)
                .HasColumnName("fudepto")
                .HasColumnType("character varying(3)")
                .HasMaxLength(3);

            builder.Property(t => t.Totdebcr)
                .HasColumnName("totdebcr")
                .HasColumnType("numeric(12,2)");

            builder.Property(t => t.Totdebsr)
                .HasColumnName("totdebsr")
                .HasColumnType("numeric(12,2)");

            builder.Property(t => t.Demitido)
                .HasColumnName("demitido")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.Datademi)
                .HasColumnName("datademi")
                .HasColumnType("date");

            builder.Property(t => t.Impresso)
                .HasColumnName("impresso")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.Fulimite)
                .HasColumnName("fulimite")
                .HasColumnType("numeric(12,2)");

            builder.Property(t => t.Fuobs1)
                .HasColumnName("fuobs1")
                .HasColumnType("character varying(50)")
                .HasMaxLength(50);

            builder.Property(t => t.Fuobs2)
                .HasColumnName("fuobs2")
                .HasColumnType("character varying(50)")
                .HasMaxLength(50);

            builder.Property(t => t.Fuobs3)
                .HasColumnName("fuobs3")
                .HasColumnType("character varying(50)")
                .HasMaxLength(50);

            builder.Property(t => t.Fubloq)
                .HasColumnName("fubloq")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.Codgolden)
                .HasColumnName("codgolden")
                .HasColumnType("character varying(6)")
                .HasMaxLength(6);

            builder.Property(t => t.Fudata)
                .HasColumnName("fudata")
                .HasColumnType("date");

            // relationships
            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "public";
            public const string Name = "funcio";
        }

        public struct Columns
        {
            public const string Fucdem = "fucdem";
            public const string Fucodi = "fucodi";
            public const string Funome = "funome";
            public const string Fuend = "fuend";
            public const string Fubai = "fubai";
            public const string Fucid = "fucid";
            public const string Fuest = "fuest";
            public const string Fucep = "fucep";
            public const string Fufone = "fufone";
            public const string Fusit = "fusit";
            public const string Fuplano = "fuplano";
            public const string Fuident = "fuident";
            public const string Fudepto = "fudepto";
            public const string Totdebcr = "totdebcr";
            public const string Totdebsr = "totdebsr";
            public const string Demitido = "demitido";
            public const string Datademi = "datademi";
            public const string Impresso = "impresso";
            public const string Fulimite = "fulimite";
            public const string Fuobs1 = "fuobs1";
            public const string Fuobs2 = "fuobs2";
            public const string Fuobs3 = "fuobs3";
            public const string Fubloq = "fubloq";
            public const string Codgolden = "codgolden";
            public const string Fudata = "fudata";
        }
        #endregion
    }
}
