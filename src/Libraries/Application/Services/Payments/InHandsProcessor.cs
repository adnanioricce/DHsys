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
            return request.SendAsync();
        }
        
    }
    public class PaymentRequest : IPaymentRequest
    {        
        public Payment Payment { get; set; }
        public PaymentRequest(Payment payment)
        {            
            Payment = payment;            
        }

        public async Task<PaymentResult> SendAsync()
        {            
            await Task.Delay(0);//TODO: How to refactor this?
            return PaymentResult.Create(Payment);
        }
    }
}