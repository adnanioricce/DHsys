using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Mappings.Legacy
{
    public partial class NfeMap
        : IEntityTypeConfiguration<global::Core.Entities.Legacy.Nfe>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<global::Core.Entities.Legacy.Nfe> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("nfe", "public");

            // key
            builder.HasNoKey();

            // properties
            builder.Property(t => t.Campo)
                .HasColumnName("campo")
                .HasColumnType("character varying(150)")
                .HasMaxLength(150);

            builder.Property(t => t.Codigo)
                .HasColumnName("codigo")
                .HasColumnType("character varying(6)")
                .HasMaxLength(6);

            builder.Property(t => t.Descricao)
                .HasColumnName("descricao")
                .HasColumnType("character varying(35)")
                .HasMaxLength(35);

            builder.Property(t => t.Qtde)
                .HasColumnName("qtde")
                .HasColumnType("character varying(4)")
                .HasMaxLength(4);

            builder.Property(t => t.Valor)
                .HasColumnName("valor")
                .HasColumnType("character varying(8)")
                .HasMaxLength(8);

            builder.Property(t => t.Vltot)
                .HasColumnName("vltot")
                .HasColumnType("character varying(8)")
                .HasMaxLength(8);

            builder.Property(t => t.Ncm)
                .HasColumnName("ncm")
                .HasColumnType("character varying(8)")
                .HasMaxLength(8);

            builder.Property(t => t.Imp)
                .HasColumnName("imp")
                .HasColumnType("character varying(8)")
                .HasMaxLength(8);

            builder.Property(t => t.Icms)
                .HasColumnName("icms")
                .HasColumnType("character varying(5)")
                .HasMaxLength(5);

            builder.Property(t => t.Prcdimp)
                .HasColumnName("prcdimp")
                .HasColumnType("character varying(2)")
                .HasMaxLength(2);

            // relationships
            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "public";
            public const string Name = "nfe";
        }

        public struct Columns
        {
            public const string Campo = "campo";
            public const string Codigo = "codigo";
            public const string Descricao = "descricao";
            public const string Qtde = "qtde";
            public const string Valor = "valor";
            public const string Vltot = "vltot";
            public const string Ncm = "ncm";
            public const string Imp = "imp";
            public const string Icms = "icms";
            public const string Prcdimp = "prcdimp";
        }
        #endregion
    }
}
