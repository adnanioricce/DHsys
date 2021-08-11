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

        public Task<PaymentResult> ProcessAsync(IPaymentCommand request)
        {
            return request.SendAsync();
        }
        
    }
    
}