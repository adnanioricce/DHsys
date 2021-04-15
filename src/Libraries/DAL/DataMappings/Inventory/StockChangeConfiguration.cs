using Core.Entities.Inventory;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.DataMappings.Inventory
{
    public class StockChangeConfiguration : BaseEntityConfiguration<StockChange>
    {
        public override void Configure(EntityTypeBuilder<StockChange> builder)
        {
            base.Configure(builder);
        }
    }
}
