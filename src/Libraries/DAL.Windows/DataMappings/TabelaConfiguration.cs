using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Windows.DataMappings
{
    public partial class TabelaMap
        : IEntityTypeConfiguration<global::Core.Entities.Legacy.Tabela>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<global::Core.Entities.Legacy.Tabela> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("tabela", "public");

            // key
            builder.HasNoKey();

            // properties
            builder.Property(t => t.Abc)
                .HasColumnName("abc")
                .HasColumnType("character varying(9)")
                .HasMaxLength(9);

            builder.Property(t => t.Ctr)
                .HasColumnName("ctr")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.Nom)
                .HasColumnName("nom")
                .HasColumnType("character varying(15)")
                .HasMaxLength(15);

            builder.Property(t => t.Des)
                .HasColumnName("des")
                .HasColumnType("character varying(45)")
                .HasMaxLength(45);

            builder.Property(t => t.Pla1)
                .HasColumnName("pla1")
                .HasColumnType("numeric(12,2)");

            builder.Property(t => t.Pco1)
                .HasColumnName("pco1")
                .HasColumnType("numeric(12,2)");

            builder.Property(t => t.Fra1)
                .HasColumnName("fra1")
                .HasColumnType("numeric(12,2)");

            builder.Property(t => t.Uni)
                .HasColumnName("uni")
                .HasColumnType("numeric(3,0)");

            builder.Property(t => t.Ipi)
                .HasColumnName("ipi")
                .HasColumnType("numeric(6,2)");

            builder.Property(t => t.Dtvig)
                .HasColumnName("dtvig")
                .HasColumnType("date");

            builder.Property(t => t.Neutro)
                .HasColumnName("neutro")
                .HasColumnType("character varying(3)")
                .HasMaxLength(3);

            builder.Property(t => t.Negpos)
                .HasColumnName("negpos")
                .HasColumnType("character varying(3)")
                .HasMaxLength(3);

            builder.Property(t => t.Custom)
                .HasColumnName("custom")
                .HasColumnType("character varying(4)")
                .HasMaxLength(4);

            builder.Property(t => t.MedDes)
                .HasColumnName("med_des")
                .HasColumnType("character varying(45)")
                .HasMaxLength(45);

            builder.Property(t => t.MedApr)
                .HasColumnName("med_apr")
                .HasColumnType("character varying(45)")
                .HasMaxLength(45);

            builder.Property(t => t.MedPrinci)
                .HasColumnName("med_princi")
                .HasColumnType("character varying(130)")
                .HasMaxLength(130);

            builder.Property(t => t.MedRegims)
                .HasColumnName("med_regims")
                .HasColumnType("character varying(13)")
                .HasMaxLength(13);

            builder.Property(t => t.LabNom)
                .HasColumnName("lab_nom")
                .HasColumnType("character varying(30)")
                .HasMaxLength(30);

            builder.Property(t => t.Barra)
                .HasColumnName("barra")
                .HasColumnType("numeric(13,0)");

            // relationships
            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "public";
            public const string Name = "tabela";
        }

        public struct Columns
        {
            public const string Abc = "abc";
            public const string Ctr = "ctr";
            public const string Nom = "nom";
            public const string Des = "des";
            public const string Pla1 = "pla1";
            public const string Pco1 = "pco1";
            public const string Fra1 = "fra1";
            public const string Uni = "uni";
            public const string Ipi = "ipi";
            public const string Dtvig = "dtvig";
            public const string Neutro = "neutro";
            public const string Negpos = "negpos";
            public const string Custom = "custom";
            public const string MedDes = "med_des";
            public const string MedApr = "med_apr";
            public const string MedPrinci = "med_princi";
            public const string MedRegims = "med_regims";
            public const string LabNom = "lab_nom";
            public const string Barra = "barra";
        }
        #endregion
    }
}
