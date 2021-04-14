using System;
using Core.Entities.Catalog;

namespace Core.Models.Dtos.Catalog
{
    public class ProductPriceDto : BaseEntityDto
    {        
        public DateTimeOffset? Pricestartdate { get; set; }
        public decimal EndCustomerDrugPrice { get; set; }
        public decimal CostPrice { get; set; }
        public int ProductId { get; set; }
        public ProductDto Product { get; set; }
    }
}