using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Mappings.Legacy
{
    public partial class CadlaboldMap
        : IEntityTypeConfiguration<global::Core.Entities.Legacy.Cadlabold>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<global::Core.Entities.Legacy.Cadlabold> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("cadlabold", "public");

            // key
            builder.HasNoKey();

            // properties
            builder.Property(t => t.Lacodi)
                .HasColumnName("lacodi")
                .HasColumnType("character varying(4)")
                .HasMaxLength(4);

            builder.Property(t => t.Fonome)
                .HasColumnName("fonome")
                .HasColumnType("character varying(30)")
                .HasMaxLength(30);

            builder.Property(t => t.Foapel)
                .HasColumnName("foapel")
                .HasColumnType("character varying(15)")
                .HasMaxLength(15);

            builder.Property(t => t.Focont)
                .HasColumnName("focont")
                .HasColumnType("character varying(15)")
                .HasMaxLength(15);

            builder.Property(t => t.Fotele)
                .HasColumnName("fotele")
                .HasColumnType("character varying(15)")
                .HasMaxLength(15);

            builder.Property(t => t.Fotel2)
                .HasColumnName("fotel2")
                .HasColumnType("character varying(15)")
                .HasMaxLength(15);

            builder.Property(t => t.Fofaxe)
                .HasColumnName("fofaxe")
                .HasColumnType("character varying(15)")
                .HasMaxLength(15);

            builder.Property(t => t.Foende)
                .HasColumnName("foende")
                .HasColumnType("character varying(40)")
                .HasMaxLength(40);

            builder.Property(t => t.Focepe)
                .HasColumnName("focepe")
                .HasColumnType("character varying(9)")
                .HasMaxLength(9);

            builder.Property(t => t.Focida)
                .HasColumnName("focida")
                .HasColumnType("character varying(25)")
                .HasMaxLength(25);

            builder.Property(t => t.Foesta)
                .HasColumnName("foesta")
                .HasColumnType("character varying(2)")
                .HasMaxLength(2);

            builder.Property(t => t.Laiest)
                .HasColumnName("laiest")
                .HasColumnType("character varying(20)")
                .HasMaxLength(20);

            builder.Property(t => t.Lacgce)
                .HasColumnName("lacgce")
                .HasColumnType("character varying(20)")
                .HasMaxLength(20);

            builder.Property(t => t.Labrev)
                .HasColumnName("labrev")
                .HasColumnType("character varying(12)")
                .HasMaxLength(12);

            builder.Property(t => t.Laultc)
                .HasColumnName("laultc")
                .HasColumnType("character varying(6)")
                .HasMaxLength(6);

            builder.Property(t => t.Lacond)
                .HasColumnName("lacond")
                .HasColumnType("character varying(30)")
                .HasMaxLength(30);

            builder.Property(t => t.Laperc)
                .HasColumnName("laperc")
                .HasColumnType("numeric(5,2)");

            builder.Property(t => t.Laulno)
                .HasColumnName("laulno")
                .HasColumnType("character varying(7)")
                .HasMaxLength(7);

            builder.Property(t => t.Latipo)
                .HasColumnName("latipo")
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

            builder.Property(t => t.Nomarq)
                .HasColumnName("nomarq")
                .HasColumnType("character varying(8)")
                .HasMaxLength(8);

            builder.Property(t => t.DtAlter)
                .HasColumnName("dt_alter")
                .HasColumnType("date");

            // relationships
            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "public";
            public const string Name = "cadlabold";
        }

        public struct Columns
        {
            public const string Lacodi = "lacodi";
            public const string Fonome = "fonome";
            public const string Foapel = "foapel";
            public const string Focont = "focont";
            public const string Fotele = "fotele";
            public const string Fotel2 = "fotel2";
            public const string Fofaxe = "fofaxe";
            public const string Foende = "foende";
            public const string Focepe = "focepe";
            public const string Focida = "focida";
            public const string Foesta = "foesta";
            public const string Laiest = "laiest";
            public const string Lacgce = "lacgce";
            public const string Labrev = "labrev";
            public const string Laultc = "laultc";
            public const string Lacond = "lacond";
            public const string Laperc = "laperc";
            public const string Laulno = "laulno";
            public const string Latipo = "latipo";
            public const string Ibgeest = "ibgeest";
            public const string Ibgemun = "ibgemun";
            public const string Nomarq = "nomarq";
            public const string DtAlter = "dt_alter";
        }
        #endregion
    }
}
