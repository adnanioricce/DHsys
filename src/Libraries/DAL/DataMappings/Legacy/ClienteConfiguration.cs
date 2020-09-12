using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Mappings.Legacy
{
    public partial class ClienteMap
        : IEntityTypeConfiguration<global::Core.Entities.Legacy.Cliente>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<global::Core.Entities.Legacy.Cliente> builder)
        {
            #region Generated Configure
            // table
            builder.ToTable("cliente", "public");

            // key
            builder.HasNoKey();

            // properties
            builder.Property(t => t.Clcodi)
                .HasColumnName("clcodi")
                .HasColumnType("character varying(4)")
                .HasMaxLength(4);

            builder.Property(t => t.Clnome)
                .HasColumnName("clnome")
                .HasColumnType("character varying(35)")
                .HasMaxLength(35);

            builder.Property(t => t.Clende)
                .HasColumnName("clende")
                .HasColumnType("character varying(40)")
                .HasMaxLength(40);

            builder.Property(t => t.Clestado)
                .HasColumnName("clestado")
                .HasColumnType("character varying(2)")
                .HasMaxLength(2);

            builder.Property(t => t.Clcep)
                .HasColumnName("clcep")
                .HasColumnType("character varying(9)")
                .HasMaxLength(9);

            builder.Property(t => t.Cltele)
                .HasColumnName("cltele")
                .HasColumnType("character varying(15)")
                .HasMaxLength(15);

            builder.Property(t => t.Cldebi)
                .HasColumnName("cldebi")
                .HasColumnType("numeric(10,2)");

            builder.Property(t => t.Clpagto)
                .HasColumnName("clpagto")
                .HasColumnType("numeric(2,0)");

            builder.Property(t => t.Cllime)
                .HasColumnName("cllime")
                .HasColumnType("numeric(12,2)");

            builder.Property(t => t.Clcompra)
                .HasColumnName("clcompra")
                .HasColumnType("date");

            builder.Property(t => t.Clupagto)
                .HasColumnName("clupagto")
                .HasColumnType("date");

            builder.Property(t => t.Clcida)
                .HasColumnName("clcida")
                .HasColumnType("character varying(15)")
                .HasMaxLength(15);

            builder.Property(t => t.Cldesc)
                .HasColumnName("cldesc")
                .HasColumnType("character varying(1)")
                .HasMaxLength(1);

            builder.Property(t => t.Cldesmed)
                .HasColumnName("cldesmed")
                .HasColumnType("numeric(5,2)");

            builder.Property(t => t.Cldesper)
                .HasColumnName("cldesper")
                .HasColumnType("numeric(5,2)");

            builder.Property(t => t.Clbairro)
                .HasColumnName("clbairro")
                .HasColumnType("character varying(15)")
                .HasMaxLength(15);

            builder.Property(t => t.Clnasc)
                .HasColumnName("clnasc")
                .HasColumnType("date");

            builder.Property(t => t.Clrg)
                .HasColumnName("clrg")
                .HasColumnType("character varying(19)")
                .HasMaxLength(19);

            builder.Property(t => t.Clobs)
                .HasColumnName("clobs")
                .HasColumnType("character varying(30)")
                .HasMaxLength(30);

            builder.Property(t => t.Clcpf)
                .HasColumnName("clcpf")
                .HasColumnType("character varying(15)")
                .HasMaxLength(15);

            builder.Property(t => t.Clcred)
                .HasColumnName("clcred")
                .HasColumnType("numeric(10,2)");

            // relationships
            #endregion
        }

        #region Generated Constants
        public struct Table
        {
            public const string Schema = "public";
            public const string Name = "cliente";
        }

        public struct Columns
        {
            public const string Clcodi = "clcodi";
            public const string Clnome = "clnome";
            public const string Clende = "clende";
            public const string Clestado = "clestado";
            public const string Clcep = "clcep";
            public const string Cltele = "cltele";
            public const string Cldebi = "cldebi";
            public const string Clpagto = "clpagto";
            public const string Cllime = "cllime";
            public const string Clcompra = "clcompra";
            public const string Clupagto = "clupagto";
            public const string Clcida = "clcida";
            public const string Cldesc = "cldesc";
            public const string Cldesmed = "cldesmed";
            public const string Cldesper = "cldesper";
            public const string Clbairro = "clbairro";
            public const string Clnasc = "clnasc";
            public const string Clrg = "clrg";
            public const string Clobs = "clobs";
            public const string Clcpf = "clcpf";
            public const string Clcred = "clcred";
        }
        #endregion
    }
}
