using System;
using System.Collections.Generic;
using System.Linq;
using Core.Entities.Catalog;

namespace Core.Models.Dtos.Catalog
{
    public class CategoryDto : BaseEntityDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public bool ShowOnHomepage { get; set; }
        public int? ParentId { get; set; }       
        public CategoryDto Parent { get; set; }
        public ICollection<CategoryDto> SubCategories { get; set; } = new List<CategoryDto>();
    }
}