using Core.Interfaces.Payments;

namespace Core.Entities.Payments
{
    public class InHands : PaymentMethod
    {
        public InHands(bool acceptsPartialPayment,IPaymentMethodService paymentMethodService) : base(paymentMethodService,PaymentMethods.InHands)
        {
            AcceptsPartialPayments = acceptsPartialPayment;
        }
        
        public override PaymentMethods Name { get; protected set; }
    }
}