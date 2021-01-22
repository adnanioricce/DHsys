using Core.Entities.Financial;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DataMappings.Common
{
    public class TaxConfiguration : BaseEntityConfiguration<Tax>
    {
        public override void Configure(EntityTypeBuilder<Tax> builder)
        {
            builder.ToTable("Taxes");
            base.Configure(builder);
        }
    }
}
