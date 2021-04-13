using Core.Entities.User;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataMappings.User
{
    public class CustomerConfiguration : BaseEntityConfiguration<Customer>
    {
        public override void Configure(EntityTypeBuilder<Customer> builder)
        {
            base.Configure(builder);
            builder.HasMany(p => p.Addresses)
                   .WithOne(e => e.Customer)
                   .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);
            
        }
    }
}
