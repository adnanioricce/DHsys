using System;
using System.Linq;
using Core.ApplicationModels.Dtos.Catalog;
using Core.Entities.Financial;

namespace Core.ApplicationModels.Dtos.Financial
{
    public class POSOrderItemDto
    {
        public int Id { get; set; }
        public string DrugUniqueCode { get; set; }
        public DrugDto Drug { get; set; }

        public int Quantity { get; set; }

        public decimal CustomerValue { get; set; }

        public decimal CostPrice { get; set; }
       
    }
}