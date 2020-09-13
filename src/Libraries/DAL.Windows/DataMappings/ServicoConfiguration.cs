using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Windows.DataMappings
{
    public partial class ServicoMap
        : IEntityTypeConfiguration<global::Core.Entities.Legacy.Servico>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<global::Core.Entities.Legacy.Servico> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("servico", "public");

            // key
            builder.HasNoKey();

            // properties
            builder.Property(t => t.Svcodi)
                .HasColumnName("svcodi")
                .HasColumnType("character varying(6)")
                .HasMaxLength(6);

            builder.Property(t => t.Svdesc)
                .HasColumnName("svdesc")
                .HasColumnType("character varying(30)")
                .HasMaxLength(30);

            builder.Property(t => t.Svprec)
                .HasColumnName("svprec")
                .HasColumnType("numeric(10,2)");

            builder.Property(t => t.Svven1)
                .HasColumnName("svven1")
                .HasColumnType("numeric(5,0)");

            builder.Property(t => t.Svven2)
                .HasColumnName("svven2")
                .HasColumnType("numeric(5,0)");

            builder.Property(t => t.Svcomb)
                .HasColumnName("svcomb")
                .HasColumnType("numeric(2,0)");

            builder.Property(t => t.Svpr01)
                .HasColumnName("svpr01")
                .HasColumnType("character varying(6)")
                .HasMaxLength(6);

            builder.Property(t => t.Svpr02)
                .HasColumnName("svpr02")
                .HasColumnType("character varying(6)")
                .HasMaxLength(6);

            builder.Property(t => t.Svpr03)
                .HasColumnName("svpr03")
                .HasColumnType("character varying(6)")
                .HasMaxLength(6);

            builder.Property(t => t.Svpr04)
                .HasColumnName("svpr04")
                .HasColumnType("character varying(6)")
                .HasMaxLength(6);

            builder.Property(t => t.Svpr05)
                .HasColumnName("svpr05")
                .HasColumnType("character varying(6)")
                .HasMaxLength(6);

            // relationships
            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "public";
            public const string Name = "servico";
        }

        public struct Columns
        {
            public const string Svcodi = "svcodi";
            public const string Svdesc = "svdesc";
            public const string Svprec = "svprec";
            public const string Svven1 = "svven1";
            public const string Svven2 = "svven2";
            public const string Svcomb = "svcomb";
            public const string Svpr01 = "svpr01";
            public const string Svpr02 = "svpr02";
            public const string Svpr03 = "svpr03";
            public const string Svpr04 = "svpr04";
            public const string Svpr05 = "svpr05";
        }
        #endregion
    }
}
