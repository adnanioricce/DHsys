using Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DataMappings.Stock
{
    public class ClientConfiguration : BaseEntityConfiguration<Client>
    {
        public override void Configure(EntityTypeBuilder<Client> builder)
        {
            base.Configure(builder);
            builder.Property(p => p.Cpf)
                .HasMaxLength(12);            
            
        }
    }
}
