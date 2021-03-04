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
            
        }        
        public string FirstAddressLine { get; set; }
        public string SecondAddressLine { get; set; }
        public string Zipcode { get; set; }
        public string Addressnumber { get; set; }
        public string City { get; set; }
        public string AddressState { get; set; }
        public string District { get; set; }         
    }
}
