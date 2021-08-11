using Core.Entities.Payments;
using Core.Models;
using Core.Interfaces.Payments;
using System.Threading.Tasks;
using Stripe;

namespace Application.Services.Payments.Providers.Stripe.Requests
{
    public class CreateChargeRequest : IPaymentCommand
    {
        private readonly string _sourceToken;
        private readonly Payment Payment;
        public CreateChargeRequest(Payment payment,string sourceToken)
        {
            Payment = payment;
            _sourceToken = sourceToken;
        }
        

        public async Task<BaseResult<Payment>> SendAsync()
        {
            var charge = new ChargeCreateOptions
            {
                Amount = (long)(this.Payment.ReceivedValue * 100),
                Currency = this.Payment.Currency,
                Source = _sourceToken,
                Description = $"Payment :{this.Payment.UniqueCode}, Charge value:{this.Payment.ReceivedValue}"
            };
            var chargeService = new ChargeService();
            var response = await chargeService.CreateAsync(charge);
            if(response.Status == "failed"){
                response.FailureMessage;
                return PaymentResult.Failed();
            }
            return PaymentResult.Paid(this.Payment);
        }
    }
}