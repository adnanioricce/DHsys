using Core.Entities.Payments;
using System;
using System.Threading.Tasks;

namespace StripePlugin.Services.Interface
{
    public interface IStripePaymentService
    {
        Task<PaymentResult> ChargeOrderAsync(int orderId);
    }
}