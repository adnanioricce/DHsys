using System;
using Core.Entities.Catalog;
using Core.Models.Dtos.Financial;

namespace Core.Models.Dtos.Catalog
{
    public class ProductTaxDto : BaseEntityDto
    {
        public int TaxId { get; set; }

        public TaxDto Tax { get; set; }

        public int ProductId { get; set; }

        public ProductDto Product { get; set; }
    }
}