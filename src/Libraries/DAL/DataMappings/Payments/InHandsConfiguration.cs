using Core.Entities.Payments;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataMappings.Payments
{
    public class InHandsConfiguration : BaseEntityConfiguration<InHands>
    {
        public override void Configure(EntityTypeBuilder<InHands> builder)
        {            
            base.Configure(builder);
            builder.Property(p => p.Name)
                   .IsRequired();
        }
    }
}
