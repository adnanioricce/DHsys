using Core.Entities.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.DataMappings.Catalog
{
    public class DrugConfiguration : BaseEntityConfiguration<Drug>
    {
        public override void Configure(EntityTypeBuilder<Drug> builder)
        {            
            base.Configure(builder);            
        }
    }
}
