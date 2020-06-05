using Core.Entities.Sync;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.DataMappings.Sync
{
    public class SyncronizationConfiguration : BaseEntityConfiguration<Syncronization>
    {
        public override void Configure(EntityTypeBuilder<Syncronization> builder)
        {
            base.Configure(builder);
        }
    }
}
