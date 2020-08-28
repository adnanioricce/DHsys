using Core.Entities.Catalog;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DataMappings.Catalog
{
    public class ProductShelLifeConfiguration : BaseEntityConfiguration<ProductShelfLife>
    {
        public override void Configure(EntityTypeBuilder<ProductShelfLife> builder)
        {
            base.Configure(builder);
        }
    }
}
