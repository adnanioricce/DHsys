using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Windows.DataMappings
{
    public partial class UsefarmaMap
        : IEntityTypeConfiguration<Legacy.Entities.Usefarma>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Legacy.Entities.Usefarma> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("usefarma", "public");

            // key
            builder.HasNoKey();

            // properties
            builder.Property(t => t.Nome)
                .HasColumnName("nome")
                .HasColumnType("character varying(15)")
                .HasMaxLength(15);

            builder.Property(t => t.Senha)
                .HasColumnName("senha")
                .HasColumnType("character varying(10)")
                .HasMaxLength(10);

            builder.Property(t => t.Nivel)
                .HasColumnName("nivel")
                .HasColumnType("character varying(2)")
                .HasMaxLength(2);

            builder.Property(t => t.Acesso1)
                .HasColumnName("acesso1")
                .HasColumnType("character varying(250)")
                .HasMaxLength(250);

            builder.Property(t => t.Acesso2)
                .HasColumnName("acesso2")
                .HasColumnType("character varying(250)")
                .HasMaxLength(250);

            builder.Property(t => t.Acesso3)
                .HasColumnName("acesso3")
                .HasColumnType("character varying(250)")
                .HasMaxLength(250);

            builder.Property(t => t.Acesso4)
                .HasColumnName("acesso4")
                .HasColumnType("character varying(250)")
                .HasMaxLength(250);

            builder.Property(t => t.Acesso5)
                .HasColumnName("acesso5")
                .HasColumnType("character varying(250)")
                .HasMaxLength(250);

            builder.Property(t => t.Acesso6)
                .HasColumnName("acesso6")
                .HasColumnType("character varying(250)")
                .HasMaxLength(250);

            builder.Property(t => t.Acesso7)
                .HasColumnName("acesso7")
                .HasColumnType("character varying(250)")
                .HasMaxLength(250);

            builder.Property(t => t.Acesso8)
                .HasColumnName("acesso8")
                .HasColumnType("character varying(250)")
                .HasMaxLength(250);

            builder.Property(t => t.Acesso9)
                .HasColumnName("acesso9")
                .HasColumnType("character varying(250)")
                .HasMaxLength(250);

            builder.Property(t => t.Acesso10)
                .HasColumnName("acesso10")
                .HasColumnType("character varying(250)")
                .HasMaxLength(250);

            // relationships
            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "public";
            public const string Name = "usefarma";
        }

        public struct Columns
        {
            public const string Nome = "nome";
            public const string Senha = "senha";
            public const string Nivel = "nivel";
            public const string Acesso1 = "acesso1";
            public const string Acesso2 = "acesso2";
            public const string Acesso3 = "acesso3";
            public const string Acesso4 = "acesso4";
            public const string Acesso5 = "acesso5";
            public const string Acesso6 = "acesso6";
            public const string Acesso7 = "acesso7";
            public const string Acesso8 = "acesso8";
            public const string Acesso9 = "acesso9";
            public const string Acesso10 = "acesso10";
        }
        #endregion
    }
}
