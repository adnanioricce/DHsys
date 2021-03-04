using System.Threading.Tasks;
using Core.Entities.Payments;
using Core.Models;

namespace Core.Interfaces.Payments
{
    public interface IPaymentRequest
    {
        Task<PaymentResult> SendAsync();
    }
}