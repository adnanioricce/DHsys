using Core.Entities.Inventory;
using System;

namespace DAL.Seed
{
    public class SupplierSeed : IDataObjectSeed<Supplier>
    {
        public Supplier GetSeedObject()
        {
            var supplier = new Supplier
            {
                Address = new Core.Entities.Address
                {
                    Addressnumber = "2222",
                    District = "District",
                    AddressState = "State",
                    City = "City",
                    Zipcode = "01223455"
                },
                CreatedAt = DateTimeOffset.UtcNow,
                Cnpj = "1234567788",
                Name = "Supplier name",
                UniqueCode = Guid.NewGuid().ToString()
            };
            return supplier;
        }
    }
}
