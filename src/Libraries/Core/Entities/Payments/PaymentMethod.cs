namespace Core.Entities.Payments
{
    using System.Threading.Tasks;
    using global::Core.Interfaces.Payments;
    using global::Core.Models;

    public class PaymentMethod : BaseEntity
    {
        protected readonly IPaymentMethodService _paymentMethodService;
        protected PaymentMethod(IPaymentMethodService paymentMethodService,PaymentMethods method)
        {
            _paymentMethodService = paymentMethodService;
            Name = method;
        }
        public virtual PaymentMethods Name { get; protected set; }
        
        public Task<BaseResult<Payment>> ChargeAsync(Payment payment)
        {
            return _paymentMethodService.IssuePaymentAsync(payment);
        }        
    }
}