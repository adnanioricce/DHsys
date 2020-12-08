using Core.Entities.Stock;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.DataMappings.Stock
{
    public class SupplierConfiguration : BaseEntityConfiguration<Supplier>
    {
        public override void Configure(EntityTypeBuilder<Supplier> builder)
        {
            //builder.HasMany(p => p.Products)
            //       .WithOne(p => p.Supplier)
            //       .OnDelete(DeleteBehavior.Cascade);
            //builder.HasMany(p => p.Stockentries)
            //       .WithOne(p => p.Supplier)
            //       .OnDelete(DeleteBehavior.Cascade);
            base.Configure(builder);
        }
    }
}