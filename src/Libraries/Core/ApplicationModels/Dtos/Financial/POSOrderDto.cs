using System;
using System.Collections.Generic;
using System.Linq;
using Core.Entities.Financial;

namespace Core.ApplicationModels.Dtos.Financial
{
    public class POSOrderDto : BaseEntityDto
    {
        public decimal OrderTotal { get; private set; }

        public decimal DiscountTotal { get; set; }

        public PaymentMethods PaymentMethod { get; set; }

        public bool HasDealWithStore { get; set; }

        public string ConsumerCode { get; set; }

        public IList<POSOrderItemDto> Items { get; set; }

        
    }
}