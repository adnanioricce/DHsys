using Core.Entities.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.DataMappings.Catalog
{
    public class ProductMediaConfiguration : BaseEntityConfiguration<ProductMedia>
    {
        public override void Configure(EntityTypeBuilder<ProductMedia> builder)
        {
            base.Configure(builder);
            builder.HasOne(p => p.Media)
                   .WithMany()
                   .HasForeignKey(p => p.MediaResourceId)
                   .OnDelete(DeleteBehavior.Restrict)
                   .IsRequired();

            builder.HasOne(p => p.Product)
                   .WithMany(p => p.ProductMedias)
                   .HasForeignKey(p => p.ProductId)
                   .OnDelete(DeleteBehavior.Cascade)
                   .IsRequired();
            
        }
    }
}
