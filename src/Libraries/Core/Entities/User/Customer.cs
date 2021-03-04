using Core.Interfaces;
using System.Collections.Generic;

namespace Core.Entities.User
{
    public class Customer : BaseEntity
    {
        public static Customer GetDefaultCustomer(IRepository<Customer> repository)
        {
            return repository.GetBy(1);
        }
        public ICollection<Address> Addresses { get; set; } = new List<Address>();
        //TODO:this is country specific, should this be defined here?
        public string CPF { get; protected set; }
        public Customer(string cpf)
        {            
            CPF = cpf;
        }
        public Customer()
        {

        }
    }
}