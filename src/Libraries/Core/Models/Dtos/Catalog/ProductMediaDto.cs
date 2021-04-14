using System;
using Core.Models.Dtos.Media;
using Core.Entities.Catalog;

namespace Core.Models.Dtos.Catalog
{
    public class ProductMediaDto : BaseEntityDto
    {
        public int MediaResourceId { get; set; }

        public MediaResourceDto Media { get; set; }

        public int ProductId { get; set; }

        public ProductDto Product { get; set; }

        public bool IsThumbnail { get; set; }
    }
}