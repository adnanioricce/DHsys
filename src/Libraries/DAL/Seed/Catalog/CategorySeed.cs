using Core.Entities.Catalog;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Seed.Catalog
{
    public class CategorySeed : IDataObjectSeed<Category>
    {
        public Category GetSeedObject()
        {
            var category = new Category {
                Name = "Sample Category",
                Description = "Sample Category Description",
                ShowOnHomepage = true
            };
            var subCategory = new Category
            {
                Name = "Sample Sub Category",
                Description = "Sample Sub Category Description",
                ShowOnHomepage = false
            };
            category.AddSubCategory(subCategory);
            return category;
        }
    }
}
