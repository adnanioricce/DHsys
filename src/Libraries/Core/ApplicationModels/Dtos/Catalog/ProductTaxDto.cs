using System;
using Core.Entities.Catalog;
using Core.ApplicationModels.Dtos.Financial;

namespace Core.ApplicationModels.Dtos.Catalog
{
    public class ProductTaxDto : BaseEntityDto
    {
        public int TaxId { get; set; }

        public TaxDto Tax { get; set; }

        public int ProductId { get; set; }

        public ProductDto Product { get; set; }
    }
}