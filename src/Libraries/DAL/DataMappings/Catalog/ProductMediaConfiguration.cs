using Core.Entities.Catalog;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.DataMappings.Catalog
{
    public class ProductMediaConfiguration : BaseEntityConfiguration<ProductMedia>
    {
        public override void Configure(EntityTypeBuilder<ProductMedia> builder)
        {
            base.Configure(builder);                                  
        }
    }
}
