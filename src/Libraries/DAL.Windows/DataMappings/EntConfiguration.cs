using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Windows.DataMappings
{
    public partial class EntMap
        : IEntityTypeConfiguration<Legacy.Entities.Ent>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Legacy.Entities.Ent> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("ent", "public");

            // key
            builder.HasNoKey();

            // properties
            builder.Property(t => t.Endata)
                .HasColumnName("endata")
                .HasColumnType("date");

            builder.Property(t => t.Prcodi)
                .HasColumnName("prcodi")
                .HasColumnType("character varying(6)")
                .HasMaxLength(6);

            builder.Property(t => t.Enqtde)
                .HasColumnName("enqtde")
                .HasColumnType("numeric(6,0)");

            builder.Property(t => t.Envalo)
                .HasColumnName("envalo")
                .HasColumnType("numeric(10,2)");

            builder.Property(t => t.Prfabr)
                .HasColumnName("prfabr")
                .HasColumnType("numeric(10,2)");

            builder.Property(t => t.Impresso)
                .HasColumnName("impresso")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.Impretq)
                .HasColumnName("impretq")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.Etiqueta)
                .HasColumnName("etiqueta")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.Soetiq)
                .HasColumnName("soetiq")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.Usuario)
                .HasColumnName("usuario")
                .HasColumnType("character varying(6)")
                .HasMaxLength(6);

            builder.Property(t => t.Estant)
                .HasColumnName("estant")
                .HasColumnType("numeric(6,0)");

            builder.Property(t => t.Desconto)
                .HasColumnName("desconto")
                .HasColumnType("numeric(5,2)");

            builder.Property(t => t.Descfin)
                .HasColumnName("descfin")
                .HasColumnType("numeric(12,2)");

            builder.Property(t => t.Descrep)
                .HasColumnName("descrep")
                .HasColumnType("numeric(12,2)");

            builder.Property(t => t.Envalodes)
                .HasColumnName("envalodes")
                .HasColumnType("numeric(10,2)");

            builder.Property(t => t.Fornec)
                .HasColumnName("fornec")
                .HasColumnType("character varying(4)")
                .HasMaxLength(4);

            builder.Property(t => t.Notafis)
                .HasColumnName("notafis")
                .HasColumnType("character varying(6)")
                .HasMaxLength(6);

            // relationships
            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "public";
            public const string Name = "ent";
        }

        public struct Columns
        {
            public const string Endata = "endata";
            public const string Prcodi = "prcodi";
            public const string Enqtde = "enqtde";
            public const string Envalo = "envalo";
            public const string Prfabr = "prfabr";
            public const string Impresso = "impresso";
            public const string Impretq = "impretq";
            public const string Etiqueta = "etiqueta";
            public const string Soetiq = "soetiq";
            public const string Usuario = "usuario";
            public const string Estant = "estant";
            public const string Desconto = "desconto";
            public const string Descfin = "descfin";
            public const string Descrep = "descrep";
            public const string Envalodes = "envalodes";
            public const string Fornec = "fornec";
            public const string Notafis = "notafis";
        }
        #endregion
    }
}
