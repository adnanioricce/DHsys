using System.Threading.Tasks;
using Core.Entities.Payments;
using Core.Interfaces;
using Core.Interfaces.Payments;
using Core.Models;

namespace Application.Services.Payments
{
    ///<summary>
    ///A mediator class to handle transactions between the <see cref="IPaymentProcessor"/> of the payment provider and the domain context
    ///</summary>
    public class InHandsPaymentService : IPaymentMethodService
    {
        protected readonly IPaymentProcessor _processor;
        protected readonly IRepository<Payment> _paymentRepository;
        public InHandsPaymentService(IPaymentProcessor processor,IRepository<Payment> paymentRepository)
        {
            _processor = processor;
            _paymentRepository = paymentRepository;
        }
        public async Task<PaymentResult> IssuePaymentAsync(Payment payment)
        {
            var result = await _processor.ProcessAsync(new PaymentRequest(payment));
            _paymentRepository.Add(payment);
            await _paymentRepository.SaveChangesAsync();
            return result;
        }
    }    
}