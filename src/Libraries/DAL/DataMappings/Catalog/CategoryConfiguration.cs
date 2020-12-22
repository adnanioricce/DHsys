using Core.Entities.Catalog;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DataMappings.Catalog
{
    public class CategoryConfiguration : BaseEntityConfiguration<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {            
            base.Configure(builder);
            builder.HasMany(c => c.SubCategories)
                   .WithOne(p => p.Parent)
                   .HasForeignKey(p => p.ParentId);                   
        }
    }
}
