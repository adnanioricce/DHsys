using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Catalog
{
    public class ProductCategory : BaseEntity
    {
        public ProductCategory(){}
        public ProductCategory(Product product,Category category)
        {
            Category = category;
            Product = product;
        }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
