using System.Threading.Tasks;
using Core.Entities.Payments;
using Core.Models;
using Core.Models.Results;

namespace Core.Interfaces.Payments
{
    public interface IPaymentCommand
    {
        Task<Result<Payment>> SendAsync();
    }
}