using Core.Entities.Catalog;
using System.Collections.Generic;
using System.Linq;

namespace Core.Entities.Financial
{
    public class Transaction : BaseEntity
    {
        public Transaction()
        {
            HasDealWithStore = false;
        }
        public decimal TransactionTotal { get { return CalculateTransactionTotal(); } }
        public virtual PaymentMethods PaymentMethod { get; set; }
        public bool HasDealWithStore { get; set; }
        public virtual IList<TransactionItem> Items { get; set; } = new List<TransactionItem>();         
        public void AddItem(TransactionItem item)
        {
            Items.Add(item);
        }
        public void AddItems(params TransactionItem[] items)
        {
            foreach (var item in items)
            {
                Items.Add(item);
            }
        }
        public decimal CalculateTransactionTotal()
        {
            return this.Items.Sum(p => p.CustomerValue * p.Quantity);
        }

    }
}