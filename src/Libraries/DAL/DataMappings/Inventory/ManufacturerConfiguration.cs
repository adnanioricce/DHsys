using Core.Entities.Inventory;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.DataMappings.Inventory
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
