using Core.Entities.Catalog;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.DataMappings.Catalog
{
    public class ProductTemplateConfiguration : BaseEntityConfiguration<ProductTemplate>
    {
        public override void Configure(EntityTypeBuilder<ProductTemplate> builder)
        {
            builder.HasMany(p => p.Categories)
                   .WithOne()                   
                   .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);
            builder.HasMany(p => p.Taxes)
                   .WithOne()
                   .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);
            base.Configure(builder);
        }
    }
}
