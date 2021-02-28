using System;
using System.Threading.Tasks;
using Core.Entities.User;
using Core.Interfaces;
using Core.Interfaces.Payments;
using Core.Models;

namespace Core.Entities.Payments
{
    public class Payment : BaseEntity
    {
        protected Payment(decimal value,PaymentStatus status,PaymentMethod method,Customer customer)
        {
            Value = value;
            Status = status;
            Method = method;
            Customer = customer;
        }        
        public virtual Customer Customer { get; protected set; }        
        public virtual PaymentMethod Method { get; protected set; }        
        public virtual PaymentStatus Status { get; protected set; }        
        public decimal Value { get; protected set; }
        public decimal Change { get; protected set; }
        public static Payment Create(PaymentMethod method,Customer customer,decimal value)
        {
            if(value <= 0){
                throw new DomainException("is not possible to define a payment with a value less than or equal to zero");
            }
            return new Payment(value,PaymentStatus.Pending,method,customer);
        }        
        public async Task<PaymentResult> IssueAsync()
        {
            var chargeResult = await this.Method.ChargeAsync(payment:this);
            this.Status = chargeResult.PaymentStatus;
            this.Change = chargeResult.Change;
            return chargeResult;            
        }
    }
}