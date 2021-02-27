using Core.Interfaces.Payments;

namespace Core.Entities.Payments
{
    public class InHands : PaymentMethod
    {
        public InHands(IPaymentMethodService paymentMethodService) : base(paymentMethodService,PaymentMethods.InHands)
        {
            
        }
        public override PaymentMethods Name { get; protected set; }
    }
}