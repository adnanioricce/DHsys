using System;
using Core.Entities.Catalog;

namespace Core.ApplicationModels.Dtos.Catalog
{
    public class ProductCategoryDto : BaseEntityDto
    {
        public int CategoryId { get; set; }

        public CategoryDto Category { get; set; }

        public int ProductId { get; set; }

        public ProductDto Product { get; set; }
    }
}