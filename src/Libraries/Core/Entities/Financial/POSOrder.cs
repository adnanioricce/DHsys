using Core.Entities.Catalog;
using Core.Entities.Payments;
using Core.Interfaces;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public decimal RemainingValueToPay { get; protected set; }
        public List<Payment> Payments { get; protected set; } = new List<Payment>();
        public bool HasDealWithStore { get; protected set; }
        public string ConsumerCode { get; protected set; }
        public virtual OrderState State { get; protected set; }
        public bool HasEnded { get; protected set; }
        public bool PaidOut { get; protected set; }
        public virtual IList<POSOrderItem> Items { get; protected set; } = new List<POSOrderItem>();
        public virtual void AddItem(int productId,int quantity,IRepository<Product> repository)
        {
            var item = POSOrderItem.Create(productId,quantity,this,repository);
            if(!item.Success) {
                return;
            }
            AddItem(item.Value);
        }
        public virtual void AddItem(POSOrderItem item)
        {
            if(this.State == OrderState.Cancelled){
                return;
            }
            var existingItem = Items.Where(i => i.Id == item.Id).FirstOrDefault();
            if(existingItem is null){
                Items.Add(item);
                return;
            }
            var newItem = existingItem.Sum(item);
            this.Items.Remove(existingItem);
            this.Items.Add(newItem);
        }
        public virtual void Cancel()
        {
            this.State = OrderState.Cancelled;
            this.HasEnded = true;
            this.PaidOut = false;
        }
        public virtual async Task<BaseResult<object>> PayAsync(Payment payment)
        {
            if(this.State == OrderState.Cancelled){
                return BaseResult<object>.CreateFailResult(new []{"can't pay a cancelled order"},default(object));
            }
            var result = await payment.IssueAsync();
            this.Payments.Add(payment);
            switch (payment.Status){
                case PaymentStatus.Paid:
                    if(payment.Status == PaymentStatus.Paid){
                        var paymentSum = this.Payments.Where(p => p.Status == PaymentStatus.Paid).Sum(p => p.Value);
                        if(paymentSum == this.OrderTotal){
                            this.State = OrderState.Paid;
                            this.PaidOut = true;                            
                        }
                    }
                    //TODO: Is there a better way to define and return results?
                    return BaseResult<object>.CreateSuccessResult("order paid with success", result);
                default:
                    return BaseResult<object>.CreateFailResult(new [] {"couldn't paid order "}, result);
            }
        }
        public virtual decimal CalculateTransactionTotal()
        {
            return this.Items.Sum(p => p.CustomerValue * p.Quantity);
        }

        
    }
}