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
        /// <summary>
        /// EF constructor
        /// </summary>        
        private Payment()
        {
            
        }
        protected Payment(decimal receivedValue,decimal neededValue,PaymentStatus status,PaymentMethod method,Customer customer)
        {
            ReceivedValue = receivedValue;
            NeededValue = neededValue;
            Status = status;
            Method = method;
            Customer = customer;
        }        
        public string ExternalId { get; set; }
        public virtual Customer Customer { get; protected set; }        
        public virtual PaymentMethod Method { get; protected set; }        
        public virtual PaymentStatus Status { get; protected set; }        
        public decimal ReceivedValue { get; protected set; }
        public decimal NeededValue { get; protected set; }
        public decimal Change { get; protected set; }
        public string Currency { get; set; }
        
        public static Payment Create(PaymentMethod method,Customer customer,decimal receivedValue,decimal neededValue)
        {
            if(receivedValue <= 0){
                throw new DomainException("is not possible to define a payment with a value less than or equal to zero");
            }
            return new Payment(receivedValue,neededValue,PaymentStatus.Pending,method,customer);
        }
        public static Payment Zero()
        {
            return new Payment{
                ExternalId = "",                
                Currency = "",
                Change = 0.0m,
                ReceivedValue = 0.0m,
                NeededValue = 0.0m,
                Status = PaymentStatus.ZeroOrNegative                
            };
        }
    }
}