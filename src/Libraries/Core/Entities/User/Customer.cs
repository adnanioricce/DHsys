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
        public virtual ICollection<CustomerAddress> Addresses { get; set; } = new List<CustomerAddress>();
        //TODO:this is country specific, should this be defined here?
        public string Name { get; protected set; }
        public string CPF { get; protected set; }
        public Customer(string cpf)
        {            
            CPF = cpf;
        }
        public Customer(string cpf,string name) : this(cpf)
        {
            Name = name;
        }
        public Customer()
        {

        }
    }
}