using System.Threading.Tasks;
using Core.ApplicationModels.Dtos.Payments;
using Core.Entities.Payments;
using Core.Models.Results;

namespace Core.Interfaces.Payments
{
    public interface IPaymentMethodService
    {
        Task<Result<PaymentDto>> ChargePaymentAsync(Payment payment);
    }
}