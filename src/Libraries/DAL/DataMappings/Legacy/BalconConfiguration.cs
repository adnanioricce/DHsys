using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Mappings.Legacy
{
    public partial class BalconMap
        : IEntityTypeConfiguration<global::Core.Entities.Legacy.Balcon>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<global::Core.Entities.Legacy.Balcon> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("balcon", "public");

            // key
            builder.HasNoKey();

            // properties
            builder.Property(t => t.Bacodi)
                .HasColumnName("bacodi")
                .HasColumnType("character varying(3)")
                .HasMaxLength(3);

            builder.Property(t => t.Banome)
                .HasColumnName("banome")
                .HasColumnType("character varying(20)")
                .HasMaxLength(20);

            builder.Property(t => t.Bacomi)
                .HasColumnName("bacomi")
                .HasColumnType("numeric(10,2)");

            builder.Property(t => t.Badevol)
                .HasColumnName("badevol")
                .HasColumnType("numeric(10,2)");

            builder.Property(t => t.Cpf)
                .HasColumnName("cpf")
                .HasColumnType("character varying(11)")
                .HasMaxLength(11);

            builder.Property(t => t.Senha)
                .HasColumnName("senha")
                .HasColumnType("character varying(8)")
                .HasMaxLength(8);

            builder.Property(t => t.ComisBo)
                .HasColumnName("comis_bo")
                .HasColumnType("numeric(5,2)");

            builder.Property(t => t.ComisPer)
                .HasColumnName("comis_per")
                .HasColumnType("numeric(5,2)");

            builder.Property(t => t.ComisAce)
                .HasColumnName("comis_ace")
                .HasColumnType("numeric(5,2)");

            builder.Property(t => t.ComisVar)
                .HasColumnName("comis_var")
                .HasColumnType("numeric(5,2)");

            builder.Property(t => t.ComisEti)
                .HasColumnName("comis_eti")
                .HasColumnType("numeric(5,2)");

            builder.Property(t => t.ComisPerc)
                .HasColumnName("comis_perc")
                .HasColumnType("numeric(5,2)");

            builder.Property(t => t.ComisOut)
                .HasColumnName("comis_out")
                .HasColumnType("numeric(5,2)");

            // relationships
            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "public";
            public const string Name = "balcon";
        }

        public struct Columns
        {
            public const string Bacodi = "bacodi";
            public const string Banome = "banome";
            public const string Bacomi = "bacomi";
            public const string Badevol = "badevol";
            public const string Cpf = "cpf";
            public const string Senha = "senha";
            public const string ComisBo = "comis_bo";
            public const string ComisPer = "comis_per";
            public const string ComisAce = "comis_ace";
            public const string ComisVar = "comis_var";
            public const string ComisEti = "comis_eti";
            public const string ComisPerc = "comis_perc";
            public const string ComisOut = "comis_out";
        }
        #endregion
    }
}
