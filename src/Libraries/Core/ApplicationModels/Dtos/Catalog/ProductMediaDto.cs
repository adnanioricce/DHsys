using System;
using Core.ApplicationModels.Dtos.Media;
using Core.Entities.Catalog;

namespace Core.ApplicationModels.Dtos.Catalog
{
    public class ProductMediaDto
    {
        public int MediaResourceId { get; set; }

        public MediaResourceDto Media { get; set; }

        public int ProductId { get; set; }

        public ProductDto Product { get; set; }

        public bool IsThumbnail { get; set; }
    }
}