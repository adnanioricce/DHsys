using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Entities.Catalog
{
    public class Category : BaseEntity
    {
        public Category(){}
        
        /// <summary>
        /// Get or set the name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Get or set the description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Get or set if this <see cref="Category"/> should be shown on homepage
        /// </summary>
        public bool ShowOnHomepage { get; set; } = false;
        /// <summary>
        /// Get of Set the id of the first category hierarchically above this category
        /// </summary>
        public int? ParentId { get; protected set; }
        /// <summary>
        /// Get or set the reference of the parent category
        /// </summary>
        public virtual Category Parent { get; protected set; }
        /// <summary>
        /// Get or set the list of categories that this category is parent
        /// </summary>
        public virtual ICollection<Category> SubCategories { get; protected set; } = new List<Category>();
        /// <summary>
        /// Sets the parent of this category
        /// </summary>        
        public void SetParent(Category parentCategory)
        {                        
            if (SubCategories.Any(c => c.Id == parentCategory.Id))
            {
                throw new DomainException("It's not possible to set a parent category for a category that is alreadly sub category of this category");
            }
            if (parentCategory?.Id == 0)
            {
                this.Parent = parentCategory;
                return;
            }
            this.ParentId = parentCategory.Id;
        }
        /// <summary>
        /// Sets this category as parent of the given category and add to the list of sub categories
        /// </summary>
        /// <param name="category">the category to be added as sub category</param>
        public void AddSubCategory(Category category)
        {
            category.SetParent(this);
            this.SubCategories.Add(category);
        }

    }
}
