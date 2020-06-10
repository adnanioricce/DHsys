using Core.Entities.Catalog;
using System.Collections.Generic;
using System.Linq;

namespace Core.Entities.Financial
{
    public class Transaction : BaseEntity
    {                
        public decimal TransactionTotal { get; set; }
        public virtual PaymentMethods PaymentMethod { get; set; }
        public bool HasDealWithStore { get; set; }        
        public virtual IList<TransactionItem> Items { get; set; } = new List<TransactionItem>();         
        public void AddItem(TransactionItem item)
        {
            Items.Add(item);
        }
    }
}