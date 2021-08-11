using Core.Entities.Orders;
using Core.Entities.Payments;
using Core.Interfaces.Payments;
using Stripe;
using System.Threading.Tasks;

namespace StripePlugin.Requests
{
    public class ChargeOrderCommand : IPaymentCommand
    {
        private readonly POSOrder _order;
        private readonly Payment _payment;
        public ChargeOrderCommand(POSOrder order,Payment payment)
        {
            _order = order;
            _payment = payment;
        }
        public async Task<PaymentResult> SendAsync()
        {
            var options = new ChargeCreateOptions
            {
              Amount = (long)(_payment.ReceivedValue * 100),
              Currency = _payment.Currency.ToLower(),
              Source = "tok_mastercard",
              Description = $"Payment {_payment.Id} for Order {_order.UniqueCode}",
            };
            var service = new ChargeService();
            Charge charge = service.Create(options);
            if(charge.Status == "failed")
            {
                return PaymentResult.Failed();
            }
            if(charge.Status == "pending")
            {                
                return PaymentResult.Pending(_payment);
            }
            await _order.PayAsync(_payment.ReceivedValue,_payment.Customer);
            //_payment
        }
    }
}
