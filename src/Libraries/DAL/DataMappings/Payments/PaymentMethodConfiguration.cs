using Core.Entities.Payments;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataMappings.Payments
{
    public class PaymentMethodConfiguration : BaseEntityConfiguration<PaymentMethod>
    {
        public override void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {            
            base.Configure(builder);
        }
    }
}
