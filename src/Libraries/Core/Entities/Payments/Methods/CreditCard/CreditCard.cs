using System.Threading.Tasks;
using Core.Interfaces.Payments;
namespace Core.Entities.Payments
{
    public class CreditCard : PaymentMethod
    {
        protected readonly IPaymentProcessor _paymentProcessor;
        public CreditCard(IPaymentProcessor paymentProcessor)
        {
            _paymentProcessor = paymentProcessor;
            Name = "CreditCard";            
        }

        public Task<PaymentResult> ChargeAsync(Payment payment)
        {
            //TODO:Implement
            throw new System.NotImplementedException();
        }
    }
}