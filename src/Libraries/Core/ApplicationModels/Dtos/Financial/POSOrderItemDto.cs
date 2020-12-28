using System;
using System.Linq;
using Core.ApplicationModels.Dtos.Catalog;
using Core.Entities.Financial;

namespace Core.ApplicationModels.Dtos.Financial
{
    public class POSOrderItemDto : BaseEntityDto
    {
        public string ProductUniqueCode { get; set; }

        public ProductDto Product { get; set; }

        public int Quantity { get; set; }

        public decimal CustomerValue { get; set; }

        public decimal CostPrice { get; set; }

        public int POSOrderId { get; set; }

        public POSOrderDto POSOrder { get; set; }        
    }
}