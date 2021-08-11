using System.Threading.Tasks;
using Core.Entities.Payments;
using Core.Interfaces.Payments;
using Infrastructure.Interfaces;
using Stripe;

namespace Application.Services.Payments.Providers
{
    public class StripeService : IStripeService,IPaymentMethodService
    {
        private readonly string _apiKey;
        public StripeService(string apiKey)
        {
            _apiKey = apiKey;
        }
        public void Authenticate(string apiKey)
        {
            var options = new RequestOptions
            {
                ApiKey = "sk_test_4eC39HqLyjWDarjtT1zdp7dc"
            };
        }

        public Charge CreateCharge()
        {
            throw new System.NotImplementedException();
        }

        public async Task<PaymentResult> IssuePaymentAsync(Payment payment)
        {
            var charge = new ChargeCreateOptions()
            {
                Amount = (long)(payment.ReceivedValue * 100),
                Currency = "BR",//TODO: Define a property on payment to hold the information of what currency it's using,
                Source = "tok_amex",
                Description = "My First Test Charge (created for API docs)",

            };
            var chargeService = new ChargeService();
            var result = await chargeService.CreateAsync(charge);
            if (!result.Captured || !result.Paid)
            {
                return PaymentResult.Failed();
            }
            
            return result.Amount != result.AmountCaptured ? PaymentResult.PartiallyPaid(payment) : PaymentResult.Paid(payment);
        }
    }
}
