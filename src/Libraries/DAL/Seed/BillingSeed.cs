using Core.Entities.Financial;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Seed
{
    public class BillingSeed : IDataObjectSeed<Billing>
    {
        public Billing GetSeedObject()
        {
            return new Billing
            {
                BeneficiaryId = 1,
                BeneficiaryName = "FAKE Beneficiary",
                CreatedAt = DateTimeOffset.UtcNow,
                Discount = 0,
                PersonType = Core.Entities.PersonDocumentType.Cnpj,
                UniqueCode = Guid.NewGuid().ToString(),
                Price = 12.99m,
                EndDate = DateTime.Today.AddDays(TimeSpan.FromDays(3).TotalDays),
                IsPaid = false,                
            };
        }
    }
}
