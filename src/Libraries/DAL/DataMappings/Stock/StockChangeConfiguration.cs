using Core.Entities.Stock;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.DataMappings.Stock
{
    public class StockChangeConfiguration : BaseEntityConfiguration<StockChange>
    {
        public override void Configure(EntityTypeBuilder<StockChange> builder)
        {
            base.Configure(builder);
        }
    }
}
