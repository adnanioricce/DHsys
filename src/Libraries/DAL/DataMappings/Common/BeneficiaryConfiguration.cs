using Core.Entities.Financial;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.DataMappings.Common
{
    public class BeneficiaryConfiguration : BaseEntityConfiguration<Beneficiary>
    {
        public override void Configure(EntityTypeBuilder<Beneficiary> builder)
        {
            base.Configure(builder);
        }
    }
}
