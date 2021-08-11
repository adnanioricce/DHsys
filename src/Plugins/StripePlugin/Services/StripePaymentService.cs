using Core.Entities.Orders;
using Core.Entities.Payments;
using Core.Interfaces;
using StripePlugin.Services.Interface;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace StripePlugin.Services
{
    public class StripePaymentService : IStripePaymentService
    {
        private readonly IRepository<POSOrder> _posOrderRepository;
        public StripePaymentService(IRepository<POSOrder> posOrderRepository)
        {
            _posOrderRepository = posOrderRepository;
        }
        public async Task<PaymentResult> ChargeOrderAsync(int orderId)
        {
            var order = await _posOrderRepository.GetByAsync(orderId);
            
        }
    }
}