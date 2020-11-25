using Core.Entities.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DataMappings.Catalog
{
    public class ProductSupplierConfiguration : BaseEntityConfiguration<ProductSupplier>
    {
        public override void Configure(EntityTypeBuilder<ProductSupplier> builder)
        {            
            base.Configure(builder);
            builder.HasOne(p => p.Supplier)
                   .WithMany(p => p.Products)
                   .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p => p.Product)
                   .WithMany(p => p.ProductSuppliers)
                   .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
