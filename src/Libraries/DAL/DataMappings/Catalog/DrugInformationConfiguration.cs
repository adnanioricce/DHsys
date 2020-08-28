using Core.Entities.Catalog;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.DataMappings.Catalog
{
    public class DrugInformationConfiguration : BaseEntityConfiguration<DrugInformation>
    {
        public override void Configure(EntityTypeBuilder<DrugInformation> builder)
        {
            base.Configure(builder);
        }
    }
}
