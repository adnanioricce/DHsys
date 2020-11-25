using Core.Entities.Stock;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace DAL.DataMappings.Stock
{
    public class StockEntryConfiguration : BaseEntityConfiguration<StockEntry>
    {
        public override void Configure(EntityTypeBuilder<StockEntry> builder)
        {
            base.Configure(builder);
            builder.HasMany(p => p.Items)
                   .WithOne(p => p.StockEntry)
                   .HasForeignKey(p => p.StockEntryId)
                   .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(p => p.Supplier)
                   .WithMany()                   
                   .OnDelete(DeleteBehavior.Restrict);                    
        }
    }
}
