using Core.Entities.Financial;
using System;
using System.Collections.Generic;

namespace Desktop.Models.Financial
{
    public class TransactionModel
    {
        public decimal TransactionTotal { get; set; }
        public virtual PaymentMethods PaymentMethod { get; set; }
        public bool HasDealWithStore { get; set; }
        public virtual IList<TransactionItem> Items { get; set; } = new List<TransactionItem>();
        public DateTimeOffset CreatedAt { get; set; }
    }
}
