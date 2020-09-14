using Core.Entities.Financial;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.DataMappings.Orders
{
    public class TransactionMap : BaseEntityConfiguration<Transaction>
    {
        public override void Configure(EntityTypeBuilder<Transaction> builder)
        {            
            base.Configure(builder);
            builder.HasMany(t => t.Items)
                   .WithOne()   
                   .HasForeignKey(t => t.TransactionId)                
                   .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade)
                   .IsRequired();            
        }
    }
}