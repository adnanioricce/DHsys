using Core.Entities.POS;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataMappings.POS
{
    public class CashDrawerConfiguration : BaseEntityConfiguration<CashDrawer>
    {
        public override void Configure(EntityTypeBuilder<CashDrawer> builder)
        {
            builder.HasMany(t => t.Transactions)
                   .WithOne(t => t.CashDrawer)                   
                   .IsRequired();
            base.Configure(builder);
        }
    }
}
