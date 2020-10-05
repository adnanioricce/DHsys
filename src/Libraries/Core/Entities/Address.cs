using System;
using System.Collections.Generic;
using Core.Entities.Financial;
using Core.Entities.Stock;

namespace Core.Entities
{
    public class Address : BaseEntity
    {
        public Address()
        {
            Clients = new HashSet<Client>();
            Manufacturer = new HashSet<Manufacturer>();
            Suppliers = new HashSet<Supplier>();
        }        
        public string FirstAddressLine { get; set; }
        public string SecondAddressLine { get; set; }
        public string Zipcode { get; set; }
        public string Addressnumber { get; set; }
        public string City { get; set; }
        public string AddressState { get; set; }
        public string District { get; set; }
        public virtual ICollection<Client> Clients { get; set; }
        public virtual ICollection<Manufacturer> Manufacturer { get; set; }
        public virtual ICollection<Supplier> Suppliers { get; set; }        
    }
}
