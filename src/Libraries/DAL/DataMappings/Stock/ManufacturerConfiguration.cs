using Core.Entities.Stock;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.DataMappings.Stock
{
    public class ManufacturerConfiguration : BaseEntityConfiguration<Manufacturer>
    {
        public override void Configure(EntityTypeBuilder<Manufacturer> builder)
        {
            base.Configure(builder);
            builder.Property(p => p.Cnpj);
        }
    }
}
