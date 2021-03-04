using Core.Entities.Payments;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataMappings.Payments
{
    public class PaymentConfiguration : BaseEntityConfiguration<Payment>
    {
        public override void Configure(EntityTypeBuilder<Payment> builder)
        {
            base.Configure(builder);
            builder.Property(p => p.NeededValue)                    
                   .IsRequired();
            builder.Property(p => p.ReceivedValue)
                   .IsRequired();
            builder.HasOne(p => p.Method)
                   .WithMany()
                   .IsRequired()
                   .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);            
        }
    }
}
