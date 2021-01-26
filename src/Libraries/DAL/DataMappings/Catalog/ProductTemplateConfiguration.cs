using Core.Entities.Catalog;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.DataMappings.Catalog
{
    public class ProductTemplateConfiguration : BaseEntityConfiguration<ProductTemplate>
    {
        public override void Configure(EntityTypeBuilder<ProductTemplate> builder)
        {            
            base.Configure(builder);
        }
    }
}
