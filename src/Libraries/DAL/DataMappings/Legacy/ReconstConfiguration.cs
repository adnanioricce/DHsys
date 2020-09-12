using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Mappings.Legacy
{
    public partial class ReconstMap
        : IEntityTypeConfiguration<global::Core.Entities.Legacy.Reconst>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<global::Core.Entities.Legacy.Reconst> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("reconst", "public");

            // key
            builder.HasNoKey();

            // properties
            builder.Property(t => t.Arquivo)
                .HasColumnName("arquivo")
                .HasColumnType("character varying(15)")
                .HasMaxLength(15);

            builder.Property(t => t.Posicao)
                .HasColumnName("posicao")
                .HasColumnType("character varying(2)")
                .HasMaxLength(2);

            builder.Property(t => t.Data)
                .HasColumnName("data")
                .HasColumnType("date");

            builder.Property(t => t.Necessita)
                .HasColumnName("necessita")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            // relationships
            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "public";
            public const string Name = "reconst";
        }

        public struct Columns
        {
            public const string Arquivo = "arquivo";
            public const string Posicao = "posicao";
            public const string Data = "data";
            public const string Necessita = "necessita";
        }
        #endregion
    }
}
