using System;
using System.Linq;
using Core.Entities.Catalog;

namespace Core.ApplicationModels.Dtos.Catalog
{
    public class CategoryDto : BaseEntityDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public bool ShowOnHomepage { get; set; }
    }
}