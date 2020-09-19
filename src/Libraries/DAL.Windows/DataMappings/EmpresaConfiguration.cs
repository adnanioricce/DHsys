using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Windows.DataMappings
{
    public partial class EmpresaMap
        : IEntityTypeConfiguration<Legacy.Entities.Empresa>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Legacy.Entities.Empresa> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("empresa", "public");

            // key
            builder.HasNoKey();

            // properties
            builder.Property(t => t.Emcodi)
                .HasColumnName("emcodi")
                .HasColumnType("character varying(3)")
                .HasMaxLength(3);

            builder.Property(t => t.Emraso)
                .HasColumnName("emraso")
                .HasColumnType("character varying(40)")
                .HasMaxLength(40);

            builder.Property(t => t.Emende)
                .HasColumnName("emende")
                .HasColumnType("character varying(40)")
                .HasMaxLength(40);

            builder.Property(t => t.Emnume)
                .HasColumnName("emnume")
                .HasColumnType("character varying(10)")
                .HasMaxLength(10);

            builder.Property(t => t.Emcida)
                .HasColumnName("emcida")
                .HasColumnType("character varying(25)")
                .HasMaxLength(25);

            builder.Property(t => t.Embair)
                .HasColumnName("embair")
                .HasColumnType("character varying(25)")
                .HasMaxLength(25);

            builder.Property(t => t.Emesta)
                .HasColumnName("emesta")
                .HasColumnType("character varying(2)")
                .HasMaxLength(2);

            builder.Property(t => t.Emcont)
                .HasColumnName("emcont")
                .HasColumnType("character varying(15)")
                .HasMaxLength(15);

            builder.Property(t => t.Emtele)
                .HasColumnName("emtele")
                .HasColumnType("character varying(15)")
                .HasMaxLength(15);

            builder.Property(t => t.Emcgce)
                .HasColumnName("emcgce")
                .HasColumnType("character varying(20)")
                .HasMaxLength(20);

            builder.Property(t => t.Eminsc)
                .HasColumnName("eminsc")
                .HasColumnType("character varying(20)")
                .HasMaxLength(20);

            builder.Property(t => t.Emfax)
                .HasColumnName("emfax")
                .HasColumnType("character varying(15)")
                .HasMaxLength(15);

            builder.Property(t => t.Emcep)
                .HasColumnName("emcep")
                .HasColumnType("character varying(9)")
                .HasMaxLength(9);

            builder.Property(t => t.Emfilial)
                .HasColumnName("emfilial")
                .HasColumnType("character varying(5)")
                .HasMaxLength(5);

            builder.Property(t => t.Emlimite)
                .HasColumnName("emlimite")
                .HasColumnType("numeric(12,2)");

            builder.Property(t => t.DesTick)
                .HasColumnName("des_tick")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.PercDesc)
                .HasColumnName("perc_desc")
                .HasColumnType("numeric(5,2)");

            builder.Property(t => t.DesNota)
                .HasColumnName("des_nota")
                .HasColumnType("numeric(5,2)");

            builder.Property(t => t.DesFech)
                .HasColumnName("des_fech")
                .HasColumnType("numeric(5,2)");

            builder.Property(t => t.Emperf)
                .HasColumnName("emperf")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.Emprint)
                .HasColumnName("emprint")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.DesPerf)
                .HasColumnName("des_perf")
                .HasColumnType("numeric(5,2)");

            builder.Property(t => t.DesRest)
                .HasColumnName("des_rest")
                .HasColumnType("numeric(5,2)");

            builder.Property(t => t.DesEtic)
                .HasColumnName("des_etic")
                .HasColumnType("numeric(5,2)");

            builder.Property(t => t.DesB)
                .HasColumnName("des_b")
                .HasColumnType("numeric(5,2)");

            builder.Property(t => t.DesVar)
                .HasColumnName("des_var")
                .HasColumnType("numeric(5,2)");

            builder.Property(t => t.DesAce)
                .HasColumnName("des_ace")
                .HasColumnType("numeric(5,2)");

            builder.Property(t => t.Descplac)
                .HasColumnName("descplac")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.Libperf)
                .HasColumnName("libperf")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.Emcontrato)
                .HasColumnName("emcontrato")
                .HasColumnType("character varying(4)")
                .HasMaxLength(4);

            builder.Property(t => t.Codgolden)
                .HasColumnName("codgolden")
                .HasColumnType("character varying(6)")
                .HasMaxLength(6);

            builder.Property(t => t.Emdebito)
                .HasColumnName("emdebito")
                .HasColumnType("numeric(12,2)");

            builder.Property(t => t.Emfech)
                .HasColumnName("emfech")
                .HasColumnType("character varying(2)")
                .HasMaxLength(2);

            builder.Property(t => t.Emguia)
                .HasColumnName("emguia")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.Emetico)
                .HasColumnName("emetico")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.Emobs)
                .HasColumnName("emobs")
                .HasColumnType("character varying(50)")
                .HasMaxLength(50);

            builder.Property(t => t.Emobs1)
                .HasColumnName("emobs1")
                .HasColumnType("character varying(50)")
                .HasMaxLength(50);

            builder.Property(t => t.Embloq)
                .HasColumnName("embloq")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.Vidalk)
                .HasColumnName("vidalk")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.Vidaav)
                .HasColumnName("vidaav")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.Vidapc)
                .HasColumnName("vidapc")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.Ibgeest)
                .HasColumnName("ibgeest")
                .HasColumnType("character varying(2)")
                .HasMaxLength(2);

            builder.Property(t => t.Ibgemun)
                .HasColumnName("ibgemun")
                .HasColumnType("character varying(5)")
                .HasMaxLength(5);

            builder.Property(t => t.Emreceita)
                .HasColumnName("emreceita")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            // relationships
            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "public";
            public const string Name = "empresa";
        }

        public struct Columns
        {
            public const string Emcodi = "emcodi";
            public const string Emraso = "emraso";
            public const string Emende = "emende";
            public const string Emnume = "emnume";
            public const string Emcida = "emcida";
            public const string Embair = "embair";
            public const string Emesta = "emesta";
            public const string Emcont = "emcont";
            public const string Emtele = "emtele";
            public const string Emcgce = "emcgce";
            public const string Eminsc = "eminsc";
            public const string Emfax = "emfax";
            public const string Emcep = "emcep";
            public const string Emfilial = "emfilial";
            public const string Emlimite = "emlimite";
            public const string DesTick = "des_tick";
            public const string PercDesc = "perc_desc";
            public const string DesNota = "des_nota";
            public const string DesFech = "des_fech";
            public const string Emperf = "emperf";
            public const string Emprint = "emprint";
            public const string DesPerf = "des_perf";
            public const string DesRest = "des_rest";
            public const string DesEtic = "des_etic";
            public const string Desb = "des_b";
            public const string DesVar = "des_var";
            public const string DesAce = "des_ace";
            public const string Descplac = "descplac";
            public const string Libperf = "libperf";
            public const string Emcontrato = "emcontrato";
            public const string Codgolden = "codgolden";
            public const string Emdebito = "emdebito";
            public const string Emfech = "emfech";
            public const string Emguia = "emguia";
            public const string Emetico = "emetico";
            public const string Emobs = "emobs";
            public const string Emobs1 = "emobs1";
            public const string Embloq = "embloq";
            public const string Vidalk = "vidalk";
            public const string Vidaav = "vidaav";
            public const string Vidapc = "vidapc";
            public const string Ibgeest = "ibgeest";
            public const string Ibgemun = "ibgemun";
            public const string Emreceita = "emreceita";
        }
        #endregion
    }
}
