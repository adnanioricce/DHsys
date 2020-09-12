using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Mappings.Legacy
{
    public partial class CliMedMap
        : IEntityTypeConfiguration<global::Core.Entities.Legacy.CliMed>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<global::Core.Entities.Legacy.CliMed> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("cli_med", "public");

            // key
            builder.HasNoKey();

            // properties
            builder.Property(t => t.CpfCrm)
                .HasColumnName("cpf_crm")
                .HasColumnType("character varying(14)")
                .HasMaxLength(14);

            builder.Property(t => t.Nome)
                .HasColumnName("nome")
                .HasColumnType("character varying(50)")
                .HasMaxLength(50);

            builder.Property(t => t.Endereco)
                .HasColumnName("endereco")
                .HasColumnType("character varying(50)")
                .HasMaxLength(50);

            builder.Property(t => t.Sexo)
                .HasColumnName("sexo")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.Fone)
                .HasColumnName("fone")
                .HasColumnType("character varying(25)")
                .HasMaxLength(25);

            // relationships
            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "public";
            public const string Name = "cli_med";
        }

        public struct Columns
        {
            public const string CpfCrm = "cpf_crm";
            public const string Nome = "nome";
            public const string Endereco = "endereco";
            public const string Sexo = "sexo";
            public const string Fone = "fone";
        }
        #endregion
    }
}
