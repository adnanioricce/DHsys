using System;
using System.Collections.Generic;
using System.Linq;
using Core.Models.Dtos.Payments;
using Core.Entities.Financial;
using Core.Entities.Orders;

namespace Core.Models.Dtos.Orders
{
    public class POSOrderDto : BaseEntityDto
    {
        public decimal OrderTotal { get; private set; }

        public decimal DiscountTotal { get; set; }

        public decimal RemainingValueToPay { get; set; }

        public decimal Change { get; set; }

        public PaymentMethodDto PaymentMethod { get; set; }

        public List<PaymentDto> Payments { get; set; }

        public bool HasDealWithStore { get; set; }

        public string ConsumerCode { get; set; }

        public OrderState State { get; set; }

        public bool HasEnded { get; set; }

        public bool PaidOut { get; set; }

        public IList<POSOrderItemDto> Items { get; set; }
    }
}