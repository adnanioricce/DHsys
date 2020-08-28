using Core.Entities.Catalog;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.DataMappings.Catalog
{
    public class ProductStockEntryConfiguration : BaseEntityConfiguration<ProductStockEntry>
    {
        public override void Configure(EntityTypeBuilder<ProductStockEntry> builder)
        {
            base.Configure(builder);
        }
    }
}
