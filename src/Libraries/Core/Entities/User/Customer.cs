using Core.Interfaces;

namespace Core.Entities.User
{
    public class Customer : BaseEntity
    {
        public static Customer GetDefaultCustomer(IRepository<Customer> repository)
        {
            return repository.GetBy(1);
        }
    }
}