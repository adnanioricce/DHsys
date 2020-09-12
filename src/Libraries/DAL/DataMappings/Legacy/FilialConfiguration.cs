using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Mappings.Legacy
{
    public partial class FilialMap
        : IEntityTypeConfiguration<global::Core.Entities.Legacy.Filial>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<global::Core.Entities.Legacy.Filial> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("filial", "public");

            // key
            builder.HasNoKey();

            // properties
            builder.Property(t => t.Filcodi)
                .HasColumnName("filcodi")
                .HasColumnType("character varying(3)")
                .HasMaxLength(3);

            builder.Property(t => t.Filnome)
                .HasColumnName("filnome")
                .HasColumnType("character varying(40)")
                .HasMaxLength(40);

            builder.Property(t => t.Filende)
                .HasColumnName("filende")
                .HasColumnType("character varying(40)")
                .HasMaxLength(40);

            builder.Property(t => t.Filcida)
                .HasColumnName("filcida")
                .HasColumnType("character varying(25)")
                .HasMaxLength(25);

            builder.Property(t => t.Filesta)
                .HasColumnName("filesta")
                .HasColumnType("character varying(2)")
                .HasMaxLength(2);

            builder.Property(t => t.Filcont)
                .HasColumnName("filcont")
                .HasColumnType("character varying(15)")
                .HasMaxLength(15);

            builder.Property(t => t.Filtele)
                .HasColumnName("filtele")
                .HasColumnType("character varying(15)")
                .HasMaxLength(15);

            builder.Property(t => t.Filcgce)
                .HasColumnName("filcgce")
                .HasColumnType("character varying(20)")
                .HasMaxLength(20);

            builder.Property(t => t.Filinsc)
                .HasColumnName("filinsc")
                .HasColumnType("character varying(20)")
                .HasMaxLength(20);

            builder.Property(t => t.Filfax)
                .HasColumnName("filfax")
                .HasColumnType("character varying(15)")
                .HasMaxLength(15);

            builder.Property(t => t.Filcep)
                .HasColumnName("filcep")
                .HasColumnType("character varying(9)")
                .HasMaxLength(9);

            builder.Property(t => t.Subsec1)
                .HasColumnName("subsec1")
                .HasColumnType("character varying(2)")
                .HasMaxLength(2);

            builder.Property(t => t.Desc1)
                .HasColumnName("desc1")
                .HasColumnType("numeric(5,2)");

            builder.Property(t => t.Aplica1)
                .HasColumnName("aplica1")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.Subsec2)
                .HasColumnName("subsec2")
                .HasColumnType("character varying(2)")
                .HasMaxLength(2);

            builder.Property(t => t.Desc2)
                .HasColumnName("desc2")
                .HasColumnType("numeric(5,2)");

            builder.Property(t => t.Aplica2)
                .HasColumnName("aplica2")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.Subsec3)
                .HasColumnName("subsec3")
                .HasColumnType("character varying(2)")
                .HasMaxLength(2);

            builder.Property(t => t.Desc3)
                .HasColumnName("desc3")
                .HasColumnType("numeric(5,2)");

            builder.Property(t => t.Aplica3)
                .HasColumnName("aplica3")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.Subsec4)
                .HasColumnName("subsec4")
                .HasColumnType("character varying(2)")
                .HasMaxLength(2);

            builder.Property(t => t.Desc4)
                .HasColumnName("desc4")
                .HasColumnType("numeric(5,2)");

            builder.Property(t => t.Aplica4)
                .HasColumnName("aplica4")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.Subsec5)
                .HasColumnName("subsec5")
                .HasColumnType("character varying(2)")
                .HasMaxLength(2);

            builder.Property(t => t.Desc5)
                .HasColumnName("desc5")
                .HasColumnType("numeric(5,2)");

            builder.Property(t => t.Aplica5)
                .HasColumnName("aplica5")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.Subsec6)
                .HasColumnName("subsec6")
                .HasColumnType("character varying(2)")
                .HasMaxLength(2);

            builder.Property(t => t.Desc6)
                .HasColumnName("desc6")
                .HasColumnType("numeric(5,2)");

            builder.Property(t => t.Aplica6)
                .HasColumnName("aplica6")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.Subsec7)
                .HasColumnName("subsec7")
                .HasColumnType("character varying(2)")
                .HasMaxLength(2);

            builder.Property(t => t.Desc7)
                .HasColumnName("desc7")
                .HasColumnType("numeric(5,2)");

            builder.Property(t => t.Aplica7)
                .HasColumnName("aplica7")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.Subsec8)
                .HasColumnName("subsec8")
                .HasColumnType("character varying(2)")
                .HasMaxLength(2);

            builder.Property(t => t.Desc8)
                .HasColumnName("desc8")
                .HasColumnType("numeric(5,2)");

            builder.Property(t => t.Aplica8)
                .HasColumnName("aplica8")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.Subsec9)
                .HasColumnName("subsec9")
                .HasColumnType("character varying(2)")
                .HasMaxLength(2);

            builder.Property(t => t.Desc9)
                .HasColumnName("desc9")
                .HasColumnType("numeric(5,2)");

            builder.Property(t => t.Aplica9)
                .HasColumnName("aplica9")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.Subsec10)
                .HasColumnName("subsec10")
                .HasColumnType("character varying(2)")
                .HasMaxLength(2);

            builder.Property(t => t.Desc10)
                .HasColumnName("desc10")
                .HasColumnType("numeric(5,2)");

            builder.Property(t => t.Aplica10)
                .HasColumnName("aplica10")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            // relationships
            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "public";
            public const string Name = "filial";
        }

        public struct Columns
        {
            public const string Filcodi = "filcodi";
            public const string Filnome = "filnome";
            public const string Filende = "filende";
            public const string Filcida = "filcida";
            public const string Filesta = "filesta";
            public const string Filcont = "filcont";
            public const string Filtele = "filtele";
            public const string Filcgce = "filcgce";
            public const string Filinsc = "filinsc";
            public const string Filfax = "filfax";
            public const string Filcep = "filcep";
            public const string Subsec1 = "subsec1";
            public const string Desc1 = "desc1";
            public const string Aplica1 = "aplica1";
            public const string Subsec2 = "subsec2";
            public const string Desc2 = "desc2";
            public const string Aplica2 = "aplica2";
            public const string Subsec3 = "subsec3";
            public const string Desc3 = "desc3";
            public const string Aplica3 = "aplica3";
            public const string Subsec4 = "subsec4";
            public const string Desc4 = "desc4";
            public const string Aplica4 = "aplica4";
            public const string Subsec5 = "subsec5";
            public const string Desc5 = "desc5";
            public const string Aplica5 = "aplica5";
            public const string Subsec6 = "subsec6";
            public const string Desc6 = "desc6";
            public const string Aplica6 = "aplica6";
            public const string Subsec7 = "subsec7";
            public const string Desc7 = "desc7";
            public const string Aplica7 = "aplica7";
            public const string Subsec8 = "subsec8";
            public const string Desc8 = "desc8";
            public const string Aplica8 = "aplica8";
            public const string Subsec9 = "subsec9";
            public const string Desc9 = "desc9";
            public const string Aplica9 = "aplica9";
            public const string Subsec10 = "subsec10";
            public const string Desc10 = "desc10";
            public const string Aplica10 = "aplica10";
        }
        #endregion
    }
}
