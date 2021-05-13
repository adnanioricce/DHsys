using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Payments;
using Core.Interfaces.Payments;

namespace Application.Services.Payments.Providers
{
    public class StripeProcessor : IPaymentProcessor
    {
        public Task<PaymentResult> ProcessAsync(IPaymentRequest request)
        {
            return null;
        }
    }
}
