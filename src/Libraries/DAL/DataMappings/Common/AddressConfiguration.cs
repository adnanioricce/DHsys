using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace DAL.DataMappings.Common
{
    public class AddressConfiguration : BaseEntityConfiguration<Address>
    {
        public override void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("addresses");
            base.Configure(builder);
        }
    }
}
