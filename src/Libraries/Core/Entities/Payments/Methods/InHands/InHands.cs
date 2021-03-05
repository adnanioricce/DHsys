using Core.Entities.Payments.Methods;
using System.Threading.Tasks;
using Core.Interfaces.Payments;

namespace Core.Entities.Payments.Methods.InHands
{
    public class InHands : PaymentMethod
    {
        IPaymentProcessor _paymentProcessor;
        private InHands() : base() { }
        public InHands(bool acceptsPartialPayment,IPaymentProcessor paymentProcessor)
        {
            AcceptsPartialPayments = acceptsPartialPayment;
            _paymentProcessor = paymentProcessor;
        }

        public Task<PaymentResult> ChargeAsync(Payment payment)
        {
            var chargeRequest = new InHandsChargeRequest(payment);
            if(!AcceptsPartialPayments && (payment.ReceivedValue < payment.NeededValue)){
                return Task.FromResult(PaymentResult.Failed());
            }
            return chargeRequest.SendAsync();
        }
    }
    public class InHandsChargeRequest : IPaymentRequest
    {        
        public Payment Payment { get; set; }
        public InHandsChargeRequest(Payment payment)
        {            
            Payment = payment;            
        }

        public async Task<PaymentResult> SendAsync()
        {                        
            await Task.Delay(0);
            return PaymentResult.Create(Payment);
        }
    }
}