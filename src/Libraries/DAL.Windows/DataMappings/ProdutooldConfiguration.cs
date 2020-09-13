using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Windows.DataMappings
{
    public partial class ProdutooldMap
        : IEntityTypeConfiguration<global::Core.Entities.Legacy.Produtoold>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<global::Core.Entities.Legacy.Produtoold> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("produtoold", "public");

            // key
            builder.HasNoKey();

            // properties
            builder.Property(t => t.Prcodi)
                .HasColumnName("prcodi")
                .HasColumnType("character varying(6)")
                .HasMaxLength(6);

            builder.Property(t => t.Prbarra)
                .HasColumnName("prbarra")
                .HasColumnType("character varying(13)")
                .HasMaxLength(13);

            builder.Property(t => t.Prreg)
                .HasColumnName("prreg")
                .HasColumnType("character varying(13)")
                .HasMaxLength(13);

            builder.Property(t => t.Prdesc)
                .HasColumnName("prdesc")
                .HasColumnType("character varying(30)")
                .HasMaxLength(30);

            builder.Property(t => t.Prlote)
                .HasColumnName("prlote")
                .HasColumnType("character varying(10)")
                .HasMaxLength(10);

            builder.Property(t => t.Prpos)
                .HasColumnName("prpos")
                .HasColumnType("character varying(3)")
                .HasMaxLength(3);

            builder.Property(t => t.Prsal)
                .HasColumnName("prsal")
                .HasColumnType("character varying(4)")
                .HasMaxLength(4);

            builder.Property(t => t.Prneutro)
                .HasColumnName("prneutro")
                .HasColumnType("character varying(3)")
                .HasMaxLength(3);

            builder.Property(t => t.Prcdla)
                .HasColumnName("prcdla")
                .HasColumnType("character varying(4)")
                .HasMaxLength(4);

            builder.Property(t => t.Prnola)
                .HasColumnName("prnola")
                .HasColumnType("character varying(15)")
                .HasMaxLength(15);

            builder.Property(t => t.Prcons)
                .HasColumnName("prcons")
                .HasColumnType("numeric(12,2)");

            builder.Property(t => t.Prconscv)
                .HasColumnName("prconscv")
                .HasColumnType("numeric(12,2)");

            builder.Property(t => t.Prfabr)
                .HasColumnName("prfabr")
                .HasColumnType("numeric(12,2)");

            builder.Property(t => t.Prfixa)
                .HasColumnName("prfixa")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.Prpromo)
                .HasColumnName("prpromo")
                .HasColumnType("numeric(12,2)");

            builder.Property(t => t.Vlcomis)
                .HasColumnName("vlcomis")
                .HasColumnType("numeric(12,2)");

            builder.Property(t => t.Prestq)
                .HasColumnName("prestq")
                .HasColumnType("numeric(4,0)");

            builder.Property(t => t.Prinicial)
                .HasColumnName("prinicial")
                .HasColumnType("numeric(4,0)");

            builder.Property(t => t.Prtestq)
                .HasColumnName("prtestq")
                .HasColumnType("numeric(4,0)");

            builder.Property(t => t.Prcdse)
                .HasColumnName("prcdse")
                .HasColumnType("character varying(2)")
                .HasMaxLength(2);

            builder.Property(t => t.Prloca)
                .HasColumnName("prloca")
                .HasColumnType("character varying(5)")
                .HasMaxLength(5);

            builder.Property(t => t.Prnose)
                .HasColumnName("prnose")
                .HasColumnType("character varying(15)")
                .HasMaxLength(15);

            builder.Property(t => t.Pretiq)
                .HasColumnName("pretiq")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.Coddcb)
                .HasColumnName("coddcb")
                .HasColumnType("character varying(5)")
                .HasMaxLength(5);

            builder.Property(t => t.Etbarra)
                .HasColumnName("etbarra")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.Etgraf)
                .HasColumnName("etgraf")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.Prpret)
                .HasColumnName("prpret")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.Prporta)
                .HasColumnName("prporta")
                .HasColumnType("character varying(6)")
                .HasMaxLength(6);

            builder.Property(t => t.Prsitu)
                .HasColumnName("prsitu")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.Prulte)
                .HasColumnName("prulte")
                .HasColumnType("numeric(6,0)");

            builder.Property(t => t.Prdtul)
                .HasColumnName("prdtul")
                .HasColumnType("date");

            builder.Property(t => t.Prcddt)
                .HasColumnName("prcddt")
                .HasColumnType("date");

            builder.Property(t => t.Prdata)
                .HasColumnName("prdata")
                .HasColumnType("date");

            builder.Property(t => t.Prcdlucr)
                .HasColumnName("prcdlucr")
                .HasColumnType("numeric(10,6)");

            builder.Property(t => t.Pricms)
                .HasColumnName("pricms")
                .HasColumnType("numeric(2,0)");

            builder.Property(t => t.Tipo)
                .HasColumnName("tipo")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.DescMax)
                .HasColumnName("desc_max")
                .HasColumnType("numeric(5,2)");

            builder.Property(t => t.Comissao)
                .HasColumnName("comissao")
                .HasColumnType("numeric(5,2)");

            builder.Property(t => t.EstMinimo)
                .HasColumnName("est_minimo")
                .HasColumnType("numeric(6,0)");

            builder.Property(t => t.Prcdimp)
                .HasColumnName("prcdimp")
                .HasColumnType("character varying(2)")
                .HasMaxLength(2);

            builder.Property(t => t.Prcdimp2)
                .HasColumnName("prcdimp2")
                .HasColumnType("character varying(2)")
                .HasMaxLength(2);

            builder.Property(t => t.Premb)
                .HasColumnName("premb")
                .HasColumnType("numeric(4,0)");

            builder.Property(t => t.Prentr)
                .HasColumnName("prentr")
                .HasColumnType("numeric(6,0)");

            builder.Property(t => t.UlVen)
                .HasColumnName("ul_ven")
                .HasColumnType("date");

            builder.Property(t => t.Ultped)
                .HasColumnName("ultped")
                .HasColumnType("date");

            builder.Property(t => t.Ultfor)
                .HasColumnName("ultfor")
                .HasColumnType("character varying(15)")
                .HasMaxLength(15);

            builder.Property(t => t.Prclas)
                .HasColumnName("prclas")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.Prmesant)
                .HasColumnName("prmesant")
                .HasColumnType("numeric(12,2)");

            builder.Property(t => t.Ultpreco)
                .HasColumnName("ultpreco")
                .HasColumnType("numeric(12,2)");

            builder.Property(t => t.Prdesconv)
                .HasColumnName("prdesconv")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.Prpopular)
                .HasColumnName("prpopular")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.Codesta)
                .HasColumnName("codesta")
                .HasColumnType("character varying(9)")
                .HasMaxLength(9);

            builder.Property(t => t.Prprinci)
                .HasColumnName("prprinci")
                .HasColumnType("character varying(130)")
                .HasMaxLength(130);

            builder.Property(t => t.Codfis)
                .HasColumnName("codfis")
                .HasColumnType("character varying(10)")
                .HasMaxLength(10);

            builder.Property(t => t.Secao)
                .HasColumnName("secao")
                .HasColumnType("character varying(2)")
                .HasMaxLength(2);

            builder.Property(t => t.Prpis)
                .HasColumnName("prpis")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.Prun)
                .HasColumnName("prun")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.Prncms)
                .HasColumnName("prncms")
                .HasColumnType("character varying(8)")
                .HasMaxLength(8);

            builder.Property(t => t.Prvalid)
                .HasColumnName("prvalid")
                .HasColumnType("date");

            builder.Property(t => t.Vendatu)
                .HasColumnName("vendatu")
                .HasColumnType("numeric(4,0)");

            builder.Property(t => t.Vendant)
                .HasColumnName("vendant")
                .HasColumnType("numeric(4,0)");

            // relationships
            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "public";
            public const string Name = "produtoold";
        }

        public struct Columns
        {
            public const string Prcodi = "prcodi";
            public const string Prbarra = "prbarra";
            public const string Prreg = "prreg";
            public const string Prdesc = "prdesc";
            public const string Prlote = "prlote";
            public const string Prpos = "prpos";
            public const string Prsal = "prsal";
            public const string Prneutro = "prneutro";
            public const string Prcdla = "prcdla";
            public const string Prnola = "prnola";
            public const string Prcons = "prcons";
            public const string Prconscv = "prconscv";
            public const string Prfabr = "prfabr";
            public const string Prfixa = "prfixa";
            public const string Prpromo = "prpromo";
            public const string Vlcomis = "vlcomis";
            public const string Prestq = "prestq";
            public const string Prinicial = "prinicial";
            public const string Prtestq = "prtestq";
            public const string Prcdse = "prcdse";
            public const string Prloca = "prloca";
            public const string Prnose = "prnose";
            public const string Pretiq = "pretiq";
            public const string Coddcb = "coddcb";
            public const string Etbarra = "etbarra";
            public const string Etgraf = "etgraf";
            public const string Prpret = "prpret";
            public const string Prporta = "prporta";
            public const string Prsitu = "prsitu";
            public const string Prulte = "prulte";
            public const string Prdtul = "prdtul";
            public const string Prcddt = "prcddt";
            public const string Prdata = "prdata";
            public const string Prcdlucr = "prcdlucr";
            public const string Pricms = "pricms";
            public const string Tipo = "tipo";
            public const string DescMax = "desc_max";
            public const string Comissao = "comissao";
            public const string EstMinimo = "est_minimo";
            public const string Prcdimp = "prcdimp";
            public const string Prcdimp2 = "prcdimp2";
            public const string Premb = "premb";
            public const string Prentr = "prentr";
            public const string UlVen = "ul_ven";
            public const string Ultped = "ultped";
            public const string Ultfor = "ultfor";
            public const string Prclas = "prclas";
            public const string Prmesant = "prmesant";
            public const string Ultpreco = "ultpreco";
            public const string Prdesconv = "prdesconv";
            public const string Prpopular = "prpopular";
            public const string Codesta = "codesta";
            public const string Prprinci = "prprinci";
            public const string Codfis = "codfis";
            public const string Secao = "secao";
            public const string Prpis = "prpis";
            public const string Prun = "prun";
            public const string Prncms = "prncms";
            public const string Prvalid = "prvalid";
            public const string Vendatu = "vendatu";
            public const string Vendant = "vendant";
        }
        #endregion
    }
}
