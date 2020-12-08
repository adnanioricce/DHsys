using Core.Entities.Stock;
using System;

namespace DAL.Seed
{
    public class SupplierSeed : IDataObjectSeed<Supplier>
    {
        public Supplier GetSeedObject()
        {
            var supplier = new Supplier();
            supplier.Address = new Core.Entities.Address
            {
                Addressnumber = "2222",
                District = "District",
                AddressState = "State",
                City = "City",
                Zipcode = "01223455"
            };            
            supplier.CreatedAt = DateTimeOffset.UtcNow;
            supplier.Cnpj = "1234567788";
            supplier.Name = "Supplier name";            
            supplier.UniqueCode = Guid.NewGuid().ToString();
            return supplier;
        }
    }
}
