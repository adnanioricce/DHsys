using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stripe;

namespace Application.Services.Payments.Providers
{
    public interface IStripeService
    {
        void Authenticate(string apiKey);
        Charge CreateCharge();
    }
}
