using System;
using System.Linq;
using Core.Models.Dtos.Catalog;
using Core.Entities.Stock;

namespace Core.Models.Dtos.Stock
{
    public class StockChangeDto : BaseEntityDto
    {
        public StockChangeType Type { get; set; }

        public int Quantity { get; set; }

        public int ProductId { get; set; }

        public ProductDto Product { get; set; }

        public int ImpactingEntityId { get; set; }

        public string Note { get; set; }
    }
}