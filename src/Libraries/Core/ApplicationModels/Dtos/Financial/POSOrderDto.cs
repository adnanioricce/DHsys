using System;
using System.Collections.Generic;
using System.Linq;
using Core.Entities.Financial;

namespace Core.ApplicationModels.Dtos.Financial
{
    public class POSOrderDto
    {
        public int Id { get; set; }
        public decimal OrderTotal { get; set; }

        public PaymentMethods PaymentMethod { get; set; }

        public bool HasDealWithStore { get; set; }

        public IList<POSOrderItemDto> Items { get; set; }

    }
}