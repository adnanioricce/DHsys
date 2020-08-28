using Core.Entities.Financial;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.DataMappings.Financial
{
    public class BillingConfiguration : BaseEntityConfiguration<Billing>
    {
        public override void Configure(EntityTypeBuilder<Billing> mapper)
        {
            base.Configure(mapper);
            mapper.ToTable("Billings");                        
        }
    }
}
