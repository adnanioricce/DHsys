using System;
using System.Collections.Generic;
using System.Linq;
using Core.Entities.Financial;

namespace Core.ApplicationModels.Dtos.Financial
{
    public class TransactionDto
    {
        public int Id { get; set; }
        public decimal TransactionTotal { get; set; }

        public PaymentMethods PaymentMethod { get; set; }

        public bool HasDealWithStore { get; set; }

        public IList<TransactionItemDto> Items { get; set; }

    }
}