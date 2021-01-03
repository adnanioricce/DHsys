using Core.Entities.Catalog;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DataMappings.Catalog
{
    public class AnvisaFixedProductPriceConfiguration : BaseEntityConfiguration<AnvisaFixedProductPrice>
    {
        public override void Configure(EntityTypeBuilder<AnvisaFixedProductPrice> builder)
        {            
            base.Configure(builder);
        }
    }
}
