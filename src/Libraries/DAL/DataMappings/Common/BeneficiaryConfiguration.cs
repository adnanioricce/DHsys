using Core.Entities.Financial;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.DataMappings.Common
{
    public class BeneficiaryConfiguration : BaseEntityConfiguration<Beneficiary>
    {
        public override void Configure(EntityTypeBuilder<Beneficiary> builder)
        {
            base.Configure(builder);
            builder.ToTable("beneficiaries");
            builder.Property(p => p.Name);
            
        }
    }
}
