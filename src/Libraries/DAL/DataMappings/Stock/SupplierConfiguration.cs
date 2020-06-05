using Core.Entities.Stock;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.DataMappings.Stock
{
    public class SupplierConfiguration : BaseEntityConfiguration<Supplier>
    {
        public override void Configure(EntityTypeBuilder<Supplier> builder)
        {
            base.Configure(builder);
        }
    }
}
