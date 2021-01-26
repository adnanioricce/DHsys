using Core.Entities.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.DataMappings.Catalog
{
    public class ProductConfiguration : BaseEntityConfiguration<Product>
    {        
        public override void Configure(EntityTypeBuilder<Product> mapper)
        {            
            mapper.HasMany(p => p.ProductPrices)
                  .WithOne(p => p.Product)
                  .HasForeignKey(p => p.ProductId)
                  .OnDelete(DeleteBehavior.Cascade);
            mapper.HasMany(r => r.ProductSuppliers)
                  .WithOne(ps => ps.Product)
                  .OnDelete(DeleteBehavior.Cascade);
            mapper.HasMany(p => p.ProductMedias)
                  .WithOne(p => p.Product)
                  .HasForeignKey(p => p.ProductId)
                  .OnDelete(DeleteBehavior.Cascade);
            mapper.HasMany(p => p.Stockentries)
                  .WithOne(p => p.Product)
                  .HasForeignKey(p => p.ProductId)
                  .OnDelete(DeleteBehavior.Cascade);
            mapper.HasMany(p => p.Categories)
                  .WithOne(p => p.Product)
                  .HasForeignKey(p => p.ProductId)
                  .OnDelete(DeleteBehavior.Cascade);
            mapper.HasMany(p => p.ShelfLifes)
                  .WithOne(p => p.Product)
                  .HasForeignKey(p => p.ProductId)
                  .OnDelete(DeleteBehavior.Cascade);
            mapper.HasMany(p => p.StockChanges)
                  .WithOne(p => p.Product)
                  .HasForeignKey(p => p.ProductId)
                  .OnDelete(DeleteBehavior.Cascade);                        
            mapper.HasMany(p => p.ProductTaxes)
                  .WithOne(p => p.Product)
                  .HasForeignKey(p => p.ProductId)
                  .OnDelete(DeleteBehavior.Cascade);
            mapper.Property(p => p.Stripe)
                  .HasConversion(c => c.ToString(), v => StripeFactory.FromString(v));
            mapper.Property(p => p.RiskClass)
                  .HasConversion(c => c.ToString(), v => v == "I" 
                                                        ? RiskClass.I : v == "II" 
                                                        ? RiskClass.II : v == "III" 
                                                        ? RiskClass.III : v == "IV" 
                                                        ? RiskClass.IV 
                                                        : RiskClass.Undefined);
            base.Configure(mapper);
        }
    }
}
