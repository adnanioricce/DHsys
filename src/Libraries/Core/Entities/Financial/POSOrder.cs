using Core.Entities.Catalog;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Entities.Financial
{
    public class POSOrder : BaseEntity
    {
        public POSOrder()
        {
            HasDealWithStore = false;
            State = OrderState.New;
        }
        public decimal OrderTotal { get { return CalculateTransactionTotal(); } }
        public decimal DiscountTotal { get; protected set; }
        public virtual PaymentMethods PaymentMethod { get; protected set; }
        public bool HasDealWithStore { get; protected set; }
        public string ConsumerCode { get; protected set; }
        public OrderState State { get; protected set; }
        public bool HasEnded { get; protected set; }
        public bool PaidOut { get; protected set; }
        public virtual IList<POSOrderItem> Items { get; protected set; } = new List<POSOrderItem>();
        public void AddItem(int productId,int quantity,IRepository<Product> repository)
        {
            var item = POSOrderItem.Create(productId,quantity,this,repository);
            if(!item.Success) {
                return;
            }
            AddItem(item.Value);
        }
        public void AddItem(POSOrderItem item)
        {
            var existingItem = Items.Where(i => i.Id == item.Id).FirstOrDefault();
            if(existingItem is null){
                Items.Add(item);
                return;
            }
            var newItem = existingItem.Sum(item);
            this.Items.Remove(existingItem);
            this.Items.Add(newItem);
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