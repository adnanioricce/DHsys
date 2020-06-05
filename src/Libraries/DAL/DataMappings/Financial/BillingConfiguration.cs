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
            mapper.ToTable("Billings");
            mapper.HasKey(prop => prop.Id);
            mapper.HasData(new[] {
                new Billing
                {
                    Id = 1,
                    EndDate = DateTime.UtcNow,
                    BeneficiaryName = "empresa",
                    Price = 12.99m
                },
                new Billing
                {
                    Id = 2,
                    EndDate = DateTime.UtcNow,
                    BeneficiaryName = "empresa 2",
                    Price = 22.99m
                }
            });
        }
    }
}
