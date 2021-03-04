namespace Core.Entities.Payments
{
    using System.Threading.Tasks;
    using global::Core.Interfaces.Payments;
    using global::Core.Models;

    public class PaymentMethod : BaseEntity
    {
        protected readonly IPaymentMethodService _paymentMethodService;
        /// <summary>
        /// EF Constructor
        /// </summary>        
        protected PaymentMethod() 
        {
            
        }
        protected PaymentMethod(IPaymentMethodService paymentMethodService,PaymentMethods method)
        {
            _paymentMethodService = paymentMethodService;
            Name = method;
        }
        public virtual PaymentMethods Name { get; protected set; }
        public bool AcceptsPartialPayments { get; protected set; }
        public bool HasChange { get; protected set; }
        
        public virtual Task<PaymentResult> ChargeAsync(Payment payment)
        {
            return _paymentMethodService.IssuePaymentAsync(payment);
        }        
    }
}