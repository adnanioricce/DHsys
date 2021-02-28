using System;
using System.Threading.Tasks;
using Core.Entities.Payments;
using Core.Entities.User;
using Core.Interfaces;
using Core.Interfaces.Payments;
using Core.Models;

namespace Application.Services.Payments
{
    public class InHandsProcessor : IPaymentProcessor
    {
        
        public InHandsProcessor()
        {            
        }        

        public Task<PaymentResult> ProcessAsync(IPaymentRequest request)
        {
            request.SendAsync();
            throw new NotImplementedException();
        }
        
    }
    public class PaymentRequest : IPaymentRequest
    {        
        public Payment Payment { get; set; }        
        public PaymentRequest(Payment payment)
        {            
            Payment = payment;            
        }

        public Task<BaseResult<PaymentResult>> SendAsync()
        {
            // this.Payment.
            throw new NotImplementedException();
        }
    }
}