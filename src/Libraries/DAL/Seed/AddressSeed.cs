using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Seed
{
    public class AddressSeed : IDataObjectSeed<Address>
    {
        public Address GetSeedObject()
        {
            var address = new Address
            {
                Addressnumber = "1222",
                AddressState = "State",
                CreatedAt = DateTimeOffset.UtcNow,
                City = "City",
                District = "District",
                FirstAddressLine = "First Address Line",
                SecondAddressLine = "Second Address Line",
                UniqueCode = Guid.NewGuid().ToString(),
                Zipcode = "123456789"
            };
            return address;
        }
    }
}
