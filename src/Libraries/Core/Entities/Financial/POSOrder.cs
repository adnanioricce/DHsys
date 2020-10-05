using Core.Entities.Catalog;
using System.Collections.Generic;
using System.Linq;

namespace Core.Entities.Financial
{
    public class POSOrder : BaseEntity
    {
        public POSOrder()
        {
            HasDealWithStore = false;
        }
        public decimal OrderTotal { get { return CalculateTransactionTotal(); } }
        public virtual PaymentMethods PaymentMethod { get; set; }
        public bool HasDealWithStore { get; set; }
        public virtual IList<POSOrderItem> Items { get; set; } = new List<POSOrderItem>();         
        public void AddItem(POSOrderItem item)
        {
            Items.Add(item);
        }
        public void AddItems(params POSOrderItem[] items)
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