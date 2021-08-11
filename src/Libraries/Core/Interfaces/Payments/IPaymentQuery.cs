using System.Threading.Tasks;

namespace Core.Interfaces.Payments
{
    public interface IPaymentQuery<T> where T : class
    {
        Task<T> GetAsync();
    }
}
