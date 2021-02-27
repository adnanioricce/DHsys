using Core.Interfaces.Payments;

namespace Core.Entities.Payments
{
    public class CreditCard : PaymentMethod
    {
        public CreditCard(IPaymentMethodService paymentMethodService) : base(paymentMethodService,PaymentMethods.CreditCard)
        {
            
        }   
    }
}