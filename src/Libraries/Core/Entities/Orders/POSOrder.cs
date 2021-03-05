using Core.Entities.Catalog;
using Core.Entities.Payments;
using Core.Entities.User;
using Core.Interfaces;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities.Orders
{
    public class POSOrder : BaseEntity
    {
        public POSOrder()
        {
            HasDealWithStore = false;
            State = OrderState.New;
        }
        public POSOrder(PaymentMethod paymentMethod) : this()
        {
            PaymentMethod = paymentMethod;
        }
        public decimal OrderTotal { get { return CalculateTransactionTotal(); } }
        public decimal DiscountTotal { get; protected set; }
        public decimal RemainingValueToPay { get; protected set; }
        public decimal Change { get; protected set; }
        public PaymentMethod PaymentMethod { get; protected set; }//TODO: refactor to use this only on Payment entity
        public virtual ICollection<Payment> Payments { get; protected set; } = new List<Payment>();
        public bool HasDealWithStore { get; protected set; }
        public string ConsumerCode { get; protected set; }
        public virtual OrderState State { get; protected set; }
        public bool HasEnded { get; protected set; }
        public bool PaidOut { get; protected set; }
        public virtual ICollection<POSOrderItem> Items { get; protected set; } = new List<POSOrderItem>();
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
                this.RemainingValueToPay += item.Quantity * item.CustomerValue;
                return;
            }
            var newItem = existingItem.Sum(item);
            this.Items.Remove(existingItem);
            this.Items.Add(newItem);
            this.RemainingValueToPay += item.Quantity * item.CustomerValue;
        }
        public virtual void Cancel()
        {
            this.State = OrderState.Cancelled;
            this.HasEnded = true;
            this.PaidOut = false;
        }
        public virtual async Task PayAsync(decimal valueReceived, Customer customer)
        {
            if(this.State == OrderState.Cancelled){
                return;
                //return BaseResult.Failed(new []{"can't pay a cancelled order"});
            }
            if(!this.PaymentMethod.AcceptsPartialPayments && valueReceived < this.OrderTotal){
                this.State = OrderState.Failed;
                //return BaseResult.Failed(new [] {"the chosen payment method don't accept partial payments"});
            }
            var payment = Payment.Create(this.PaymentMethod,customer, valueReceived, this.OrderTotal);
            await payment.IssueAsync();
            this.Payments.Add(payment);
            switch (payment.Status){
                case PaymentStatus.Paid:
                    UpdateOrderTotal(payment);
                    return;
                    //return BaseResult.Succeed("order paid with success");
                default:
                    return;
                    //return BaseResult.Failed(new [] {"couldn't paid order "});
            }
        }
        protected virtual void UpdateOrderTotal(Payment payment)
        {
            if(payment.Status == PaymentStatus.Paid){
                var paymentSum = this.Payments.Where(p => p.Status == PaymentStatus.Paid).Sum(p => p.ReceivedValue);
                if(paymentSum >= this.OrderTotal){
                    ConfirmPaymentValue(paymentSum);                    
                }                
            }
            void ConfirmPaymentValue(decimal paymentValue)
            {
                this.State = OrderState.Paid;
                this.PaidOut = true;
                this.RemainingValueToPay = 0;
                this.Change = paymentValue - this.OrderTotal;
            }
        }       
        protected virtual decimal CalculateTransactionTotal()
        {
            return this.Items.Sum(p => p.CustomerValue * p.Quantity);
        }

        public void DefinePaymentMethod(PaymentMethod paymentMethod)
        {
            this.PaymentMethod = paymentMethod;
        }
    }
}