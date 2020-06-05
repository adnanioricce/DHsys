using Core.Entities.Stock;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DataMappings.Stock
{
    public class StockEntryConfiguration : BaseEntityConfiguration<StockEntry>
    {
        public override void Configure(EntityTypeBuilder<StockEntry> builder)
        {
            base.Configure(builder);
        }
    }
}
