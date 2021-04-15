using Core.Entities.Financial;
using Core.Entities.POS;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.DataMappings.POS
{
    public class POSOrderConfiguration : BaseEntityConfiguration<POSOrder>
    {
        public override void Configure(EntityTypeBuilder<POSOrder> builder)
        {            
            base.Configure(builder);
            builder.HasMany(t => t.Items)
                   .WithOne()   
                   .HasForeignKey(t => t.POSOrderId)                
                   .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade)
                   .IsRequired();
            builder.Ignore(p => p.PaymentMethod);
        }
    }
}