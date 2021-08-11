using System.Threading.Tasks;
using Core.Interfaces.Payments;
namespace Core.Entities.Payments.Methods.CreditCard
{
    public class CreditCard : PaymentMethod
    {
        protected readonly IPaymentProcessor _paymentProcessor;
        protected CreditCard()
        {

        }
        public CreditCard(IPaymentProcessor paymentProcessor)
        {
            _paymentProcessor = paymentProcessor;
            Name = "CreditCard";            
        }        
    }
}