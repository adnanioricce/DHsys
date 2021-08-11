using System;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Payments;
using Core.Entities.Payments.Methods;
using Core.Interfaces;
using Core.Interfaces.Payments;
using Microsoft.EntityFrameworkCore;
using Stripe;

namespace Application.Services.Payments.Providers.Stripe.Requests
{
    public class GetChargeRequest : IPaymentQuery<Payment>
    {
        private readonly string _chargeId;
        private readonly IRepository<Payment> _paymentRepository;
        public GetChargeRequest(IRepository<Payment> paymentRepository,string chargeId)
        {
            _paymentRepository = paymentRepository;
            _chargeId = chargeId;
        }

        public async Task<Payment> GetAsync()
        {
            var payment = await _paymentRepository
                .Query()
                .Where(p => p.ExternalId == _chargeId)
                .FirstOrDefaultAsync();
            if(payment is null){
                return Payment.Zero();
            }
            return payment;
        }        
    }
}