using Core.Entities.Catalog;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DataMappings.Catalog
{
    public class ProductTaxConfiguration : BaseEntityConfiguration<ProductTax>
    {
        public override void Configure(EntityTypeBuilder<ProductTax> builder)
        {
            base.Configure(builder);
        }
    }
}
