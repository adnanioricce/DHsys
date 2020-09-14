using Core.Entities.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.DataMappings.Catalog
{
    public class ProductConfiguration : BaseEntityConfiguration<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> mapper)
        {
            mapper.ToTable("Products");
            mapper.HasMany(r => r.ProductSuppliers)
            .WithOne(ps => ps.Product)
            .OnDelete(DeleteBehavior.Restrict);
            base.Configure(mapper);
        }
    }
}
