using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Windows.DataMappings
{
    public partial class DespesasMap
        : IEntityTypeConfiguration<global::Core.Entities.Legacy.Despesas>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<global::Core.Entities.Legacy.Despesas> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("despesas", "public");

            // key
            builder.HasNoKey();

            // properties
            builder.Property(t => t.Data)
                .HasColumnName("data")
                .HasColumnType("date");

            builder.Property(t => t.Historico)
                .HasColumnName("historico")
                .HasColumnType("character varying(20)")
                .HasMaxLength(20);

            builder.Property(t => t.Valor)
                .HasColumnName("valor")
                .HasColumnType("numeric(12,2)");

            builder.Property(t => t.Caixa)
                .HasColumnName("caixa")
                .HasColumnType("character varying(2)")
                .HasMaxLength(2);

            // relationships
            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "public";
            public const string Name = "despesas";
        }

        public struct Columns
        {
            public const string Data = "data";
            public const string Historico = "historico";
            public const string Valor = "valor";
            public const string Caixa = "caixa";
        }
        #endregion
    }
}
