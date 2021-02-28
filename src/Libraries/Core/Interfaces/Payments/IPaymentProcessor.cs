using System.Threading.Tasks;
using Core.Entities.Payments;
using Core.Entities.User;
using Core.Models;

namespace Core.Interfaces.Payments
{
    public interface IPaymentProcessor
    {
        Task<PaymentResult> ProcessAsync(IPaymentRequest request);
    }
}